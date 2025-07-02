using Csla;
using FileRemover.Controllers;
using FileRemover.Models;
using FileRemover.Properties;
using System.ComponentModel;
using System.Diagnostics;

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
        labelVersion.Text = string.Format(Resources.label_version, "1.0.1");
        labelInfo.Visible = false;

        dateTimePickerDateFrom.Value = DateTime.Now.AddDays(-1);
        dateTimePickerDateTo.Value = DateTime.Now;

        dateTimePickerTimeFrom.Value = DateTime.Today.AddHours(8);
        dateTimePickerTimeTo.Value = DateTime.Today.AddHours(21);

        labelVersion.Text = $"v{Application.ProductVersion.Split('+')[0]}";
    }

    #region EventHandlers

    private void BtnGetFiles_Click(object sender, EventArgs e)
    {
        labelInfo.Text = "";
        labelInfo.Visible = true;

        this.BackgroundWorkerGetFiles.RunWorkerAsync();
    }

    private void BtnSetFilePath_Click(object sender, EventArgs e)
    {
        using var folderBrowserDialog = new FolderBrowserDialog();
        var result = folderBrowserDialog.ShowDialog();
        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
        {
            tBFolderPath.Text = folderBrowserDialog.SelectedPath;
        }
    }

    private void BtnRemoveFiles_Click(object sender, EventArgs e)
    {
        var result = _controller.RemoveFiles(_filesDetailsList);

        labelInfo.Text = Resources.fileremoval_information_processing;

        MessageBox.Show(result.Message, Resources.messagebox_title_warning, MessageBoxButtons.OK);

        labelInfo.Visible = false;
        dataGridViewFileList.DataSource = null;

    }

    private void BtnAddDayFrom_Click(object sender, EventArgs e)
    {
        dateTimePickerDateFrom.Value = dateTimePickerDateFrom.Value.AddDays(1);
    }

    private void BtnSubtractDayFrom_Click(object sender, EventArgs e)
    {
        dateTimePickerDateFrom.Value = dateTimePickerDateFrom.Value.AddDays(-1);
    }

    private void BtnAddDayTo_Click(object sender, EventArgs e)
    {
        dateTimePickerDateTo.Value = dateTimePickerDateTo.Value.AddDays(1);
    }

    private void BtnSubtractDayTo_Click(object sender, EventArgs e)
    {
        dateTimePickerDateTo.Value = dateTimePickerDateTo.Value.AddDays(-1);
    }

    private void BtnAddHourFrom_Click(object sender, EventArgs e)
    {
        dateTimePickerTimeFrom.Value = dateTimePickerTimeFrom.Value.AddHours(1);
    }

    private void BtnSubtractHourFrom_Click(object sender, EventArgs e)
    {
        dateTimePickerTimeFrom.Value = dateTimePickerTimeFrom.Value.AddHours(-1);
    }

    private void BtnAddHourTo_Click(object sender, EventArgs e)
    {
        dateTimePickerTimeTo.Value = dateTimePickerTimeTo.Value.AddHours(1);
    }

    private void BtnSubtractHourTo_Click(object sender, EventArgs e)
    {
        dateTimePickerTimeTo.Value = dateTimePickerTimeTo.Value.AddHours(-1);
    }

    #endregion

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
            direction = ListSortDirection.Ascending;

            if (oldColumn != null)
            {
                oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
            }
        }

        var source = new SortedBindingList<FileDetails>(_filesDetailsList);
        source.ApplySort(newColumn.DataPropertyName, direction);
        dataGridViewFileList.DataSource = source;
    }

    private void dataGridViewFileList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.RowIndex < 0)
        {
            return;
        }
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

    private void BackgroundWorkerGetFiles_DoWork(object sender, DoWorkEventArgs e)
    {
        var worker = sender as BackgroundWorker;

        e.Result = RetrieveFilesFromLocation();
    }

    private void BackgroundWorkerGetFiles_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        labelInfo.Text = string.Format(Resources.label_info_files_searching, e.UserState);
    }

    private void BackgroundWorkerGetFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        var (files, success) = e.Result as (List<FileDetails> files, bool success)? ?? ([], false);

        if (e.Error is not null)
        {
            MessageBox.Show(Resources.messagebox_content_files_unexpectederror, Resources.messagebox_title_warning, MessageBoxButtons.OK);
            return;
        }

        if (success)
        {
            _filesDetailsList.Clear();
            _filesDetailsList = files.OrderBy(file => file.FileModificationDate).ToList();
            labelInfo.Text = string.Format(Resources.label_info_foundedfiles, _filesDetailsList.Count);
            labelInfo.Visible = true;
            GenerateDataGridView();
        }
        else
        {
            MessageBox.Show(Resources.messagebox_content_files_notfound, Resources.messagebox_title_warning, MessageBoxButtons.OK);
        }
    }

    private (List<FileDetails> files, bool success) RetrieveFilesFromLocation()
    {
        var filePath = tBFolderPath.Text;
        if (string.IsNullOrWhiteSpace(filePath))
        {
            MessageBox.Show(Resources.messagebox_content_filepath_error, Resources.messagebox_title_warning, MessageBoxButtons.OK);
            return ([], false);
        }

        if (!ValidateSelectedTime())
        {
            return ([], false);
        }

        var directoryDetails = new DirectoryDetails(filePath, dateTimePickerDateFrom.Value,
            dateTimePickerDateTo.Value, dateTimePickerTimeFrom.Value, dateTimePickerTimeTo.Value,
            tBFileExtension.Text);

        directoryDetails.DateExceptions = new List<SpecificDateTimeRange>();

        foreach (Panel panel in flowLayoutPanelDateExceptions.Controls)
        {
            var datePicker = panel.Controls[0] as DateTimePicker;
            var startPicker = panel.Controls[1] as DateTimePicker;
            var endPicker = panel.Controls[2] as DateTimePicker;

            if (datePicker != null && startPicker != null && endPicker != null)
            {
                directoryDetails.DateExceptions.Add(new SpecificDateTimeRange
                {
                    Date = datePicker.Value.Date,
                    StartTime = startPicker.Value.TimeOfDay,
                    EndTime = endPicker.Value.TimeOfDay
                });
            }
        }

        return _controller.GetFilesInGivenDirectory(directoryDetails, BackgroundWorkerGetFiles);


    }

    private void btnAddException_Click(object sender, EventArgs e)
    {
        AddExceptionRow();
    }

    private void AddExceptionRow()
    {
        var panel = new Panel
        {
            Width = flowLayoutPanelDateExceptions.Width,
            Height = 30,
            AutoSize = true
        };

        var datePicker = new DateTimePicker
        {
            Format = DateTimePickerFormat.Short,
            Width = 100
        };

        var startTimePicker = new DateTimePicker
        {
            Format = DateTimePickerFormat.Time,
            ShowUpDown = true,
            Width = 80
        };

        var endTimePicker = new DateTimePicker
        {
            Format = DateTimePickerFormat.Time,
            ShowUpDown = true,
            Width = 80
        };

        var removeButton = new Button
        {
            Text = "X",
            Width = 30,
            Height = 25
        };

        removeButton.Click += (s, e) => flowLayoutPanelDateExceptions.Controls.Remove(panel);

        panel.Controls.Add(datePicker);
        panel.Controls.Add(startTimePicker);
        panel.Controls.Add(endTimePicker);
        panel.Controls.Add(removeButton);

        // Optional: layout adjustments
        startTimePicker.Left = datePicker.Right + 10;
        endTimePicker.Left = startTimePicker.Right + 10;
        removeButton.Left = endTimePicker.Right + 10;

        flowLayoutPanelDateExceptions.Controls.Add(panel);
    }
}