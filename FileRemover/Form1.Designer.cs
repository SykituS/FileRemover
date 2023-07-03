namespace FileRemover
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnGetFiles = new Button();
			btnRemoveFiles = new Button();
			dateTimePickerFrom = new DateTimePicker();
			dateTimePickerTo = new DateTimePicker();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			dataGridViewFileList = new DataGridView();
			folderBrowserDialog1 = new FolderBrowserDialog();
			tBFolderPath = new TextBox();
			btnSetFilePath = new Button();
			panel1 = new Panel();
			label4 = new Label();
			labelInfo = new Label();
			panel2 = new Panel();
			panel6 = new Panel();
			panel5 = new Panel();
			panel4 = new Panel();
			panel3 = new Panel();
			((System.ComponentModel.ISupportInitialize)dataGridViewFileList).BeginInit();
			panel1.SuspendLayout();
			panel2.SuspendLayout();
			panel6.SuspendLayout();
			panel5.SuspendLayout();
			panel4.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			// 
			// btnGetFiles
			// 
			btnGetFiles.Location = new Point(231, 17);
			btnGetFiles.Name = "btnGetFiles";
			btnGetFiles.Size = new Size(174, 23);
			btnGetFiles.TabIndex = 0;
			btnGetFiles.Text = "Znajdź pliki do usunięcia";
			btnGetFiles.UseVisualStyleBackColor = true;
			btnGetFiles.Click += btnGetFiles_Click;
			// 
			// btnRemoveFiles
			// 
			btnRemoveFiles.Location = new Point(420, 17);
			btnRemoveFiles.Name = "btnRemoveFiles";
			btnRemoveFiles.Size = new Size(174, 23);
			btnRemoveFiles.TabIndex = 1;
			btnRemoveFiles.Text = "Usuń pliki";
			btnRemoveFiles.UseVisualStyleBackColor = true;
			btnRemoveFiles.Click += btnRemoveFiles_Click;
			// 
			// dateTimePickerFrom
			// 
			dateTimePickerFrom.CustomFormat = "dd-MM-yyyy HH:mm:ss";
			dateTimePickerFrom.Format = DateTimePickerFormat.Custom;
			dateTimePickerFrom.Location = new Point(388, 46);
			dateTimePickerFrom.Name = "dateTimePickerFrom";
			dateTimePickerFrom.Size = new Size(142, 23);
			dateTimePickerFrom.TabIndex = 2;
			// 
			// dateTimePickerTo
			// 
			dateTimePickerTo.CustomFormat = "dd-MM-yyyy HH:mm:ss";
			dateTimePickerTo.Format = DateTimePickerFormat.Custom;
			dateTimePickerTo.Location = new Point(388, 83);
			dateTimePickerTo.Name = "dateTimePickerTo";
			dateTimePickerTo.Size = new Size(142, 23);
			dateTimePickerTo.TabIndex = 3;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(366, 15);
			label1.Name = "label1";
			label1.Size = new Size(89, 21);
			label1.TabIndex = 4;
			label1.Text = "Znajdź pliki";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(335, 48);
			label2.Name = "label2";
			label2.Size = new Size(28, 21);
			label2.TabIndex = 5;
			label2.Text = "od";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label3.Location = new Point(335, 85);
			label3.Name = "label3";
			label3.Size = new Size(28, 21);
			label3.TabIndex = 6;
			label3.Text = "do";
			// 
			// dataGridViewFileList
			// 
			dataGridViewFileList.AllowUserToAddRows = false;
			dataGridViewFileList.AllowUserToDeleteRows = false;
			dataGridViewFileList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewFileList.Dock = DockStyle.Bottom;
			dataGridViewFileList.EditMode = DataGridViewEditMode.EditOnF2;
			dataGridViewFileList.Location = new Point(0, 44);
			dataGridViewFileList.Name = "dataGridViewFileList";
			dataGridViewFileList.ReadOnly = true;
			dataGridViewFileList.RowTemplate.Height = 25;
			dataGridViewFileList.Size = new Size(843, 263);
			dataGridViewFileList.TabIndex = 7;
			// 
			// tBFolderPath
			// 
			tBFolderPath.Dock = DockStyle.Left;
			tBFolderPath.Location = new Point(0, 0);
			tBFolderPath.Name = "tBFolderPath";
			tBFolderPath.Size = new Size(327, 23);
			tBFolderPath.TabIndex = 8;
			// 
			// btnSetFilePath
			// 
			btnSetFilePath.Dock = DockStyle.Right;
			btnSetFilePath.Location = new Point(322, 0);
			btnSetFilePath.Name = "btnSetFilePath";
			btnSetFilePath.Size = new Size(75, 21);
			btnSetFilePath.TabIndex = 9;
			btnSetFilePath.Text = "Lokalizacja";
			btnSetFilePath.UseVisualStyleBackColor = true;
			btnSetFilePath.Click += btnSetFilePath_Click;
			// 
			// panel1
			// 
			panel1.Controls.Add(tBFolderPath);
			panel1.Controls.Add(btnSetFilePath);
			panel1.Location = new Point(234, 73);
			panel1.Name = "panel1";
			panel1.Size = new Size(397, 21);
			panel1.TabIndex = 10;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			label4.Location = new Point(350, 37);
			label4.Name = "label4";
			label4.Size = new Size(180, 21);
			label4.TabIndex = 11;
			label4.Text = "Wskaż lokalizację plików";
			// 
			// labelInfo
			// 
			labelInfo.AutoSize = true;
			labelInfo.Dock = DockStyle.Bottom;
			labelInfo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			labelInfo.Location = new Point(0, 8);
			labelInfo.Name = "labelInfo";
			labelInfo.Padding = new Padding(15, 0, 0, 15);
			labelInfo.Size = new Size(89, 36);
			labelInfo.TabIndex = 12;
			labelInfo.Text = "LabelInfo";
			labelInfo.TextAlign = ContentAlignment.MiddleCenter;
			labelInfo.Visible = false;
			// 
			// panel2
			// 
			panel2.Controls.Add(panel6);
			panel2.Controls.Add(panel5);
			panel2.Controls.Add(panel4);
			panel2.Controls.Add(panel3);
			panel2.Dock = DockStyle.Fill;
			panel2.Location = new Point(0, 0);
			panel2.Name = "panel2";
			panel2.Size = new Size(843, 603);
			panel2.TabIndex = 13;
			// 
			// panel6
			// 
			panel6.Controls.Add(label4);
			panel6.Controls.Add(panel1);
			panel6.Dock = DockStyle.Bottom;
			panel6.Location = new Point(0, 3);
			panel6.Name = "panel6";
			panel6.Size = new Size(843, 124);
			panel6.TabIndex = 16;
			// 
			// panel5
			// 
			panel5.Controls.Add(label1);
			panel5.Controls.Add(label2);
			panel5.Controls.Add(label3);
			panel5.Controls.Add(dateTimePickerTo);
			panel5.Controls.Add(dateTimePickerFrom);
			panel5.Dock = DockStyle.Bottom;
			panel5.Location = new Point(0, 127);
			panel5.Name = "panel5";
			panel5.Size = new Size(843, 120);
			panel5.TabIndex = 15;
			// 
			// panel4
			// 
			panel4.Controls.Add(btnGetFiles);
			panel4.Controls.Add(btnRemoveFiles);
			panel4.Dock = DockStyle.Bottom;
			panel4.Location = new Point(0, 247);
			panel4.Name = "panel4";
			panel4.Size = new Size(843, 49);
			panel4.TabIndex = 14;
			// 
			// panel3
			// 
			panel3.Controls.Add(labelInfo);
			panel3.Controls.Add(dataGridViewFileList);
			panel3.Dock = DockStyle.Bottom;
			panel3.Location = new Point(0, 296);
			panel3.Name = "panel3";
			panel3.Size = new Size(843, 307);
			panel3.TabIndex = 13;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(843, 603);
			Controls.Add(panel2);
			Name = "Form1";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)dataGridViewFileList).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			panel2.ResumeLayout(false);
			panel6.ResumeLayout(false);
			panel6.PerformLayout();
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			panel4.ResumeLayout(false);
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Button btnGetFiles;
		private Button btnRemoveFiles;
		private DateTimePicker dateTimePickerFrom;
		private DateTimePicker dateTimePickerTo;
		private Label label1;
		private Label label2;
		private Label label3;
		private DataGridView dataGridViewFileList;
		private FolderBrowserDialog folderBrowserDialog1;
		private TextBox tBFolderPath;
		private Button btnSetFilePath;
		private Panel panel1;
		private Label label4;
		private Label labelInfo;
		private Panel panel2;
		private Panel panel5;
		private Panel panel4;
		private Panel panel3;
		private Panel panel6;
	}
}