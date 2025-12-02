namespace ProyectoGUI
{
    partial class MemberManagerControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            LongitudeLabel = new Label();
            LatitudeLabel = new Label();
            groupBox2 = new GroupBox();
            PhotoSelectionButton = new Button();
            label3 = new Label();
            NameTextBox = new TextBox();
            label5 = new Label();
            label8 = new Label();
            DateofBirthPicker = new DateTimePicker();
            AncestorSelectorBox = new ComboBox();
            DeathInfoContainer = new GroupBox();
            label10 = new Label();
            DateofDeathPicker = new DateTimePicker();
            IsDeadCheckBox = new CheckBox();
            FamilyNameLabel = new Label();
            IDLabel = new Label();
            AgeLabel = new Label();
            NameLabel = new Label();
            SelectedPictureBox = new PictureBox();
            CreateFamilyMemberButton = new Button();
            MemberLocationControl = new GMap.NET.WindowsForms.GMapControl();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            DeathInfoContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedPictureBox).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(DeathInfoContainer);
            splitContainer1.Panel1.Controls.Add(IsDeadCheckBox);
            splitContainer1.Panel1.Controls.Add(FamilyNameLabel);
            splitContainer1.Panel1.Controls.Add(IDLabel);
            splitContainer1.Panel1.Controls.Add(AgeLabel);
            splitContainer1.Panel1.Controls.Add(NameLabel);
            splitContainer1.Panel1.Controls.Add(SelectedPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(CreateFamilyMemberButton);
            splitContainer1.Panel2.Controls.Add(MemberLocationControl);
            splitContainer1.Size = new Size(1000, 660);
            splitContainer1.SplitterDistance = 361;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LongitudeLabel);
            groupBox1.Controls.Add(LatitudeLabel);
            groupBox1.Location = new Point(174, 532);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(184, 60);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ubicación";
            // 
            // LongitudeLabel
            // 
            LongitudeLabel.AutoSize = true;
            LongitudeLabel.Font = new Font("Segoe UI", 7F);
            LongitudeLabel.ForeColor = Color.Blue;
            LongitudeLabel.Location = new Point(6, 38);
            LongitudeLabel.Name = "LongitudeLabel";
            LongitudeLabel.Size = new Size(24, 12);
            LongitudeLabel.TabIndex = 7;
            LongitudeLabel.Text = "Lng:";
            // 
            // LatitudeLabel
            // 
            LatitudeLabel.AutoSize = true;
            LatitudeLabel.Font = new Font("Segoe UI", 7F);
            LatitudeLabel.ForeColor = Color.Blue;
            LatitudeLabel.Location = new Point(6, 19);
            LatitudeLabel.Name = "LatitudeLabel";
            LatitudeLabel.Size = new Size(20, 12);
            LatitudeLabel.TabIndex = 7;
            LatitudeLabel.Text = "Lat:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(PhotoSelectionButton);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(NameTextBox);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(DateofBirthPicker);
            groupBox2.Controls.Add(AncestorSelectorBox);
            groupBox2.Location = new Point(18, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(254, 312);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            // 
            // PhotoSelectionButton
            // 
            PhotoSelectionButton.Location = new Point(14, 251);
            PhotoSelectionButton.Name = "PhotoSelectionButton";
            PhotoSelectionButton.Size = new Size(225, 40);
            PhotoSelectionButton.TabIndex = 5;
            PhotoSelectionButton.Text = "Seleccionar Foto";
            PhotoSelectionButton.UseVisualStyleBackColor = true;
            PhotoSelectionButton.Click += PhotoSelectionButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(17, 27);
            label3.Name = "label3";
            label3.Size = new Size(71, 21);
            label3.TabIndex = 1;
            label3.Text = "Nombre:";
            // 
            // NameTextBox
            // 
            NameTextBox.Font = new Font("Segoe UI", 12F);
            NameTextBox.Location = new Point(14, 53);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(225, 29);
            NameTextBox.TabIndex = 2;
            NameTextBox.TextChanged += NameTextBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(17, 103);
            label5.Name = "label5";
            label5.Size = new Size(158, 21);
            label5.TabIndex = 1;
            label5.Text = "Fecha de Nacimiento:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(17, 177);
            label8.Name = "label8";
            label8.Size = new Size(76, 21);
            label8.TabIndex = 1;
            label8.Text = "Hijo/a de:";
            // 
            // DateofBirthPicker
            // 
            DateofBirthPicker.CalendarFont = new Font("Segoe UI", 12F);
            DateofBirthPicker.CustomFormat = "dd MM yyy";
            DateofBirthPicker.Format = DateTimePickerFormat.Custom;
            DateofBirthPicker.Location = new Point(14, 129);
            DateofBirthPicker.MaxDate = new DateTime(2025, 11, 30, 0, 0, 0, 0);
            DateofBirthPicker.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            DateofBirthPicker.Name = "DateofBirthPicker";
            DateofBirthPicker.Size = new Size(225, 23);
            DateofBirthPicker.TabIndex = 3;
            DateofBirthPicker.Value = new DateTime(2025, 11, 30, 0, 0, 0, 0);
            DateofBirthPicker.ValueChanged += DateofBirthPicker_ValueChanged;
            // 
            // AncestorSelectorBox
            // 
            AncestorSelectorBox.Font = new Font("Segoe UI", 12F);
            AncestorSelectorBox.FormattingEnabled = true;
            AncestorSelectorBox.Location = new Point(14, 203);
            AncestorSelectorBox.Name = "AncestorSelectorBox";
            AncestorSelectorBox.Size = new Size(225, 29);
            AncestorSelectorBox.TabIndex = 6;
            // 
            // DeathInfoContainer
            // 
            DeathInfoContainer.Controls.Add(label10);
            DeathInfoContainer.Controls.Add(DateofDeathPicker);
            DeathInfoContainer.Enabled = false;
            DeathInfoContainer.Location = new Point(18, 377);
            DeathInfoContainer.Name = "DeathInfoContainer";
            DeathInfoContainer.Size = new Size(254, 100);
            DeathInfoContainer.TabIndex = 4;
            DeathInfoContainer.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F);
            label10.Location = new Point(17, 28);
            label10.Name = "label10";
            label10.Size = new Size(128, 21);
            label10.TabIndex = 1;
            label10.Text = "Fecha de Muerte:";
            // 
            // DateofDeathPicker
            // 
            DateofDeathPicker.CalendarFont = new Font("Segoe UI", 12F);
            DateofDeathPicker.CustomFormat = "dd MM yyy";
            DateofDeathPicker.Format = DateTimePickerFormat.Custom;
            DateofDeathPicker.Location = new Point(14, 54);
            DateofDeathPicker.MaxDate = new DateTime(2025, 11, 30, 0, 0, 0, 0);
            DateofDeathPicker.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            DateofDeathPicker.Name = "DateofDeathPicker";
            DateofDeathPicker.Size = new Size(225, 23);
            DateofDeathPicker.TabIndex = 3;
            DateofDeathPicker.Value = new DateTime(2025, 11, 30, 0, 0, 0, 0);
            DateofDeathPicker.ValueChanged += DateofDeathPicker_ValueChanged;
            // 
            // IsDeadCheckBox
            // 
            IsDeadCheckBox.AutoSize = true;
            IsDeadCheckBox.Font = new Font("Segoe UI", 12F);
            IsDeadCheckBox.Location = new Point(32, 346);
            IsDeadCheckBox.Name = "IsDeadCheckBox";
            IsDeadCheckBox.Size = new Size(103, 25);
            IsDeadCheckBox.TabIndex = 8;
            IsDeadCheckBox.Text = "Fallecido/a";
            IsDeadCheckBox.UseVisualStyleBackColor = true;
            IsDeadCheckBox.CheckedChanged += IsDeadCheckBox_CheckedChanged;
            // 
            // FamilyNameLabel
            // 
            FamilyNameLabel.AutoSize = true;
            FamilyNameLabel.Font = new Font("Segoe UI", 9F);
            FamilyNameLabel.Location = new Point(174, 619);
            FamilyNameLabel.Name = "FamilyNameLabel";
            FamilyNameLabel.Size = new Size(45, 15);
            FamilyNameLabel.TabIndex = 7;
            FamilyNameLabel.Text = "Familia";
            FamilyNameLabel.Visible = false;
            // 
            // IDLabel
            // 
            IDLabel.AutoSize = true;
            IDLabel.Font = new Font("Segoe UI", 9F);
            IDLabel.Location = new Point(174, 598);
            IDLabel.Name = "IDLabel";
            IDLabel.Size = new Size(47, 15);
            IDLabel.TabIndex = 7;
            IDLabel.Text = "Cédula:";
            // 
            // AgeLabel
            // 
            AgeLabel.AutoSize = true;
            AgeLabel.Font = new Font("Segoe UI", 9F);
            AgeLabel.Location = new Point(174, 511);
            AgeLabel.Name = "AgeLabel";
            AgeLabel.Size = new Size(36, 15);
            AgeLabel.TabIndex = 7;
            AgeLabel.Text = "Edad:";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Font = new Font("Segoe UI", 9F);
            NameLabel.Location = new Point(174, 490);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(54, 15);
            NameLabel.TabIndex = 7;
            NameLabel.Text = "Nombre:";
            // 
            // SelectedPictureBox
            // 
            SelectedPictureBox.BorderStyle = BorderStyle.FixedSingle;
            SelectedPictureBox.Location = new Point(18, 487);
            SelectedPictureBox.Name = "SelectedPictureBox";
            SelectedPictureBox.Size = new Size(150, 150);
            SelectedPictureBox.TabIndex = 4;
            SelectedPictureBox.TabStop = false;
            // 
            // CreateFamilyMemberButton
            // 
            CreateFamilyMemberButton.Font = new Font("Segoe UI", 12F);
            CreateFamilyMemberButton.Location = new Point(140, 557);
            CreateFamilyMemberButton.Name = "CreateFamilyMemberButton";
            CreateFamilyMemberButton.Size = new Size(353, 80);
            CreateFamilyMemberButton.TabIndex = 3;
            CreateFamilyMemberButton.Text = "Crear Miembro Familiar";
            CreateFamilyMemberButton.UseVisualStyleBackColor = true;
            CreateFamilyMemberButton.Click += CreateFamilyMemberButton_Click;
            // 
            // MemberLocationControl
            // 
            MemberLocationControl.Bearing = 0F;
            MemberLocationControl.CanDragMap = true;
            MemberLocationControl.EmptyTileColor = Color.Navy;
            MemberLocationControl.GrayScaleMode = false;
            MemberLocationControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            MemberLocationControl.LevelsKeepInMemory = 5;
            MemberLocationControl.Location = new Point(16, 20);
            MemberLocationControl.MarkersEnabled = true;
            MemberLocationControl.MaxZoom = 2;
            MemberLocationControl.MinZoom = 2;
            MemberLocationControl.MouseWheelZoomEnabled = true;
            MemberLocationControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            MemberLocationControl.Name = "MemberLocationControl";
            MemberLocationControl.NegativeMode = false;
            MemberLocationControl.PolygonsEnabled = true;
            MemberLocationControl.RetryLoadTile = 0;
            MemberLocationControl.RoutesEnabled = true;
            MemberLocationControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            MemberLocationControl.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            MemberLocationControl.ShowTileGridLines = false;
            MemberLocationControl.Size = new Size(600, 518);
            MemberLocationControl.TabIndex = 0;
            MemberLocationControl.Zoom = 0D;
            MemberLocationControl.MouseDoubleClick += MemberLocationControl_MouseDoubleClick;
            // 
            // MemberManagerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Name = "MemberManagerControl";
            Size = new Size(1000, 660);
            Load += MemberManagerControl_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            DeathInfoContainer.ResumeLayout(false);
            DeathInfoContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SelectedPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GMap.NET.WindowsForms.GMapControl MemberLocationControl;
        private Button CreateFamilyMemberButton;
        private TextBox NameTextBox;
        private Label label3;
        private DateTimePicker DateofBirthPicker;
        private Label label5;
        private PictureBox SelectedPictureBox;
        private Button PhotoSelectionButton;
        private Label label8;
        private Label AgeLabel;
        private Label NameLabel;
        private ComboBox AncestorSelectorBox;
        private Label IDLabel;
        private CheckBox IsDeadCheckBox;
        private DateTimePicker DateofDeathPicker;
        private Label label10;
        private GroupBox DeathInfoContainer;
        private Label FamilyNameLabel;
        private GroupBox groupBox1;
        private Label LongitudeLabel;
        private Label LatitudeLabel;
        private GroupBox groupBox2;
    }
}
