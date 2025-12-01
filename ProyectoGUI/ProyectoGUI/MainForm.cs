namespace ProyectoGUI
{
    public partial class MainForm : Form
    {   
        public MainForm()
        {
            InitializeComponent();
            MemberManagerControl TestControl = new();
            TestControl.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
