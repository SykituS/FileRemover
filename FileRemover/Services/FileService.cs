using System.ComponentModel;
using FileRemover.Models;
using System.Diagnostics;

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

        bool success;
        try
        {
            RetrieveFilesFromAllDirectories(directoryDetails.SelectedPath, directoryDetails);
            success = true;
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Unexpected error occured: {e}");
            success = false;
        }


        return (_files, success);
    }

    private void RetrieveFilesFromAllDirectories(string rootPath, DirectoryDetails details)
    {
        var directoriesToProcess = new Stack<string>();
        directoriesToProcess.Push(rootPath);

        while (directoriesToProcess.Count > 0)
        {
            var currentDir = directoriesToProcess.Pop();

            try
            {
                // Process files in current directory
                RetrieveFilesFromDirectory(currentDir, details);

                // Get subdirectories
                var subDirs = Directory.GetDirectories(currentDir);
                foreach (var subDir in subDirs)
                {
                    directoriesToProcess.Push(subDir);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Debug.WriteLine($"Access denied to {currentDir}: {e.Message}");
            }
            catch (PathTooLongException e)
            {
                Debug.WriteLine($"Path too long: {currentDir}: {e.Message}");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Unexpected error in {currentDir}: {e.Message}");
            }
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