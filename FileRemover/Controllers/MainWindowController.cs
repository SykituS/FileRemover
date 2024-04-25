using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileRemover.Models;
using FileRemover.Services;

namespace FileRemover.Controllers;

public class MainWindowController
{
    private readonly FileService _fileService;
    private readonly UserDataContext _userDataContext;

    public MainWindowController(FileService fileService, UserDataContext userDataContext)
    {
        _fileService = fileService;
        _userDataContext = userDataContext;
    }

    public Result RemoveFiles()
    {
        var result = _fileService.RemoveFiles(_userDataContext.FilesDetailsList);

        _userDataContext.FilesDetailsList.Clear();

        return result;
    }


    public Result GetFilesInGivenDirectory(DirectoryDetails directoryDetails)
    {
        var result = _fileService.SearchForFilesInDirectory(directoryDetails);
    }

}