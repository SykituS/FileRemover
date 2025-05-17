namespace FileRemover.Models;

public class FileDetails
{
    public bool IsDeletable { get; set; }

    public string FileName { get; set; }
    public DateTime FileModificationDate { get; set; }
    public string FilePath { get; set; }
}

