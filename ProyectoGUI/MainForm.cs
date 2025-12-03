using ProyectoGUI.Logica;
using System.Windows.Forms;

namespace ProyectoGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {   
            
            FamilyDataControl TestControl = new FamilyDataControl();
            TestControl.EnterFamilyConfig += OnEnterFamilyConfig;
            TestControl.Dock = DockStyle.Fill;
            DynamicPanel.Controls.Clear();
            DynamicPanel.Controls.Add(TestControl);

        }

        private void OnEnterFamilyConfig(FamilyTree family)
        {  
            FamilyManagerControl FMControl = new FamilyManagerControl(family);
            FMControl.AddMember += OnAddMember;
            FMControl.Dock = DockStyle.Fill;
            DynamicPanel.Controls.Clear();
            DynamicPanel.Controls.Add(FMControl);
        }

        private void OnAddMember(FamilyTree family)
        {
            MemberManagerControl MMControl = new MemberManagerControl(family);
            MMControl.FamilyMemberCreated += OnEnterFamilyConfig;
            MMControl.Dock = DockStyle.Fill;
            DynamicPanel.Controls.Clear();
            DynamicPanel.Controls.Add(MMControl);
        }
    }
}
