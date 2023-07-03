using System.Diagnostics;

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
		}

		private void btnGetFiles_Click(object sender, EventArgs e)
		{
			_filesDetailsList = new List<FileDetails>();
			var filesPath = tBFolderPath.Text;

			if (string.IsNullOrWhiteSpace(filesPath))
			{
				MessageBox.Show("Ustaw lokalizacjê folderu!", "Uwaga!", MessageBoxButtons.OK);
				return;
			}

			var startDate = dateTimePickerFrom.Value;
			var endDate = dateTimePickerTo.Value;
			var files = Directory.GetFiles(filesPath);

			foreach (var file in files)
			{
				var modificationTime = File.GetLastWriteTime(file);
				if (startDate > modificationTime || modificationTime > endDate) continue;
				var fileDetails = new FileDetails
				{
					FilePath = file,
					FileName = Path.GetFileName(file),
					FileModificationDate = modificationTime.ToString("G"),
				};

				_filesDetailsList.Add(fileDetails);
			}

			labelInfo.Text = $"Znaleziono {_filesDetailsList.Count} plików do usuniêcia";
			labelInfo.Visible = true;
			dataGridViewFileList.DataSource = _filesDetailsList;
		}

		private void btnSetFilePath_Click(object sender, EventArgs e)
		{
			using (var folderBrowserDialog = new FolderBrowserDialog())
			{
				var result = folderBrowserDialog.ShowDialog();
				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
				{
					tBFolderPath.Text = folderBrowserDialog.SelectedPath;
				}
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
	}
}