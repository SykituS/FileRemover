using FileRemover.Models;
using System.Diagnostics;
using System.IO;

namespace FileRemover.Services;

public class FileService
{
    private List<FileDetails> _files = new();

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
        _files.Clear();

        try
        {
            RetrieveFilesFromDirectory(directoryDetails.SelectedPath, directoryDetails);
            CheckSubDirectoriesAndRetrieveFiles(directoryDetails.SelectedPath, directoryDetails);
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
                    if (subDirectories.Any())
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