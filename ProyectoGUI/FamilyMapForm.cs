using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ProyectoGUI.Logica;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProyectoGUI
{
    public partial class FamilyMapForm : Form
    {
        private GMapControl MapControl;
        private GMapOverlay Overlay;
        private FamilyTree Family;
        private GeographicGraph Graph;

        public FamilyMapForm(FamilyTree family)
        {
            Family = family ?? throw new ArgumentNullException(nameof(family));
            Graph = new GeographicGraph();

            InitializeComponent();
            SetupMap();
            LoadFamilyMembers();
        }

        private void InitializeComponent()
        {
            this.MapControl = new GMapControl();
            this.SuspendLayout();
            // 
            // MapControl
            // 
            this.MapControl.Dock = DockStyle.Fill;
            this.MapControl.MinZoom = 0;
            this.MapControl.MaxZoom = 24;
            this.MapControl.Zoom = 2;
            this.MapControl.MapProvider = GMapProviders.GoogleMap;
            this.MapControl.Position = new PointLatLng(0, 0);
            this.MapControl.ShowCenter = false;
            this.Controls.Add(this.MapControl);
            // 
            // FamilyMapForm
            // 
            this.ClientSize = new Size(1000, 600);
            this.Text = $"Mapa de la Familia {Family.FamilyName}";
            this.ResumeLayout(false);
        }

        private void SetupMap()
        {
            Overlay = new GMapOverlay("familyOverlay");
            MapControl.Overlays.Add(Overlay);
            MapControl.DragButton = MouseButtons.Left;
        }

        private void LoadFamilyMembers()
        {
            // Agregar miembros al grafo
            if (Family.Root != null) Graph.AddMember(Family.Root);
            foreach (var kv in Family.Members)
                Graph.AddMember(kv.Value);

            // Añadir marcadores con foto de cada miembro
            foreach (var member in Graph.GetAllMembers())
            {
                if (!File.Exists(member.PhotoPath)) continue;

                Bitmap original = new Bitmap(member.PhotoPath);
                Bitmap resized = new Bitmap(original, new Size(50, 50)); // tamaño razonable
                Bitmap circle = MakeCircularImage(resized);

                GMapMarker marker = new GMarkerGoogle(new PointLatLng(member.Location.Latitude, member.Location.Longitude), circle);
                marker.Tag = member; // guardar referencia

                Overlay.Markers.Add(marker);
            }

            MapControl.ZoomAndCenterMarkers("familyOverlay");

            // Evento click de los marcadores
            MapControl.OnMarkerClick += MapControl_OnMarkerClick;
        }

        private void MapControl_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (item.Tag is FamilyMember member)
            {
                // Abrir ventana con distancias
                MemberDistanceForm distanceForm = new MemberDistanceForm(member, Graph);
                distanceForm.ShowDialog();
            }
        }

        private Bitmap MakeCircularImage(Bitmap src)
        {
            Bitmap dest = new Bitmap(src.Width, src.Height);
            using (Graphics g = Graphics.FromImage(dest))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Brush brush = new TextureBrush(src))
                {
                    g.FillEllipse(brush, 0, 0, src.Width, src.Height);
                }
            }
            return dest;
        }
    }
}
