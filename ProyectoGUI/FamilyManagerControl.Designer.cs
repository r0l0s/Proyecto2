namespace ProyectoGUI
{
    partial class FamilyManagerControl
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
            SelectedFamilyLabel = new Label();
            AddMemberButton = new Button();
            ViewMapButton = new Button();
            FamilyStatisticsButton = new Button();
            FamilyTreeButton = new Button();
            FamilyTreeView = new TreeView();
            SuspendLayout();
            // 
            // SelectedFamilyLabel
            // 
            SelectedFamilyLabel.AutoSize = true;
            SelectedFamilyLabel.Font = new Font("Segoe UI", 15F);
            SelectedFamilyLabel.Location = new Point(209, 63);
            SelectedFamilyLabel.Name = "SelectedFamilyLabel";
            SelectedFamilyLabel.Size = new Size(138, 28);
            SelectedFamilyLabel.TabIndex = 0;
            SelectedFamilyLabel.Text = "Family's Name";
            // 
            // AddMemberButton
            // 
            AddMemberButton.Font = new Font("Segoe UI", 12F);
            AddMemberButton.Location = new Point(518, 172);
            AddMemberButton.Name = "AddMemberButton";
            AddMemberButton.Size = new Size(200, 40);
            AddMemberButton.TabIndex = 1;
            AddMemberButton.Text = "Agregar Miembro";
            AddMemberButton.UseVisualStyleBackColor = true;
            AddMemberButton.Click += AddMemberButton_Click;
            // 
            // ViewMapButton
            // 
            ViewMapButton.Font = new Font("Segoe UI", 12F);
            ViewMapButton.Location = new Point(518, 231);
            ViewMapButton.Name = "ViewMapButton";
            ViewMapButton.Size = new Size(200, 40);
            ViewMapButton.TabIndex = 1;
            ViewMapButton.Text = "Visualizar Mapa";
            ViewMapButton.UseVisualStyleBackColor = true;
            ViewMapButton.Click += ViewMapButton_Click;
            // 
            // FamilyStatisticsButton
            // 
            FamilyStatisticsButton.Font = new Font("Segoe UI", 12F);
            FamilyStatisticsButton.Location = new Point(518, 349);
            FamilyStatisticsButton.Name = "FamilyStatisticsButton";
            FamilyStatisticsButton.Size = new Size(200, 40);
            FamilyStatisticsButton.TabIndex = 1;
            FamilyStatisticsButton.Text = "Estadísticas Familiares";
            FamilyStatisticsButton.UseVisualStyleBackColor = true;
            FamilyStatisticsButton.Click += FamilyStatisticsButton_Click;
            // 
            // FamilyTreeButton
            // 
            FamilyTreeButton.Font = new Font("Segoe UI", 12F);
            FamilyTreeButton.Location = new Point(518, 290);
            FamilyTreeButton.Name = "FamilyTreeButton";
            FamilyTreeButton.Size = new Size(200, 40);
            FamilyTreeButton.TabIndex = 1;
            FamilyTreeButton.Text = "Visualizar Árbol Familiar";
            FamilyTreeButton.UseVisualStyleBackColor = true;
            FamilyTreeButton.Click += FamilyTreeButton_Click;
            // 
            // FamilyTreeView
            // 
            FamilyTreeView.Font = new Font("Segoe UI", 12F);
            FamilyTreeView.Location = new Point(71, 104);
            FamilyTreeView.Name = "FamilyTreeView";
            FamilyTreeView.Size = new Size(414, 460);
            FamilyTreeView.TabIndex = 2;
            // 
            // FamilyManagerControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(FamilyTreeView);
            Controls.Add(AddMemberButton);
            Controls.Add(FamilyStatisticsButton);
            Controls.Add(ViewMapButton);
            Controls.Add(SelectedFamilyLabel);
            Controls.Add(FamilyTreeButton);
            Name = "FamilyManagerControl";
            Size = new Size(1000, 600);
            Load += FamilyManagerControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label SelectedFamilyLabel;
        private Button AddMemberButton;
        private Button ViewMapButton;
        private Button FamilyStatisticsButton;
        private Button FamilyTreeButton;
        private TreeView FamilyTreeView;
    }
}
