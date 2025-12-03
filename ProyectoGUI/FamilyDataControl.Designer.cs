namespace ProyectoGUI
{
    partial class FamilyDataControl
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
            AvailableFamiliesList = new ListBox();
            RemoveFamilyButton = new Button();
            FamiliesTitle = new Label();
            FamilyNameTextBox = new TextBox();
            CreateFamilyButton = new Button();
            FamilyConfigButton = new Button();
            SuspendLayout();
            // 
            // AvailableFamiliesList
            // 
            AvailableFamiliesList.Font = new Font("Segoe UI", 12F);
            AvailableFamiliesList.FormattingEnabled = true;
            AvailableFamiliesList.Location = new Point(99, 108);
            AvailableFamiliesList.Name = "AvailableFamiliesList";
            AvailableFamiliesList.Size = new Size(334, 424);
            AvailableFamiliesList.TabIndex = 0;
            AvailableFamiliesList.SelectedIndexChanged += AvailableFamiliesList_SelectedIndexChanged;
            // 
            // RemoveFamilyButton
            // 
            RemoveFamilyButton.Font = new Font("Segoe UI", 12F);
            RemoveFamilyButton.Location = new Point(597, 385);
            RemoveFamilyButton.Name = "RemoveFamilyButton";
            RemoveFamilyButton.Size = new Size(200, 40);
            RemoveFamilyButton.TabIndex = 1;
            RemoveFamilyButton.Text = "Eliminar Familia";
            RemoveFamilyButton.UseVisualStyleBackColor = true;
            RemoveFamilyButton.Click += RemoveFamilyButton_Click;
            // 
            // FamiliesTitle
            // 
            FamiliesTitle.AutoSize = true;
            FamiliesTitle.Font = new Font("Segoe UI", 15F);
            FamiliesTitle.Location = new Point(226, 62);
            FamiliesTitle.Name = "FamiliesTitle";
            FamiliesTitle.Size = new Size(81, 28);
            FamiliesTitle.TabIndex = 2;
            FamiliesTitle.Text = "Familias";
            // 
            // FamilyNameTextBox
            // 
            FamilyNameTextBox.Font = new Font("Segoe UI", 12F);
            FamilyNameTextBox.Location = new Point(530, 228);
            FamilyNameTextBox.Name = "FamilyNameTextBox";
            FamilyNameTextBox.Size = new Size(335, 29);
            FamilyNameTextBox.TabIndex = 3;
            FamilyNameTextBox.Text = "Nombre de la nueva familia...";
            // 
            // CreateFamilyButton
            // 
            CreateFamilyButton.Font = new Font("Segoe UI", 12F);
            CreateFamilyButton.Location = new Point(597, 285);
            CreateFamilyButton.Name = "CreateFamilyButton";
            CreateFamilyButton.Size = new Size(200, 40);
            CreateFamilyButton.TabIndex = 1;
            CreateFamilyButton.Text = "Crear Familia";
            CreateFamilyButton.UseVisualStyleBackColor = true;
            CreateFamilyButton.Click += CreateFamilyButton_Click;
            // 
            // FamilyConfigButton
            // 
            FamilyConfigButton.Font = new Font("Segoe UI", 12F);
            FamilyConfigButton.Location = new Point(161, 552);
            FamilyConfigButton.Name = "FamilyConfigButton";
            FamilyConfigButton.Size = new Size(210, 60);
            FamilyConfigButton.TabIndex = 1;
            FamilyConfigButton.Text = "Configurar Familia";
            FamilyConfigButton.UseVisualStyleBackColor = true;
            FamilyConfigButton.Click += FamilyConfigButton_Click;
            // 
            // FamilyDataControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(FamilyNameTextBox);
            Controls.Add(FamiliesTitle);
            Controls.Add(CreateFamilyButton);
            Controls.Add(FamilyConfigButton);
            Controls.Add(RemoveFamilyButton);
            Controls.Add(AvailableFamiliesList);
            Name = "FamilyDataControl";
            Size = new Size(1000, 660);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox AvailableFamiliesList;
        private Button RemoveFamilyButton;
        private Label FamiliesTitle;
        private TextBox FamilyNameTextBox;
        private Button CreateFamilyButton;
        private Button FamilyConfigButton;
    }
}
