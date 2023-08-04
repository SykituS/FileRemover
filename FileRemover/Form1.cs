using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Csla;

namespace FileRemover
{
	public partial class Form1 : Form
	{
		List<FileDetails> _filesDetailsList = new();
		public Form1()
		{
			InitializeComponent();
			dataGridViewFileList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			labelInfo.Visible = false;
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
			var numerator = 1;
			var filesCount = _filesDetailsList.Count;
			foreach (var file in _filesDetailsList)
			{
				File.Delete(file.FilePath);
				labelInfo.Text = $"Usuwanie plików: {numerator++} na {filesCount}";
				Debug.WriteLine($"Removed file from location: {file.FilePath} | File name: {file.FileName}");
			}

			MessageBox.Show($"Pomyœlnie usuniêto {filesCount} plików", "Uwaga!", MessageBoxButtons.OK);
			labelInfo.Visible = false;
			dataGridViewFileList.DataSource = null;

		}

		#endregion

		#region Functions

		private void GetFilesFromGivenPath()
		{
			var filePath = tBFolderPath.Text;

			if (string.IsNullOrWhiteSpace(filePath))
			{
				MessageBox.Show("Ustaw lokalizacjê folderu", "Uwaga!", MessageBoxButtons.OK);
				return;
			}

			var startDate = dateTimePickerDateFrom.Value;
			var endDate = dateTimePickerDateTo.Value;

			var startTime = dateTimePickerTimeFrom.Value;
			var endTime = dateTimePickerTimeTo.Value;

			try
			{
				var directory = Directory.GetDirectories(filePath);
				var fileList = directory.Length == 0 ? GetFilesInGivenDirectory(filePath, startDate, endDate, startTime, endTime) : GetFilesInSubFolders(directory, startDate, endDate, startTime, endTime);

				if (!fileList.Any())
				{
					MessageBox.Show("Nie znaleziono plików w podanej lokalizacji", "Uwaga!", MessageBoxButtons.OK);
					return;
				}

				_filesDetailsList = fileList.OrderBy(e => e.FileModificationDate).ToList();
				labelInfo.Text = $"Znaleziono {_filesDetailsList.Count} plików do usuniêcia";
				labelInfo.Visible = true;
				GenerateDataGridView();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Podczas wyszukiwania plików wyst¹pi³ nieoczekiwany problem! Upewnij siê ¿e podana œcie¿ka istnieje", "Uwaga!", MessageBoxButtons.OK);
				return;
			}

		}

		private List<FileDetails> GetFilesInGivenDirectory(string filePath, DateTime startDate, DateTime endDate, DateTime startTime, DateTime endTime)
		{
			var fileList = new List<FileDetails>();
			var files = Directory.GetFiles(filePath);

			if (files.Length == 0)
			{
				return new List<FileDetails>();
			}

			foreach (var file in files)
			{
				var modificationTime = File.GetLastWriteTime(file);
				if (startDate.Date > modificationTime.Date || modificationTime.Date > endDate.Date) continue;
				if (startTime.TimeOfDay > modificationTime.TimeOfDay || modificationTime.TimeOfDay > endTime.TimeOfDay) continue;

				var fileDetails = new FileDetails
				{
					FilePath = file,
					FileName = Path.GetFileName(file),
					FileModificationDate = modificationTime,
				};

				fileList.Add(fileDetails);
			}

			return fileList;
		}

		private List<FileDetails> GetFilesInSubFolders(string[] directories, DateTime startDate, DateTime endDate,
			DateTime startTime, DateTime endTime)
		{
			var fileList = new List<FileDetails>();

			foreach (var dir in directories)
			{
				var files = Directory.GetFiles(dir);

				foreach (var file in files)
				{
					var modificationTime = File.GetLastWriteTime(file);
					if (startDate.Date > modificationTime.Date || modificationTime.Date > endDate.Date) continue;
					if (startTime.TimeOfDay > modificationTime.TimeOfDay || modificationTime.TimeOfDay > endTime.TimeOfDay) continue;

					var fileDetails = new FileDetails
					{
						FilePath = file,
						FileName = Path.GetFileName(file),
						FileModificationDate = modificationTime,
					};

					fileList.Add(fileDetails);
				}
			}

			return fileList;
		}

		private void GenerateDataGridView()
		{
			dataGridViewFileList.Columns.Clear();
			dataGridViewFileList.AutoGenerateColumns = false;
			dataGridViewFileList.Columns.AddRange(
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "FileName",
					HeaderText = "Nazwa pliku",
					SortMode = DataGridViewColumnSortMode.Programmatic,
				},
				new DataGridViewTextBoxColumn()
				{
					DataPropertyName = "FileModificationDate",
					HeaderText = "Data modyfikacji",
					SortMode = DataGridViewColumnSortMode.Programmatic,
				},
				new DataGridViewTextBoxColumn
				{
					DataPropertyName = "FilePath",
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
	}
}