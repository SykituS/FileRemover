using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;
using FileRemover.Models;

namespace FileRemover.Services;

public class FileService
{
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

    public (List<FileDetails> files, bool success) SearchForFilesInDirectory(DirectoryDetails directoryDetails)
    {
        var fileList = new List<FileDetails>();

        try
        {
            RetrieveFilesFromDirectory(directoryDetails.SelectedPath, directoryDetails, fileList);
            CheckSubDirectoriesAndRetrieveFiles(directoryDetails.SelectedPath, directoryDetails, fileList);
        }
        catch (Exception e)
        {
            return (new List<FileDetails>(), false);

        }


        return (fileList, true);
    }

    private void CheckSubDirectoriesAndRetrieveFiles(string path, DirectoryDetails directoryDetails, List<FileDetails> fileList)
    {
        var directories = Directory.GetDirectories(path);
        foreach (var directory in directories)
        {
            try
            {
                var subDirectories = Directory.GetDirectories(directory);
                if (subDirectories.Any())
                {
                    foreach (var subDirectory in subDirectories)
                    {
                        CheckSubDirectoriesAndRetrieveFiles(subDirectory, directoryDetails, fileList);
                    }
                }

                RetrieveFilesFromDirectory(directory, directoryDetails, fileList);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Unable to read {directory} | {e}");
            }
        }
    }

    private void RetrieveFilesFromDirectory(string path, DirectoryDetails directoryDetails, List<FileDetails> fileList)
    {
        var files = Directory.GetFiles(path);
        foreach (var file in files)
        {
            CheckFileAndAddToList(directoryDetails, file, fileList);
        }
    }

    private void CheckFileAndAddToList(DirectoryDetails directoryDetails, string file, List<FileDetails> fileList)
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

        fileList.Add(fileDetails);
    }


    private bool ValidateFileModificationTime(DirectoryDetails directoryDetails, DateTime modificationDate)
    {
        if (directoryDetails.StartDate.Date > modificationDate.Date ||
            modificationDate.Date > directoryDetails.EndDate.Date)
        {
            return false;
        }

        if (directoryDetails.StartDate.TimeOfDay > modificationDate.TimeOfDay ||
            modificationDate.TimeOfDay > directoryDetails.EndTime.TimeOfDay)
        {
            return false;
        }
        
        return true;
    }
}