namespace ProyectoGUI
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
        private void InitializeComponent()
        {
            memberManagerControl1 = new MemberManagerControl();
            SuspendLayout();
            // 
            // memberManagerControl1
            // 
            memberManagerControl1.Location = new Point(252, 12);
            memberManagerControl1.Name = "memberManagerControl1";
            memberManagerControl1.Size = new Size(1000, 660);
            memberManagerControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(memberManagerControl1);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ProyectoFamilia";
            ResumeLayout(false);
        }

        #endregion

        private MemberManagerControl memberManagerControl1;
    }
}
