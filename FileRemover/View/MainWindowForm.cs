using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Csla;
using FileRemover.Controllers;
using FileRemover.Models;
using FileRemover.Properties;

namespace FileRemover;

public partial class MainWindowForm : Form
{
    private List<FileDetails> _filesDetailsList = new();

    private readonly MainWindowController _controller;

    public MainWindowForm(MainWindowController controller)
    {
        _controller = controller;
        InitializeComponent();
        dataGridViewFileList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        labelInfo.Visible = false;

        dateTimePickerDateFrom.Value = DateTime.Now.AddDays(-1);
        dateTimePickerDateTo.Value = DateTime.Now;

        dateTimePickerTimeFrom.Value = DateTime.Today.AddHours(8);
        dateTimePickerTimeTo.Value = DateTime.Today.AddHours(21);
    }

    #region EventHandlers

    private void btnGetFiles_Click(object sender, EventArgs e)
    {
        GetFilesFromGivenPath();
    }

    private void btnSetFilePath_Click(object sender, EventArgs e)
    {
        using var folderBrowserDialog = new FolderBrowserDialog();
        var result = folderBrowserDialog.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
        {
            tBFolderPath.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private void btnRemoveFiles_Click(object sender, EventArgs e)
    {
        var result = _controller.RemoveFiles();

        labelInfo.Text = Resources.fileremoval_information_processing;

        MessageBox.Show(result.Message, Resources.messagebox_title_warning, MessageBoxButtons.OK);
        
        labelInfo.Visible = false;
        dataGridViewFileList.DataSource = null;

    }

    private void btnAddDayFrom_Click(object sender, EventArgs e)
    {
        dateTimePickerDateFrom.Value = dateTimePickerDateFrom.Value.AddDays(1);
    }

    private void btnSubtrackDayFrom_Click(object sender, EventArgs e)
    {
        dateTimePickerDateFrom.Value = dateTimePickerDateFrom.Value.AddDays(-1);
    }

    private void btnAddDayTo_Click(object sender, EventArgs e)
    {
        dateTimePickerDateTo.Value = dateTimePickerDateTo.Value.AddDays(1);
    }

    private void btnSubtrackDayTo_Click(object sender, EventArgs e)
    {
        dateTimePickerDateTo.Value = dateTimePickerDateTo.Value.AddDays(-1);
    }

    private void btnAddHourFrom_Click(object sender, EventArgs e)
    {
        dateTimePickerTimeFrom.Value = dateTimePickerTimeFrom.Value.AddHours(1);
    }

    private void btnSubtrackHourFrom_Click(object sender, EventArgs e)
    {
        dateTimePickerTimeFrom.Value = dateTimePickerTimeFrom.Value.AddHours(-1);
    }

    private void btnAddHourTo_Click(object sender, EventArgs e)
    {
        dateTimePickerTimeTo.Value = dateTimePickerTimeTo.Value.AddHours(1);
    }

    private void btnSubtrackHourTo_Click(object sender, EventArgs e)
    {
        dateTimePickerTimeTo.Value = dateTimePickerTimeTo.Value.AddHours(-1);
    }

    #endregion

    #region Functions

    private bool ValidateSelectedTime()
    {
        var startDate = dateTimePickerDateFrom.Value;
        var endDate = dateTimePickerDateTo.Value;

        var startTime = dateTimePickerTimeFrom.Value;
        var endTime = dateTimePickerTimeTo.Value;

        if (startDate > endDate)
        {
            MessageBox.Show(Resources.messagebox_content_startdate_error, Resources.messagebox_title_warning, MessageBoxButtons.OK);
            return false;
        }

        if (startTime > endTime)
        {
            MessageBox.Show(Resources.messagebox_content_starttime_error, Resources.messagebox_title_warning, MessageBoxButtons.OK);
            return false;
        }

        return true;
    }

    private void GetFilesFromGivenPath()
    {
        var filePath = tBFolderPath.Text;

        if (string.IsNullOrWhiteSpace(filePath))
        {
            MessageBox.Show(Resources.messagebox_content_filepath_error, Resources.messagebox_title_warning, MessageBoxButtons.OK);
            return;
        }

        var directoryDetails = new DirectoryDetails(filePath, dateTimePickerDateFrom.Value,
            dateTimePickerDateTo.Value, dateTimePickerTimeFrom.Value, dateTimePickerTimeTo.Value,
            tBFileExtension.Text);

        var startDate = dateTimePickerDateFrom.Value;
        var endDate = dateTimePickerDateTo.Value;

        var startTime = dateTimePickerTimeFrom.Value;
        var endTime = dateTimePickerTimeTo.Value;

        var fileExtensionToSearch = tBFileExtension.Text;

        if (!ValidateSelectedTime()) return;

        try
        { //TODO: Searching with sub folders is not giving results, not searching current directory
            var directory = Directory.GetDirectories(filePath);
                
                
            var fileList = directory.Length == 0 ?
                GetFilesInGivenDirectory(filePath, startDate, endDate, startTime, endTime, fileExtensionToSearch) :
                GetFilesInSubFolders(directory, startDate, endDate, startTime, endTime, fileExtensionToSearch);

            if (!fileList.Any())
            {
                MessageBox.Show(Resources.messagebox_content_files_error, Resources.messagebox_title_warning, MessageBoxButtons.OK);
                return;
            }

            _filesDetailsList = fileList.OrderBy(e => e.FileModificationDate).ToList();
            labelInfo.Text = string.Format(Resources.label_info_foundedfiles, _filesDetailsList.Count);
            labelInfo.Visible = true;
            GenerateDataGridView();
        }
        catch (Exception ex)
        {
            MessageBox.Show(Resources.messagebox_content_files_notfound, Resources.messagebox_title_warning, MessageBoxButtons.OK);
            return;
        }

    }

    private List<FileDetails> GetFilesInGivenDirectory(string filePath, DateTime startDate, DateTime endDate, DateTime startTime, DateTime endTime, string fileExtensionToSearch)
    {
        var fileList = new List<FileDetails>();
        var files = Directory.GetFiles(filePath);

        if (files.Length == 0)
        {
            return new List<FileDetails>();
        }

        foreach (var file in files)
        {
            if (!string.IsNullOrEmpty(fileExtensionToSearch))
            {
                var extension = Path.GetExtension(file);
                if (!string.Equals(fileExtensionToSearch, extension, StringComparison.CurrentCultureIgnoreCase))
                {
                    continue;
                }
            }

            var modificationTime = File.GetLastWriteTime(file);
            if (startDate.Date > modificationTime.Date || modificationTime.Date > endDate.Date) continue;
            if (startTime.TimeOfDay > modificationTime.TimeOfDay || modificationTime.TimeOfDay > endTime.TimeOfDay) continue;

            var fileDetails = new FileDetails
            {
                IsDeletable = true,
                FilePath = file,
                FileName = Path.GetFileName(file),
                FileModificationDate = modificationTime,
            };

            fileList.Add(fileDetails);
        }

        return fileList;
    }

    private List<FileDetails> SearchForFilesInGivenLocation(DirectoryDetails directoryDetails)
    {
        var result = new List<FileDetails>();
        var files = Directory.GetFiles(directoryDetails.SelectedPath);
        return result;
    }

    private List<FileDetails> GetFilesInSubFolders(string[] directories, DateTime startDate, DateTime endDate,
        DateTime startTime, DateTime endTime, string fileExtensionToSearch)
    {
        var fileList = new List<FileDetails>();

        foreach (var dir in directories)
        {
            try
            {
                var subDirectories = Directory.GetDirectories(dir);

                if (subDirectories.Any())
                {
                    fileList.AddRange(GetFilesInSubFolders(subDirectories, startDate, endDate, startTime, endTime, fileExtensionToSearch));
                }

                var files = Directory.GetFiles(dir);
                foreach (var file in files)
                {
                    if (!string.IsNullOrEmpty(fileExtensionToSearch))
                    {
                        var extension = Path.GetExtension(file);
                        if (!string.Equals(fileExtensionToSearch, extension, StringComparison.CurrentCultureIgnoreCase))
                        {
                            continue;
                        }
                    }

                    var modificationTime = File.GetLastWriteTime(file);
                    if (startDate.Date > modificationTime.Date || modificationTime.Date > endDate.Date) continue;
                    if (startTime.TimeOfDay > modificationTime.TimeOfDay || modificationTime.TimeOfDay > endTime.TimeOfDay) continue;

                    var fileDetails = new FileDetails
                    {
                        IsDeletable = true,
                        FilePath = file,
                        FileName = Path.GetFileName(file),
                        FileModificationDate = modificationTime,
                    };

                    fileList.Add(fileDetails);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error while reading files", e);
            }
        }

        return fileList;
    }

    private void GenerateDataGridView()
    {
        dataGridViewFileList.Columns.Clear();
        dataGridViewFileList.AutoGenerateColumns = false;
        dataGridViewFileList.Columns.AddRange(
            new DataGridViewCheckBoxColumn()
            {
                DataPropertyName = nameof(FileDetails.IsDeletable),
                HeaderText = "Plik zostanie usuniety",
                SortMode = DataGridViewColumnSortMode.Programmatic,
            },
            new DataGridViewTextBoxColumn()
            {
                DataPropertyName = nameof(FileDetails.FileName),
                HeaderText = "Nazwa pliku",
                SortMode = DataGridViewColumnSortMode.Programmatic,
            },
            new DataGridViewTextBoxColumn()
            {
                DataPropertyName = nameof(FileDetails.FileModificationDate),
                HeaderText = "Data modyfikacji",
                SortMode = DataGridViewColumnSortMode.Programmatic,
            },
            new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(FileDetails.FilePath),
                HeaderText = "œcie¿ka do pliku",
                SortMode = DataGridViewColumnSortMode.Programmatic
            });
        var source = new SortedBindingList<FileDetails>(_filesDetailsList);
        dataGridViewFileList.DataSource = source;
    }
    #endregion

    private void dataGridViewFileList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        var newColumn = dataGridViewFileList.Columns[e.ColumnIndex];
        var oldColumn = dataGridViewFileList.SortedColumn;
        ListSortDirection direction;

        if (oldColumn == newColumn)
        {
            // Sorting by the same column: toggle between ASC and DESC:
            direction = dataGridViewFileList.SortOrder == SortOrder.Ascending
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;
        }
        else
        {
            // Sorting by a new column.

            // Choose the default direction based on the column name:
            direction = ListSortDirection.Ascending;

            // Remove the sorting glyph from the old column, if any:
            if (oldColumn != null)
            {
                oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
        }

        var source = new SortedBindingList<FileDetails>(_filesDetailsList);
        source.ApplySort(newColumn.DataPropertyName, direction);
        dataGridViewFileList.DataSource = source;

        //newColumn.HeaderCell.SortGlyphDirection = direction == ListSortDirection.Ascending
        //	? SortOrder.Ascending
        //	: SortOrder.Descending;
    }

    private void dataGridViewFileList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        var current = ((SortedBindingList<FileDetails>)dataGridViewFileList.DataSource)[e.RowIndex];
        var isDeletable = current.IsDeletable;
        var fileModificationDate = current.FileModificationDate;
        var fileName = current.FileName;
        var filePath = current.FilePath;
        //var cellValue = (bool)e.Value;
        if (e.ColumnIndex == 0)
        {
            ((SortedBindingList<FileDetails>)dataGridViewFileList.DataSource)[e.RowIndex] = new FileDetails
            {
                IsDeletable = !isDeletable,
                FileName = fileName,
                FileModificationDate = fileModificationDate,
                FilePath = filePath
            };
        }
    }
}