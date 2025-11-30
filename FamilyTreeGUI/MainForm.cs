using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
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
            this.Resize += MainForm_Resize; // Para mantener centrado al redimensionar
        }
        
        private void InitializeForm()
        {
            this.Text = "Árbol Genealógico - Proyecto 2";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // TÍTULO CENTRADO - Parte superior
            var lblTitle = new Label()
            {
                Text = "Sistema de Árbol Genealógico",
                AutoSize = true,
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            
            // Centrar el título horizontalmente
            lblTitle.Location = new Point(
                (this.Width - lblTitle.Width) / 2,  // Centrado horizontal
                20  // 20 píxeles desde el borde superior
            );
            
            // Botón para probar la lógica del árbol
            var btnTest = new Button()
            {
                Text = "Probar Lógica del Árbol",
                Location = new Point(50, 80),
                Size = new Size(200, 40),
                BackColor = Color.LightBlue,
                Font = new Font("Arial", 10)
            };
            btnTest.Click += BtnTest_Click;
            
            // Botón para el mapa - Parte superior derecha
            var btnMapa = new Button()
            {
                Text = "Abrir Mapa",
                Size = new Size(120, 35),
                Location = new Point(this.Width - 150, 20), // Superior derecha
                BackColor = Color.LightGreen,
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };
            btnMapa.Click += BtnMapa_Click;
            
            // Agregar controles al formulario
            this.Controls.Add(lblTitle);
            this.Controls.Add(btnTest);
            this.Controls.Add(btnMapa);
        }
        
        private void MainForm_Resize(object? sender, EventArgs e)
        {
            // Recentrar el título cuando cambie el tamaño
            var lblTitle = this.Controls.OfType<Label>().FirstOrDefault();
            if (lblTitle != null)
            {
                lblTitle.Location = new Point((this.Width - lblTitle.Width) / 2, 20);
            }
            
            // Recentrar también el botón del mapa
            var btnMapa = this.Controls.OfType<Button>().FirstOrDefault(b => b.Text == "Abrir Mapa");
            if (btnMapa != null)
            {
                btnMapa.Location = new Point(this.Width - 150, 20);
            }
        }
        
        private void BtnTest_Click(object? sender, EventArgs e)
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
        
        // MÉTODO PARA ABRIR LA VENTANA DEL MAPA
        private void BtnMapa_Click(object? sender, EventArgs e)
        {
            var mapaForm = new MapForm();
            mapaForm.Show();
        }
    }
    
    // CLASE PARA LA VENTANA DEL MAPA (por ahora en blanco)
    public class MapForm : Form
    {
        public MapForm()
        {
            InitializeMapForm();
        }
        
        private void InitializeMapForm()
        {
            this.Text = "Mapa Familiar - Proyecto 2";
            this.Size = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.LightGray; // Color temporal para distinguirla
            
            // Título del mapa
            var lblMapTitle = new Label()
            {
                Text = "🗺️ Mapa Familiar (En Desarrollo)",
                Location = new Point(50, 30),
                AutoSize = true,
                Font = new Font("Arial", 18, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            
            // Mensaje temporal
            var lblMessage = new Label()
            {
                Text = "Aquí irá el mapa interactivo con las ubicaciones de los familiares\n" +
                       "y las distancias entre ellos.",
                Location = new Point(50, 80),
                AutoSize = true,
                Font = new Font("Arial", 12),
                ForeColor = Color.DarkSlateGray
            };
            
            // Botón para cerrar
            var btnCerrar = new Button()
            {
                Text = "Cerrar Mapa",
                Location = new Point(50, 150),
                Size = new Size(120, 35),
                BackColor = Color.LightCoral,
                Font = new Font("Arial", 10)
            };
            btnCerrar.Click += (s, e) => this.Close();
            
            this.Controls.Add(lblMapTitle);
            this.Controls.Add(lblMessage);
            this.Controls.Add(btnCerrar);
        }
    }
}