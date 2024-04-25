using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRemover.Models;

public class FileDetails
{
    public bool IsDeletable { get; set; }

    public string FileName { get; set; }
    public DateTime FileModificationDate { get; set; }
    public string FilePath { get; set; }
}

public record DirectoryDetails(
    string SelectedPath,
    DateTime StartDate,
    DateTime EndDate,
    DateTime StartTime,
    DateTime EndTime,
    string? FileExtensionToSearch);