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
            this.titleLabel = new System.Windows.Forms.Label();
            this.setupLabel = new System.Windows.Forms.Label();
            this.LocationToSaveLabel = new System.Windows.Forms.Label();
            this.LocationToSaveTextField = new System.Windows.Forms.TextBox();
            this.openFolderButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.nameOfStatsFileLabel = new System.Windows.Forms.Label();
            this.nameOfStatsFileTextField = new System.Windows.Forms.TextBox();
            this.targetAreaLabel = new System.Windows.Forms.Label();
            this.areaDropDown = new System.Windows.Forms.ComboBox();
            this.searchingFilesLabel = new System.Windows.Forms.Label();
            this.searchingFilesTextField = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.informationLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.resultsTextField = new System.Windows.Forms.RichTextBox();
            this.getFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.spinningWheel = new System.Windows.Forms.PictureBox();
            this.StatisticsTextBox = new System.Windows.Forms.RichTextBox();
            this.RunButtonBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ClearConsoleButton = new System.Windows.Forms.Button();
            this.StartOverButton = new System.Windows.Forms.Button();
            this.InformationButton = new System.Windows.Forms.Button();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.removeFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spinningWheel)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.Location = new System.Drawing.Point(152, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(317, 31);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Vulcan Statisics Retriever";
            // 
            // setupLabel
            // 
            this.setupLabel.AutoSize = true;
            this.setupLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.setupLabel.Location = new System.Drawing.Point(51, 55);
            this.setupLabel.Name = "setupLabel";
            this.setupLabel.Size = new System.Drawing.Size(48, 14);
            this.setupLabel.TabIndex = 1;
            this.setupLabel.Text = "SETUP";
            // 
            // LocationToSaveLabel
            // 
            this.LocationToSaveLabel.AutoSize = true;
            this.LocationToSaveLabel.Location = new System.Drawing.Point(51, 79);
            this.LocationToSaveLabel.Name = "LocationToSaveLabel";
            this.LocationToSaveLabel.Size = new System.Drawing.Size(96, 15);
            this.LocationToSaveLabel.TabIndex = 2;
            this.LocationToSaveLabel.Text = "Location to save:";
            // 
            // LocationToSaveTextField
            // 
            this.LocationToSaveTextField.BackColor = System.Drawing.SystemColors.Window;
            this.LocationToSaveTextField.Location = new System.Drawing.Point(184, 76);
            this.LocationToSaveTextField.Name = "LocationToSaveTextField";
            this.LocationToSaveTextField.PlaceholderText = "Enter Path...";
            this.LocationToSaveTextField.ReadOnly = true;
            this.LocationToSaveTextField.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.LocationToSaveTextField.Size = new System.Drawing.Size(357, 23);
            this.LocationToSaveTextField.TabIndex = 3;
            this.LocationToSaveTextField.TextChanged += new System.EventHandler(this.LocationToSaveTextField_TextChanged);
            // 
            // openFolderButton
            // 
            this.openFolderButton.AccessibleDescription = "Choose a location to save search results";
            this.openFolderButton.BackColor = System.Drawing.SystemColors.Control;
            this.openFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFolderButton.Image = ((System.Drawing.Image)(resources.GetObject("openFolderButton.Image")));
            this.openFolderButton.Location = new System.Drawing.Point(547, 76);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(37, 23);
            this.openFolderButton.TabIndex = 4;
            this.openFolderButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.openFolderButton.UseVisualStyleBackColor = false;
            this.openFolderButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // nameOfStatsFileLabel
            // 
            this.nameOfStatsFileLabel.AutoSize = true;
            this.nameOfStatsFileLabel.Location = new System.Drawing.Point(51, 110);
            this.nameOfStatsFileLabel.Name = "nameOfStatsFileLabel";
            this.nameOfStatsFileLabel.Size = new System.Drawing.Size(123, 15);
            this.nameOfStatsFileLabel.TabIndex = 5;
            this.nameOfStatsFileLabel.Text = "Name of statistics file:";
            // 
            // nameOfStatsFileTextField
            // 
            this.nameOfStatsFileTextField.Location = new System.Drawing.Point(184, 107);
            this.nameOfStatsFileTextField.Name = "nameOfStatsFileTextField";
            this.nameOfStatsFileTextField.PlaceholderText = "Enter File Name...";
            this.nameOfStatsFileTextField.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.nameOfStatsFileTextField.Size = new System.Drawing.Size(357, 23);
            this.nameOfStatsFileTextField.TabIndex = 6;
            // 
            // targetAreaLabel
            // 
            this.targetAreaLabel.AutoSize = true;
            this.targetAreaLabel.Location = new System.Drawing.Point(51, 142);
            this.targetAreaLabel.Name = "targetAreaLabel";
            this.targetAreaLabel.Size = new System.Drawing.Size(109, 15);
            this.targetAreaLabel.TabIndex = 7;
            this.targetAreaLabel.Text = "Choose target area:";
            // 
            // areaDropDown
            // 
            this.areaDropDown.DisplayMember = "uhui";
            this.areaDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.areaDropDown.FormattingEnabled = true;
            this.areaDropDown.Items.AddRange(new object[] {
            "TAP",
            "TAW"});
            this.areaDropDown.Location = new System.Drawing.Point(184, 139);
            this.areaDropDown.Name = "areaDropDown";
            this.areaDropDown.Size = new System.Drawing.Size(98, 23);
            this.areaDropDown.TabIndex = 8;
            // 
            // searchingFilesLabel
            // 
            this.searchingFilesLabel.AutoSize = true;
            this.searchingFilesLabel.Location = new System.Drawing.Point(54, 171);
            this.searchingFilesLabel.Name = "searchingFilesLabel";
            this.searchingFilesLabel.Size = new System.Drawing.Size(86, 15);
            this.searchingFilesLabel.TabIndex = 11;
            this.searchingFilesLabel.Text = "Searching files:";
            // 
            // searchingFilesTextField
            // 
            this.searchingFilesTextField.BackColor = System.Drawing.SystemColors.Window;
            this.searchingFilesTextField.ForeColor = System.Drawing.SystemColors.WindowText;
            this.searchingFilesTextField.Location = new System.Drawing.Point(184, 168);
            this.searchingFilesTextField.Multiline = true;
            this.searchingFilesTextField.Name = "searchingFilesTextField";
            this.searchingFilesTextField.PlaceholderText = "(No files)";
            this.searchingFilesTextField.ReadOnly = true;
            this.searchingFilesTextField.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.searchingFilesTextField.Size = new System.Drawing.Size(357, 87);
            this.searchingFilesTextField.TabIndex = 12;
            this.searchingFilesTextField.TextChanged += new System.EventHandler(this.searchingFilesTextField_TextChanged);
            // 
            // runButton
            // 
            this.runButton.BackColor = System.Drawing.Color.LightGreen;
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.Location = new System.Drawing.Point(240, 283);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(122, 31);
            this.runButton.TabIndex = 13;
            this.runButton.Text = "Go";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // informationLabel
            // 
            this.informationLabel.AutoSize = true;
            this.informationLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.informationLabel.Location = new System.Drawing.Point(54, 349);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(96, 14);
            this.informationLabel.TabIndex = 15;
            this.informationLabel.Text = "INFORMATION";
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(509, 669);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 16;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // resultsTextField
            // 
            this.resultsTextField.BackColor = System.Drawing.SystemColors.Window;
            this.resultsTextField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultsTextField.Location = new System.Drawing.Point(54, 378);
            this.resultsTextField.Name = "resultsTextField";
            this.resultsTextField.ReadOnly = true;
            this.resultsTextField.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.resultsTextField.Size = new System.Drawing.Size(487, 251);
            this.resultsTextField.TabIndex = 17;
            this.resultsTextField.Text = "";
            // 
            // getFileButton
            // 
            this.getFileButton.Image = ((System.Drawing.Image)(resources.GetObject("getFileButton.Image")));
            this.getFileButton.Location = new System.Drawing.Point(547, 167);
            this.getFileButton.Name = "getFileButton";
            this.getFileButton.Size = new System.Drawing.Size(37, 23);
            this.getFileButton.TabIndex = 21;
            this.getFileButton.UseVisualStyleBackColor = true;
            this.getFileButton.Click += new System.EventHandler(this.getFileButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xlsm";
            // 
            // spinningWheel
            // 
            this.spinningWheel.Image = ((System.Drawing.Image)(resources.GetObject("spinningWheel.Image")));
            this.spinningWheel.Location = new System.Drawing.Point(259, 484);
            this.spinningWheel.Name = "spinningWheel";
            this.spinningWheel.Size = new System.Drawing.Size(54, 43);
            this.spinningWheel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.spinningWheel.TabIndex = 22;
            this.spinningWheel.TabStop = false;
            this.spinningWheel.Visible = false;
            // 
            // StatisticsTextBox
            // 
            this.StatisticsTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.StatisticsTextBox.Location = new System.Drawing.Point(601, 9);
            this.StatisticsTextBox.Name = "StatisticsTextBox";
            this.StatisticsTextBox.ReadOnly = true;
            this.StatisticsTextBox.Size = new System.Drawing.Size(608, 683);
            this.StatisticsTextBox.TabIndex = 23;
            this.StatisticsTextBox.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.progressBar1.Location = new System.Drawing.Point(115, 635);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(426, 23);
            this.progressBar1.TabIndex = 24;
            // 
            // ClearConsoleButton
            // 
            this.ClearConsoleButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClearConsoleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearConsoleButton.Location = new System.Drawing.Point(51, 669);
            this.ClearConsoleButton.Name = "ClearConsoleButton";
            this.ClearConsoleButton.Size = new System.Drawing.Size(99, 23);
            this.ClearConsoleButton.TabIndex = 26;
            this.ClearConsoleButton.Text = "Clear Console";
            this.ClearConsoleButton.UseVisualStyleBackColor = false;
            this.ClearConsoleButton.Click += new System.EventHandler(this.ClearConsoleButton_Click);
            // 
            // StartOverButton
            // 
            this.StartOverButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.StartOverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartOverButton.Location = new System.Drawing.Point(152, 669);
            this.StartOverButton.Name = "StartOverButton";
            this.StartOverButton.Size = new System.Drawing.Size(99, 23);
            this.StartOverButton.TabIndex = 27;
            this.StartOverButton.Text = "Start Over";
            this.StartOverButton.UseVisualStyleBackColor = false;
            this.StartOverButton.Click += new System.EventHandler(this.StartOverButton_Click);
            // 
            // InformationButton
            // 
            this.InformationButton.BackColor = System.Drawing.Color.DarkGray;
            this.InformationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.InformationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InformationButton.Image = ((System.Drawing.Image)(resources.GetObject("InformationButton.Image")));
            this.InformationButton.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.InformationButton.Location = new System.Drawing.Point(257, 669);
            this.InformationButton.Name = "InformationButton";
            this.InformationButton.Size = new System.Drawing.Size(99, 23);
            this.InformationButton.TabIndex = 28;
            this.InformationButton.Text = "Information";
            this.InformationButton.UseVisualStyleBackColor = false;
            this.InformationButton.Click += new System.EventHandler(this.InformationButton_Click);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.AutoSize = true;
            this.ProgressLabel.Location = new System.Drawing.Point(54, 640);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(55, 15);
            this.ProgressLabel.TabIndex = 29;
            this.ProgressLabel.Text = "Progress:";
            // 
            // removeFile
            // 
            this.removeFile.Image = ((System.Drawing.Image)(resources.GetObject("removeFile.Image")));
            this.removeFile.Location = new System.Drawing.Point(547, 196);
            this.removeFile.Name = "removeFile";
            this.removeFile.Size = new System.Drawing.Size(37, 23);
            this.removeFile.TabIndex = 30;
            this.removeFile.UseVisualStyleBackColor = true;
            this.removeFile.Click += new System.EventHandler(this.removeFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1226, 704);
            this.Controls.Add(this.removeFile);
            this.Controls.Add(this.ProgressLabel);
            this.Controls.Add(this.InformationButton);
            this.Controls.Add(this.StartOverButton);
            this.Controls.Add(this.ClearConsoleButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.StatisticsTextBox);
            this.Controls.Add(this.spinningWheel);
            this.Controls.Add(this.getFileButton);
            this.Controls.Add(this.resultsTextField);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.informationLabel);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.searchingFilesTextField);
            this.Controls.Add(this.searchingFilesLabel);
            this.Controls.Add(this.areaDropDown);
            this.Controls.Add(this.targetAreaLabel);
            this.Controls.Add(this.nameOfStatsFileTextField);
            this.Controls.Add(this.nameOfStatsFileLabel);
            this.Controls.Add(this.openFolderButton);
            this.Controls.Add(this.LocationToSaveTextField);
            this.Controls.Add(this.LocationToSaveLabel);
            this.Controls.Add(this.setupLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "MainForm";
            this.Text = " Vulcan Statistics Programme";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spinningWheel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}