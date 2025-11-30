using System;
using System.Windows.Forms;
using System.Drawing;
using Proyecto2.FamilyTreeSpace;  

namespace Proyecto2
{
    public partial class MainForm : Form
    {
        private FamilyTree _familyTree;
        
        public MainForm()
        {
            _familyTree = new FamilyTree();
            InitializeForm();
        }
        
        private void InitializeForm()
        {
            this.Text = "Árbol Genealógico - Proyecto 2";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            
            var lblTitle = new Label()
            {
                Text = "Sistema de Árbol Genealógico",
                Location = new Point(50, 30),
                AutoSize = true,
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            
            var btnTest = new Button()
            {
                Text = "Probar Lógica del Árbol",
                Location = new Point(50, 80),
                Size = new Size(200, 40),
                BackColor = Color.LightBlue,
                Font = new Font("Arial", 10)
            };
            btnTest.Click += BtnTest_Click;
            
            this.Controls.Add(lblTitle);
            this.Controls.Add(btnTest);
        }
        
        private void BtnTest_Click(object sender, EventArgs e)
        {
            try
            {
                var person = new Person("001", "Juan Pérez", new DateTime(1980, 5, 15));
                
                if (!_familyTree.HasRoot)
                {
                    _familyTree.AddRoot(person);
                    MessageBox.Show("✅ Persona agregada como raíz del árbol\n" +
                                   $"Nombre: {person.Name}\n" +
                                   $"Edad: {person.Age} años", 
                                   "Éxito");
                }
                
                var members = _familyTree.GetAllMembers();
                MessageBox.Show($"Miembros en el árbol: {members.Count()}", "Información");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error: {ex.Message}", "Error");
            }
        }
    }
}