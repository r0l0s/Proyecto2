using System.Windows.Forms;

namespace ProyectoGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
        }

        private void MainForm_Load(object sender, EventArgs e)
        {   
            
            FamilyDataControl TestControl = new FamilyDataControl();
            TestControl.EnterFamilyConfig += c_EnterFamilyConfig!;
            TestControl.Dock = DockStyle.Fill;
            DynamicPanel.Controls.Clear();
            DynamicPanel.Controls.Add(TestControl);

        }

        private void c_EnterFamilyConfig(object sender, EventArgs e)
        {
            FamilyManagerControl FMControl = new FamilyManagerControl();
            FMControl.Dock = DockStyle.Fill;
            DynamicPanel.Controls.Clear();
            DynamicPanel.Controls.Add(FMControl);
        }
    }
}
