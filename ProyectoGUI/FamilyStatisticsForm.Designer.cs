namespace ProyectoGUI
{
    partial class FamilyStatisticsForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label FarLabel;
        private Label CloseLabel;
        private Label AvgLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            FarLabel = new Label();
            CloseLabel = new Label();
            AvgLabel = new Label();

            SuspendLayout();

            // FarLabel
            FarLabel.AutoSize = true;
            FarLabel.Font = new Font("Segoe UI", 13F);
            FarLabel.Location = new Point(40, 40);
            FarLabel.Size = new Size(500, 50);

            // CloseLabel
            CloseLabel.AutoSize = true;
            CloseLabel.Font = new Font("Segoe UI", 13F);
            CloseLabel.Location = new Point(40, 140);
            CloseLabel.Size = new Size(500, 50);

            // AvgLabel
            AvgLabel.AutoSize = true;
            AvgLabel.Font = new Font("Segoe UI", 13F);
            AvgLabel.Location = new Point(40, 240);
            AvgLabel.Size = new Size(500, 50);

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            ClientSize = new Size(600, 400);
            Controls.Add(FarLabel);
            Controls.Add(CloseLabel);
            Controls.Add(AvgLabel);
            Name = "FamilyStatisticsForm";
            Text = "Estadísticas Familiares";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
