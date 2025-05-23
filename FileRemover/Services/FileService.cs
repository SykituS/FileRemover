﻿using System.ComponentModel;
using FileRemover.Models;
using System.Diagnostics;
using System.IO;

namespace FileRemover.Services;

public class FileService
{
    private readonly List<FileDetails> _files = new();
    private BackgroundWorker? _worker;

    public Result RemoveFiles(List<FileDetails> filesDetailsList)
    {
        var result = new Result();
        var numerator = 0;
        try
        {
            foreach (var file in filesDetailsList)
            {
                if (!file.IsDeletable)
                {
                    continue;
                }
#if RELEASE
				File.Delete(file.FilePath);
#endif
                numerator++;
            }

            result.Success = true;
            result.Message = $"Pomyślnie usunięto {numerator} / {filesDetailsList.Count}";
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Error while removing file {e}");
            result.Success = false;
            result.Message = $"Wystąpił nieoczekiwany błąd w trakcie usuwania plików, usunięto {numerator} / {filesDetailsList.Count}";
        }

        return result;
    }

    public (List<FileDetails> files, bool success) SearchForFilesInDirectory(DirectoryDetails directoryDetails, BackgroundWorker backgroundWorkerGetFiles)
    {
        _files.Clear();
        _worker = backgroundWorkerGetFiles;

        try
        {
            RetrieveFilesFromAllDirectories(directoryDetails.SelectedPath, directoryDetails);
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Unexpected error occured: {e}");
        }


        return (_files, true);
    }

    private void CheckSubDirectoriesAndRetrieveFiles(string path, DirectoryDetails directoryDetails)
    {
        var directories = Directory.GetDirectories(path);

        if (!directories.Any())
        {
            RetrieveFilesFromDirectory(path, directoryDetails);
        }
        else
        {
            foreach (var directory in directories)
            {
                try
                {
                    var subDirectories = Directory.GetDirectories(directory);
                    if (subDirectories.Length != 0)
                    {
                        foreach (var subDirectory in subDirectories)
                        {
                            CheckSubDirectoriesAndRetrieveFiles(subDirectory, directoryDetails);
                        }
                    }

                    RetrieveFilesFromDirectory(directory, directoryDetails);
                }
                catch (Exception e)
                {
                    Debug.WriteLine($"Unable to read {directory} | {e}");
                }
            }
        }

    }

    private void RetrieveFilesFromAllDirectories(string rootPath, DirectoryDetails details)
    {
        try
        {
            var allDirectories = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories)
                .Prepend(rootPath); // include root directory itself

            foreach (var dir in allDirectories)
            {
                RetrieveFilesFromDirectory(dir, details);
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Error while traversing directories: {e}");
        }
    }

    private void RetrieveFilesFromDirectory(string path, DirectoryDetails directoryDetails)
    {
        try
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                CheckFileAndAddToList(directoryDetails, file);
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Unable to read {path} | {e}");
        }
    }

    private void CheckFileAndAddToList(DirectoryDetails directoryDetails, string file)
    {

        if (!string.IsNullOrEmpty(directoryDetails.FileExtensionToSearch))
        {
            var extension = Path.GetExtension(file);
            if (!string.Equals(directoryDetails.FileExtensionToSearch, extension, StringComparison.CurrentCultureIgnoreCase))
            {
                return;
            }
        }

        var modificationTime = File.GetLastWriteTime(file);
        if (!ValidateFileModificationTime(directoryDetails, modificationTime))
        {
            return;
        }

        var fileDetails = new FileDetails
        {
            IsDeletable = true,
            FilePath = file,
            FileName = Path.GetFileName(file),
            FileModificationDate = modificationTime,
        };

        _files.Add(fileDetails);
        _worker?.ReportProgress(0, _files.Count);
    }


    private bool IsWithinDateRange(DateTime date, DateTime start, DateTime end)
    => start.Date <= date.Date && date.Date <= end.Date;

    private bool IsWithinTimeRange(DateTime time, TimeSpan start, TimeSpan end)
        => start <= time.TimeOfDay && time.TimeOfDay <= end;

    private bool ValidateFileModificationTime(DirectoryDetails details, DateTime modificationDate)
    {
        // Check date-specific overrides first
        foreach (var exception in details.DateExceptions)
        {
            if (modificationDate.Date == exception.Date.Date)
            {
                return IsWithinTimeRange(modificationDate, exception.StartTime, exception.EndTime);
            }
        }

        // Fallback to global rule
        return IsWithinDateRange(modificationDate, details.StartDate, details.EndDate) &&
               IsWithinTimeRange(modificationDate, details.StartTime.TimeOfDay, details.EndTime.TimeOfDay);
    }
}