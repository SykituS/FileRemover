namespace FileRemover.Models;

public class DirectoryDetails(
    string SelectedPath,
    DateTime StartDate,
    DateTime EndDate,
    DateTime StartTime,
    DateTime EndTime,
    string? FileExtensionToSearch)
{
    public string SelectedPath { get; } = SelectedPath;
    public DateTime StartDate { get; } = StartDate;
    public DateTime EndDate { get; } = EndDate;
    public DateTime StartTime { get; } = StartTime;
    public DateTime EndTime { get; } = EndTime;
    public string? FileExtensionToSearch { get; } = FileExtensionToSearch;
    public List<SpecificDateTimeRange> DateExceptions { get; set; } = new();
}

public class SpecificDateTimeRange
{
    public DateTime Date { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}
