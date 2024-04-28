using System.ComponentModel;
using FileRemover.Models;
using FileRemover.Services;

namespace FileRemover.Controllers;

public class MainWindowController
{
    private readonly FileService _fileService;

    public MainWindowController(FileService fileService)
    {
        _fileService = fileService;
    }

    public Result RemoveFiles(List<FileDetails> files)
    {
        var result = _fileService.RemoveFiles(files);

        return result;
    }


    public (List<FileDetails> files, bool success) GetFilesInGivenDirectory(DirectoryDetails directoryDetails, BackgroundWorker backgroundWorkerGetFiles)
    {
        var (files, success) = _fileService.SearchForFilesInDirectory(directoryDetails, backgroundWorkerGetFiles);

        return (files, success);
    }

}