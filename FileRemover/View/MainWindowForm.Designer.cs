namespace FileRemover
{
	partial class MainWindowForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowForm));
            btnGetFiles = new Button();
            btnRemoveFiles = new Button();
            dataGridViewFileList = new DataGridView();
            folderBrowserDialog1 = new FolderBrowserDialog();
            tBFolderPath = new TextBox();
            btnSetFilePath = new Button();
            panel1 = new Panel();
            label4 = new Label();
            labelInfo = new Label();
            panel2 = new Panel();
            panel6 = new Panel();
            pictureBox1 = new PictureBox();
            labelVersion = new Label();
            panel5 = new Panel();
            tBFileExtension = new TextBox();
            label10 = new Label();
            label11 = new Label();
            btnSubtrackHourTo = new Button();
            btnAddHourTo = new Button();
            btnSubtrackHourFrom = new Button();
            btnAddHourFrom = new Button();
            btnSubtrackDayTo = new Button();
            btnAddDayTo = new Button();
            btnSubtrackDayFrom = new Button();
            btnAddDayFrom = new Button();
            label7 = new Label();
            label8 = new Label();
            label6 = new Label();
            label5 = new Label();
            dateTimePickerTimeTo = new DateTimePicker();
            dateTimePickerTimeFrom = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dateTimePickerDateTo = new DateTimePicker();
            dateTimePickerDateFrom = new DateTimePicker();
            panel4 = new Panel();
            panel3 = new Panel();
            imageList1 = new ImageList(components);
            BackgroundWorkerGetFiles = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFileList).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnGetFiles
            // 
            btnGetFiles.Anchor = AnchorStyles.Top;
            btnGetFiles.Location = new Point(435, 11);
            btnGetFiles.Name = "btnGetFiles";
            btnGetFiles.Size = new Size(174, 27);
            btnGetFiles.TabIndex = 0;
            btnGetFiles.Text = "Znajdź pliki do usunięcia";
            btnGetFiles.UseVisualStyleBackColor = true;
            btnGetFiles.Click += BtnGetFiles_Click;
            // 
            // btnRemoveFiles
            // 
            btnRemoveFiles.Anchor = AnchorStyles.Top;
            btnRemoveFiles.Location = new Point(624, 11);
            btnRemoveFiles.Name = "btnRemoveFiles";
            btnRemoveFiles.Size = new Size(174, 27);
            btnRemoveFiles.TabIndex = 1;
            btnRemoveFiles.Text = "Usuń pliki";
            btnRemoveFiles.UseVisualStyleBackColor = true;
            btnRemoveFiles.Click += BtnRemoveFiles_Click;
            // 
            // dataGridViewFileList
            // 
            dataGridViewFileList.AllowUserToAddRows = false;
            dataGridViewFileList.AllowUserToDeleteRows = false;
            dataGridViewFileList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFileList.Dock = DockStyle.Bottom;
            dataGridViewFileList.Location = new Point(0, 44);
            dataGridViewFileList.Name = "dataGridViewFileList";
            dataGridViewFileList.Size = new Size(1234, 263);
            dataGridViewFileList.TabIndex = 7;
            dataGridViewFileList.CellMouseClick += dataGridViewFileList_CellMouseClick;
            dataGridViewFileList.ColumnHeaderMouseClick += dataGridViewFileList_ColumnHeaderMouseClick;
            // 
            // tBFolderPath
            // 
            tBFolderPath.Anchor = AnchorStyles.Top;
            tBFolderPath.Location = new Point(0, 0);
            tBFolderPath.Name = "tBFolderPath";
            tBFolderPath.Size = new Size(327, 23);
            tBFolderPath.TabIndex = 8;
            // 
            // btnSetFilePath
            // 
            btnSetFilePath.Anchor = AnchorStyles.Top;
            btnSetFilePath.Location = new Point(322, 0);
            btnSetFilePath.Name = "btnSetFilePath";
            btnSetFilePath.Size = new Size(75, 21);
            btnSetFilePath.TabIndex = 9;
            btnSetFilePath.Text = "Lokalizacja";
            btnSetFilePath.UseVisualStyleBackColor = true;
            btnSetFilePath.Click += BtnSetFilePath_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.Controls.Add(tBFolderPath);
            panel1.Controls.Add(btnSetFilePath);
            panel1.Location = new Point(418, 144);
            panel1.Name = "panel1";
            panel1.Size = new Size(397, 21);
            panel1.TabIndex = 10;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(534, 108);
            label4.Name = "label4";
            label4.Size = new Size(180, 21);
            label4.TabIndex = 11;
            label4.Text = "Wskaż lokalizację plików";
            // 
            // labelInfo
            // 
            labelInfo.Dock = DockStyle.Bottom;
            labelInfo.Font = new Font("Segoe UI", 12F);
            labelInfo.Location = new Point(0, 0);
            labelInfo.Name = "labelInfo";
            labelInfo.Padding = new Padding(15, 0, 0, 15);
            labelInfo.Size = new Size(1234, 44);
            labelInfo.TabIndex = 12;
            labelInfo.Text = "LabelInfo";
            labelInfo.TextAlign = ContentAlignment.MiddleLeft;
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
            panel2.Size = new Size(1234, 769);
            panel2.TabIndex = 13;
            // 
            // panel6
            // 
            panel6.Controls.Add(pictureBox1);
            panel6.Controls.Add(labelVersion);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(panel1);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1234, 173);
            panel6.TabIndex = 16;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(520, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(203, 66);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // labelVersion
            // 
            labelVersion.AutoSize = true;
            labelVersion.Location = new Point(0, 0);
            labelVersion.Name = "labelVersion";
            labelVersion.Size = new Size(54, 15);
            labelVersion.TabIndex = 18;
            labelVersion.Text = "version 1";
            // 
            // panel5
            // 
            panel5.Controls.Add(tBFileExtension);
            panel5.Controls.Add(label10);
            panel5.Controls.Add(label11);
            panel5.Controls.Add(btnSubtrackHourTo);
            panel5.Controls.Add(btnAddHourTo);
            panel5.Controls.Add(btnSubtrackHourFrom);
            panel5.Controls.Add(btnAddHourFrom);
            panel5.Controls.Add(btnSubtrackDayTo);
            panel5.Controls.Add(btnAddDayTo);
            panel5.Controls.Add(btnSubtrackDayFrom);
            panel5.Controls.Add(btnAddDayFrom);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label5);
            panel5.Controls.Add(dateTimePickerTimeTo);
            panel5.Controls.Add(dateTimePickerTimeFrom);
            panel5.Controls.Add(label1);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(dateTimePickerDateTo);
            panel5.Controls.Add(dateTimePickerDateFrom);
            panel5.Dock = DockStyle.Bottom;
            panel5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            panel5.Location = new Point(0, 173);
            panel5.Name = "panel5";
            panel5.Size = new Size(1234, 240);
            panel5.TabIndex = 15;
            // 
            // tBFileExtension
            // 
            tBFileExtension.Anchor = AnchorStyles.Top;
            tBFileExtension.Location = new Point(445, 190);
            tBFileExtension.Name = "tBFileExtension";
            tBFileExtension.Size = new Size(300, 23);
            tBFileExtension.TabIndex = 21;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.Location = new Point(445, 170);
            label10.Name = "label10";
            label10.Size = new Size(300, 15);
            label10.TabIndex = 20;
            label10.Text = "Szukaj plików z konkretnym rozszerzeniem (np. .txt)";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F);
            label11.Location = new Point(506, 144);
            label11.Name = "label11";
            label11.Size = new Size(194, 21);
            label11.TabIndex = 26;
            label11.Text = "Dodatkowe opcje szukania";
            // 
            // btnSubtrackHourTo
            // 
            btnSubtrackHourTo.Anchor = AnchorStyles.Top;
            btnSubtrackHourTo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSubtrackHourTo.Location = new Point(825, 103);
            btnSubtrackHourTo.Name = "btnSubtrackHourTo";
            btnSubtrackHourTo.Size = new Size(28, 23);
            btnSubtrackHourTo.TabIndex = 25;
            btnSubtrackHourTo.Text = "-";
            btnSubtrackHourTo.UseVisualStyleBackColor = true;
            btnSubtrackHourTo.Click += BtnSubtractHourTo_Click;
            // 
            // btnAddHourTo
            // 
            btnAddHourTo.Anchor = AnchorStyles.Top;
            btnAddHourTo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddHourTo.Location = new Point(792, 103);
            btnAddHourTo.Name = "btnAddHourTo";
            btnAddHourTo.Size = new Size(28, 23);
            btnAddHourTo.TabIndex = 24;
            btnAddHourTo.Text = "+";
            btnAddHourTo.UseVisualStyleBackColor = true;
            btnAddHourTo.Click += BtnAddHourTo_Click;
            // 
            // btnSubtrackHourFrom
            // 
            btnSubtrackHourFrom.Anchor = AnchorStyles.Top;
            btnSubtrackHourFrom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSubtrackHourFrom.Location = new Point(825, 67);
            btnSubtrackHourFrom.Name = "btnSubtrackHourFrom";
            btnSubtrackHourFrom.Size = new Size(28, 23);
            btnSubtrackHourFrom.TabIndex = 23;
            btnSubtrackHourFrom.Text = "-";
            btnSubtrackHourFrom.UseVisualStyleBackColor = true;
            btnSubtrackHourFrom.Click += BtnSubtractHourFrom_Click;
            // 
            // btnAddHourFrom
            // 
            btnAddHourFrom.Anchor = AnchorStyles.Top;
            btnAddHourFrom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddHourFrom.Location = new Point(792, 67);
            btnAddHourFrom.Name = "btnAddHourFrom";
            btnAddHourFrom.Size = new Size(28, 23);
            btnAddHourFrom.TabIndex = 22;
            btnAddHourFrom.Text = "+";
            btnAddHourFrom.UseVisualStyleBackColor = true;
            btnAddHourFrom.Click += BtnAddHourFrom_Click;
            // 
            // btnSubtrackDayTo
            // 
            btnSubtrackDayTo.Anchor = AnchorStyles.Top;
            btnSubtrackDayTo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSubtrackDayTo.Location = new Point(537, 104);
            btnSubtrackDayTo.Name = "btnSubtrackDayTo";
            btnSubtrackDayTo.Size = new Size(28, 23);
            btnSubtrackDayTo.TabIndex = 21;
            btnSubtrackDayTo.Text = "-";
            btnSubtrackDayTo.UseVisualStyleBackColor = true;
            btnSubtrackDayTo.Click += BtnSubtractDayTo_Click;
            // 
            // btnAddDayTo
            // 
            btnAddDayTo.Anchor = AnchorStyles.Top;
            btnAddDayTo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddDayTo.Location = new Point(503, 105);
            btnAddDayTo.Name = "btnAddDayTo";
            btnAddDayTo.Size = new Size(28, 23);
            btnAddDayTo.TabIndex = 20;
            btnAddDayTo.Text = "+";
            btnAddDayTo.UseVisualStyleBackColor = true;
            btnAddDayTo.Click += BtnAddDayTo_Click;
            // 
            // btnSubtrackDayFrom
            // 
            btnSubtrackDayFrom.Anchor = AnchorStyles.Top;
            btnSubtrackDayFrom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSubtrackDayFrom.Location = new Point(537, 70);
            btnSubtrackDayFrom.Name = "btnSubtrackDayFrom";
            btnSubtrackDayFrom.Size = new Size(28, 23);
            btnSubtrackDayFrom.TabIndex = 19;
            btnSubtrackDayFrom.Text = "-";
            btnSubtrackDayFrom.UseVisualStyleBackColor = true;
            btnSubtrackDayFrom.Click += BtnSubtractDayFrom_Click;
            // 
            // btnAddDayFrom
            // 
            btnAddDayFrom.Anchor = AnchorStyles.Top;
            btnAddDayFrom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddDayFrom.Location = new Point(503, 70);
            btnAddDayFrom.Name = "btnAddDayFrom";
            btnAddDayFrom.Size = new Size(28, 23);
            btnAddDayFrom.TabIndex = 18;
            btnAddDayFrom.Text = "+";
            btnAddDayFrom.UseVisualStyleBackColor = true;
            btnAddDayFrom.Click += BtnAddDayFrom_Click;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.Location = new Point(672, 65);
            label7.Name = "label7";
            label7.Size = new Size(28, 21);
            label7.TabIndex = 16;
            label7.Text = "od";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(672, 102);
            label8.Name = "label8";
            label8.Size = new Size(28, 21);
            label8.TabIndex = 17;
            label8.Text = "do";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(671, 39);
            label6.Name = "label6";
            label6.Size = new Size(299, 21);
            label6.TabIndex = 15;
            label6.Text = "Wyszukaj pomiędzy podanymi godzinami";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(341, 38);
            label5.Name = "label5";
            label5.Size = new Size(182, 21);
            label5.TabIndex = 14;
            label5.Text = "Wyszukaj pomiędzy datą";
            // 
            // dateTimePickerTimeTo
            // 
            dateTimePickerTimeTo.Anchor = AnchorStyles.Top;
            dateTimePickerTimeTo.Format = DateTimePickerFormat.Time;
            dateTimePickerTimeTo.Location = new Point(709, 102);
            dateTimePickerTimeTo.Name = "dateTimePickerTimeTo";
            dateTimePickerTimeTo.Size = new Size(72, 23);
            dateTimePickerTimeTo.TabIndex = 13;
            // 
            // dateTimePickerTimeFrom
            // 
            dateTimePickerTimeFrom.Anchor = AnchorStyles.Top;
            dateTimePickerTimeFrom.CustomFormat = "";
            dateTimePickerTimeFrom.Format = DateTimePickerFormat.Time;
            dateTimePickerTimeFrom.Location = new Point(709, 66);
            dateTimePickerTimeFrom.Name = "dateTimePickerTimeFrom";
            dateTimePickerTimeFrom.Size = new Size(72, 23);
            dateTimePickerTimeFrom.TabIndex = 12;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(577, 10);
            label1.Name = "label1";
            label1.Size = new Size(89, 21);
            label1.TabIndex = 9;
            label1.Text = "Znajdź pliki";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(343, 70);
            label2.Name = "label2";
            label2.Size = new Size(28, 21);
            label2.TabIndex = 10;
            label2.Text = "od";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(343, 107);
            label3.Name = "label3";
            label3.Size = new Size(28, 21);
            label3.TabIndex = 11;
            label3.Text = "do";
            // 
            // dateTimePickerDateTo
            // 
            dateTimePickerDateTo.Anchor = AnchorStyles.Top;
            dateTimePickerDateTo.CustomFormat = "dd-MM-yyyy";
            dateTimePickerDateTo.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateTo.Location = new Point(387, 105);
            dateTimePickerDateTo.Name = "dateTimePickerDateTo";
            dateTimePickerDateTo.Size = new Size(110, 23);
            dateTimePickerDateTo.TabIndex = 8;
            dateTimePickerDateTo.Value = new DateTime(2023, 7, 3, 22, 27, 37, 0);
            // 
            // dateTimePickerDateFrom
            // 
            dateTimePickerDateFrom.Anchor = AnchorStyles.Top;
            dateTimePickerDateFrom.CustomFormat = "dd-MM-yyyy";
            dateTimePickerDateFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerDateFrom.Location = new Point(387, 70);
            dateTimePickerDateFrom.Name = "dateTimePickerDateFrom";
            dateTimePickerDateFrom.Size = new Size(110, 23);
            dateTimePickerDateFrom.TabIndex = 7;
            dateTimePickerDateFrom.Value = new DateTime(2024, 4, 23, 0, 0, 0, 0);
            // 
            // panel4
            // 
            panel4.Controls.Add(btnGetFiles);
            panel4.Controls.Add(btnRemoveFiles);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(0, 413);
            panel4.Name = "panel4";
            panel4.Size = new Size(1234, 49);
            panel4.TabIndex = 14;
            // 
            // panel3
            // 
            panel3.Controls.Add(labelInfo);
            panel3.Controls.Add(dataGridViewFileList);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(0, 462);
            panel3.Name = "panel3";
            panel3.Size = new Size(1234, 307);
            panel3.TabIndex = 13;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // BackgroundWorkerGetFiles
            // 
            BackgroundWorkerGetFiles.WorkerReportsProgress = true;
            BackgroundWorkerGetFiles.DoWork += BackgroundWorkerGetFiles_DoWork;
            BackgroundWorkerGetFiles.ProgressChanged += BackgroundWorkerGetFiles_ProgressChanged;
            BackgroundWorkerGetFiles.RunWorkerCompleted += BackgroundWorkerGetFiles_RunWorkerCompleted;
            // 
            // MainWindowForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 769);
            Controls.Add(panel2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainWindowForm";
            Text = "AllCam - FileRemover";
            ((System.ComponentModel.ISupportInitialize)dataGridViewFileList).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnGetFiles;
		private Button btnRemoveFiles;
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
		private Label label7;
		private Label label8;
		private Label label6;
		private Label label5;
		private DateTimePicker dateTimePickerTimeTo;
		private DateTimePicker dateTimePickerTimeFrom;
		private Label label1;
		private Label label2;
		private Label label3;
		private DateTimePicker dateTimePickerDateTo;
		private DateTimePicker dateTimePickerDateFrom;
		private Label labelVersion;
		private PictureBox pictureBox1;
		private ImageList imageList1;
		private Button btnSubtrackHourFrom;
		private Button btnAddHourFrom;
		private Button btnSubtrackDayTo;
		private Button btnAddDayTo;
		private Button btnSubtrackDayFrom;
		private Button btnAddDayFrom;
		private Button btnSubtrackHourTo;
		private Button btnAddHourTo;
        private TextBox tBFileExtension;
        private Label label10;
        private Label label11;
        private System.ComponentModel.BackgroundWorker BackgroundWorkerGetFiles;
    }
}