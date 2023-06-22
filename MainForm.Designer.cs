namespace VulcanShotSuccess
{
    partial class MainForm
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
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            titleLabel = new Label();
            setupLabel = new Label();
            LocationToSaveLabel = new Label();
            LocationToSaveTextField = new TextBox();
            openFolderButton = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            nameOfStatsFileLabel = new Label();
            nameOfStatsFileTextField = new TextBox();
            targetAreaLabel = new Label();
            areaDropDown = new ComboBox();
            searchingFilesLabel = new Label();
            searchingFilesTextField = new TextBox();
            runButton = new Button();
            informationLabel = new Label();
            exitButton = new Button();
            resultsTextField = new RichTextBox();
            getFileButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            spinningWheel = new PictureBox();
            StatisticsTextBox = new RichTextBox();
            RunButtonBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            progressBar1 = new ProgressBar();
            ClearConsoleButton = new Button();
            StartOverButton = new Button();
            InformationButton = new Button();
            ProgressLabel = new Label();
            removeFile = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)spinningWheel).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Times New Roman", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.Location = new System.Drawing.Point(152, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new System.Drawing.Size(317, 31);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Vulcan Statisics Retriever";
            // 
            // setupLabel
            // 
            setupLabel.AutoSize = true;
            setupLabel.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            setupLabel.Location = new System.Drawing.Point(51, 55);
            setupLabel.Name = "setupLabel";
            setupLabel.Size = new System.Drawing.Size(48, 14);
            setupLabel.TabIndex = 1;
            setupLabel.Text = "SETUP";
            // 
            // LocationToSaveLabel
            // 
            LocationToSaveLabel.AutoSize = true;
            LocationToSaveLabel.Location = new System.Drawing.Point(51, 79);
            LocationToSaveLabel.Name = "LocationToSaveLabel";
            LocationToSaveLabel.Size = new System.Drawing.Size(96, 15);
            LocationToSaveLabel.TabIndex = 2;
            LocationToSaveLabel.Text = "Location to save:";
            // 
            // LocationToSaveTextField
            // 
            LocationToSaveTextField.BackColor = SystemColors.Window;
            LocationToSaveTextField.Location = new System.Drawing.Point(184, 76);
            LocationToSaveTextField.Name = "LocationToSaveTextField";
            LocationToSaveTextField.PlaceholderText = "Enter Path...";
            LocationToSaveTextField.ReadOnly = true;
            LocationToSaveTextField.ScrollBars = ScrollBars.Horizontal;
            LocationToSaveTextField.Size = new System.Drawing.Size(357, 23);
            LocationToSaveTextField.TabIndex = 3;
            LocationToSaveTextField.TextChanged += LocationToSaveTextField_TextChanged;
            // 
            // openFolderButton
            // 
            openFolderButton.AccessibleDescription = "Choose a location to save search results";
            openFolderButton.BackColor = SystemColors.Control;
            openFolderButton.FlatStyle = FlatStyle.Flat;
            openFolderButton.Image = (System.Drawing.Image)resources.GetObject("openFolderButton.Image");
            openFolderButton.Location = new System.Drawing.Point(547, 76);
            openFolderButton.Name = "openFolderButton";
            openFolderButton.Size = new System.Drawing.Size(37, 23);
            openFolderButton.TabIndex = 4;
            openFolderButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            openFolderButton.UseVisualStyleBackColor = false;
            openFolderButton.Click += button1_Click;
            // 
            // nameOfStatsFileLabel
            // 
            nameOfStatsFileLabel.AutoSize = true;
            nameOfStatsFileLabel.Location = new System.Drawing.Point(51, 110);
            nameOfStatsFileLabel.Name = "nameOfStatsFileLabel";
            nameOfStatsFileLabel.Size = new System.Drawing.Size(123, 15);
            nameOfStatsFileLabel.TabIndex = 5;
            nameOfStatsFileLabel.Text = "Name of statistics file:";
            // 
            // nameOfStatsFileTextField
            // 
            nameOfStatsFileTextField.Location = new System.Drawing.Point(184, 107);
            nameOfStatsFileTextField.Name = "nameOfStatsFileTextField";
            nameOfStatsFileTextField.PlaceholderText = "Enter File Name...";
            nameOfStatsFileTextField.ScrollBars = ScrollBars.Horizontal;
            nameOfStatsFileTextField.Size = new System.Drawing.Size(357, 23);
            nameOfStatsFileTextField.TabIndex = 6;
            // 
            // targetAreaLabel
            // 
            targetAreaLabel.AutoSize = true;
            targetAreaLabel.Location = new System.Drawing.Point(51, 142);
            targetAreaLabel.Name = "targetAreaLabel";
            targetAreaLabel.Size = new System.Drawing.Size(109, 15);
            targetAreaLabel.TabIndex = 7;
            targetAreaLabel.Text = "Choose target area:";
            // 
            // areaDropDown
            // 
            areaDropDown.DisplayMember = "uhui";
            areaDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            areaDropDown.FormattingEnabled = true;
            areaDropDown.Items.AddRange(new object[] { "TAP", "TAW" });
            areaDropDown.Location = new System.Drawing.Point(184, 139);
            areaDropDown.Name = "areaDropDown";
            areaDropDown.Size = new System.Drawing.Size(98, 23);
            areaDropDown.TabIndex = 8;
            // 
            // searchingFilesLabel
            // 
            searchingFilesLabel.AutoSize = true;
            searchingFilesLabel.Location = new System.Drawing.Point(54, 171);
            searchingFilesLabel.Name = "searchingFilesLabel";
            searchingFilesLabel.Size = new System.Drawing.Size(86, 15);
            searchingFilesLabel.TabIndex = 11;
            searchingFilesLabel.Text = "Searching files:";
            // 
            // searchingFilesTextField
            // 
            searchingFilesTextField.BackColor = SystemColors.Window;
            searchingFilesTextField.ForeColor = SystemColors.WindowText;
            searchingFilesTextField.Location = new System.Drawing.Point(184, 168);
            searchingFilesTextField.Multiline = true;
            searchingFilesTextField.Name = "searchingFilesTextField";
            searchingFilesTextField.PlaceholderText = "(No files)";
            searchingFilesTextField.ReadOnly = true;
            searchingFilesTextField.ScrollBars = ScrollBars.Vertical;
            searchingFilesTextField.Size = new System.Drawing.Size(357, 87);
            searchingFilesTextField.TabIndex = 12;
            searchingFilesTextField.TextChanged += searchingFilesTextField_TextChanged;
            // 
            // runButton
            // 
            runButton.BackColor = System.Drawing.Color.LightGreen;
            runButton.FlatStyle = FlatStyle.Flat;
            runButton.Location = new System.Drawing.Point(240, 283);
            runButton.Name = "runButton";
            runButton.Size = new System.Drawing.Size(122, 31);
            runButton.TabIndex = 13;
            runButton.Text = "Go";
            runButton.UseVisualStyleBackColor = false;
            runButton.Click += runButton_Click;
            // 
            // informationLabel
            // 
            informationLabel.AutoSize = true;
            informationLabel.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point);
            informationLabel.Location = new System.Drawing.Point(54, 349);
            informationLabel.Name = "informationLabel";
            informationLabel.Size = new System.Drawing.Size(96, 14);
            informationLabel.TabIndex = 15;
            informationLabel.Text = "INFORMATION";
            // 
            // exitButton
            // 
            exitButton.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Location = new System.Drawing.Point(509, 669);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(75, 23);
            exitButton.TabIndex = 16;
            exitButton.Text = "Exit";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // resultsTextField
            // 
            resultsTextField.BackColor = SystemColors.Window;
            resultsTextField.BorderStyle = BorderStyle.FixedSingle;
            resultsTextField.Location = new System.Drawing.Point(54, 378);
            resultsTextField.Name = "resultsTextField";
            resultsTextField.ReadOnly = true;
            resultsTextField.ScrollBars = RichTextBoxScrollBars.Vertical;
            resultsTextField.Size = new System.Drawing.Size(487, 251);
            resultsTextField.TabIndex = 17;
            resultsTextField.Text = "";
            // 
            // getFileButton
            // 
            getFileButton.Image = (System.Drawing.Image)resources.GetObject("getFileButton.Image");
            getFileButton.Location = new System.Drawing.Point(547, 167);
            getFileButton.Name = "getFileButton";
            getFileButton.Size = new System.Drawing.Size(37, 23);
            getFileButton.TabIndex = 21;
            getFileButton.UseVisualStyleBackColor = true;
            getFileButton.Click += getFileButton_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.DefaultExt = "xlsm";
            // 
            // spinningWheel
            // 
            spinningWheel.Image = (System.Drawing.Image)resources.GetObject("spinningWheel.Image");
            spinningWheel.Location = new System.Drawing.Point(259, 484);
            spinningWheel.Name = "spinningWheel";
            spinningWheel.Size = new System.Drawing.Size(54, 43);
            spinningWheel.SizeMode = PictureBoxSizeMode.StretchImage;
            spinningWheel.TabIndex = 22;
            spinningWheel.TabStop = false;
            spinningWheel.Visible = false;
            // 
            // StatisticsTextBox
            // 
            StatisticsTextBox.BackColor = SystemColors.Window;
            StatisticsTextBox.Location = new System.Drawing.Point(601, 9);
            StatisticsTextBox.Name = "StatisticsTextBox";
            StatisticsTextBox.ReadOnly = true;
            StatisticsTextBox.Size = new System.Drawing.Size(608, 683);
            StatisticsTextBox.TabIndex = 23;
            StatisticsTextBox.Text = "";
            // 
            // progressBar1
            // 
            progressBar1.BackColor = SystemColors.ActiveCaption;
            progressBar1.Location = new System.Drawing.Point(115, 635);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(426, 23);
            progressBar1.TabIndex = 24;
            // 
            // ClearConsoleButton
            // 
            ClearConsoleButton.BackColor = SystemColors.AppWorkspace;
            ClearConsoleButton.FlatStyle = FlatStyle.Flat;
            ClearConsoleButton.Location = new System.Drawing.Point(51, 669);
            ClearConsoleButton.Name = "ClearConsoleButton";
            ClearConsoleButton.Size = new System.Drawing.Size(99, 23);
            ClearConsoleButton.TabIndex = 26;
            ClearConsoleButton.Text = "Clear Console";
            ClearConsoleButton.UseVisualStyleBackColor = false;
            ClearConsoleButton.Click += ClearConsoleButton_Click;
            // 
            // StartOverButton
            // 
            StartOverButton.BackColor = SystemColors.AppWorkspace;
            StartOverButton.FlatStyle = FlatStyle.Flat;
            StartOverButton.Location = new System.Drawing.Point(152, 669);
            StartOverButton.Name = "StartOverButton";
            StartOverButton.Size = new System.Drawing.Size(99, 23);
            StartOverButton.TabIndex = 27;
            StartOverButton.Text = "Start Over";
            StartOverButton.UseVisualStyleBackColor = false;
            StartOverButton.Click += StartOverButton_Click;
            // 
            // InformationButton
            // 
            InformationButton.BackColor = System.Drawing.Color.DarkGray;
            InformationButton.BackgroundImageLayout = ImageLayout.Zoom;
            InformationButton.FlatStyle = FlatStyle.Flat;
            InformationButton.Image = (System.Drawing.Image)resources.GetObject("InformationButton.Image");
            InformationButton.ImageAlign = ContentAlignment.BottomLeft;
            InformationButton.Location = new System.Drawing.Point(257, 669);
            InformationButton.Name = "InformationButton";
            InformationButton.Size = new System.Drawing.Size(99, 23);
            InformationButton.TabIndex = 28;
            InformationButton.Text = "Information";
            InformationButton.UseVisualStyleBackColor = false;
            InformationButton.Click += InformationButton_Click;
            // 
            // ProgressLabel
            // 
            ProgressLabel.AutoSize = true;
            ProgressLabel.Location = new System.Drawing.Point(54, 640);
            ProgressLabel.Name = "ProgressLabel";
            ProgressLabel.Size = new System.Drawing.Size(55, 15);
            ProgressLabel.TabIndex = 29;
            ProgressLabel.Text = "Progress:";
            // 
            // removeFile
            // 
            removeFile.Image = (System.Drawing.Image)resources.GetObject("removeFile.Image");
            removeFile.Location = new System.Drawing.Point(547, 196);
            removeFile.Name = "removeFile";
            removeFile.Size = new System.Drawing.Size(37, 23);
            removeFile.TabIndex = 30;
            removeFile.UseVisualStyleBackColor = true;
            removeFile.Click += removeFile_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(414, 282);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 31;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new System.Drawing.Size(1226, 704);
            Controls.Add(button1);
            Controls.Add(removeFile);
            Controls.Add(ProgressLabel);
            Controls.Add(InformationButton);
            Controls.Add(StartOverButton);
            Controls.Add(ClearConsoleButton);
            Controls.Add(progressBar1);
            Controls.Add(StatisticsTextBox);
            Controls.Add(spinningWheel);
            Controls.Add(getFileButton);
            Controls.Add(resultsTextField);
            Controls.Add(exitButton);
            Controls.Add(informationLabel);
            Controls.Add(runButton);
            Controls.Add(searchingFilesTextField);
            Controls.Add(searchingFilesLabel);
            Controls.Add(areaDropDown);
            Controls.Add(targetAreaLabel);
            Controls.Add(nameOfStatsFileTextField);
            Controls.Add(nameOfStatsFileLabel);
            Controls.Add(openFolderButton);
            Controls.Add(LocationToSaveTextField);
            Controls.Add(LocationToSaveLabel);
            Controls.Add(setupLabel);
            Controls.Add(titleLabel);
            Name = "MainForm";
            Text = " Vulcan Statistics Programme";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)spinningWheel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label setupLabel;
        private Label LocationToSaveLabel;
        private TextBox LocationToSaveTextField;
        private Button openFolderButton;
        private FolderBrowserDialog folderBrowserDialog1;
        private Label nameOfStatsFileLabel;
        private TextBox nameOfStatsFileTextField;
        private Label targetAreaLabel;
        private ComboBox areaDropDown;
        private Label fileNameLabel;
        private TextBox individualFileToSearchTextField;
        private Label searchingFilesLabel;
        private TextBox searchingFilesTextField;
        private Button runButton;
        private Label informationLabel;
        private Button exitButton;
        private RichTextBox resultsTextField;
        private Button returnFileButton;
        private Button getFileButton;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private PictureBox spinningWheel;
        private RichTextBox StatisticsTextBox;
        private System.ComponentModel.BackgroundWorker RunButtonBackgroundWorker;
        private ProgressBar progressBar1;
        private DataGridView dataGridView1;
        private Button ClearConsoleButton;
        private Button StartOverButton;
        private Button InformationButton;
        private Label ProgressLabel;
        private Button removeFile;
        private Button button1;
    }
}