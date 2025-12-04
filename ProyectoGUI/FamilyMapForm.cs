using System;
using System.Drawing;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ProyectoGUI.Logica;

namespace ProyectoGUI
{
    public partial class FamilyMapForm : Form
    {
        private FamilyTree Family;
        private GMapControl MapControl;
        private GMapOverlay MarkersOverlay;

        public FamilyMapForm(FamilyTree family)
        {
            Family = family;
            InitializeComponent();
            InitializeMap();
            LoadFamilyMarkers();
        }

        private void InitializeComponent()
        {
            this.MapControl = new GMapControl();
            this.SuspendLayout();
            // 
            // MapControl
            // 
            this.MapControl.Dock = DockStyle.Fill;
            this.MapControl.Bearing = 0F;
            this.MapControl.CanDragMap = true;
            this.MapControl.EmptyTileColor = Color.Navy;
            this.MapControl.GrayScaleMode = false;
            this.MapControl.HelperLineOption = HelperLineOptions.DontShow;
            this.MapControl.MarkersEnabled = true;
            this.MapControl.MaxZoom = 24;
            this.MapControl.MinZoom = 0;
            this.MapControl.MouseWheelZoomEnabled = true;
            this.MapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            this.MapControl.NegativeMode = false;
            this.MapControl.PolygonsEnabled = true;
            this.MapControl.RetryLoadTile = 0;
            this.MapControl.RoutesEnabled = true;
            this.MapControl.ShowTileGridLines = false;
            this.MapControl.Zoom = 5D;
            // 
            // FamilyMapForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.MapControl);
            this.Text = $"Mapa de la familia {Family.FamilyName}";
            this.ResumeLayout(false);
        }

        private void InitializeMap()
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            MapControl.MapProvider = GoogleMapProvider.Instance;
            MapControl.Position = new PointLatLng(20.0, 0.0); // Centro inicial
            MapControl.Zoom = 2;
            MarkersOverlay = new GMapOverlay("familyMarkers");
            MapControl.Overlays.Add(MarkersOverlay);
        }

        private void LoadFamilyMarkers()
        {
            foreach (var member in Family.Members.Values)
            {
                AddMemberMarker(member);
            }

            if (Family.Root != null)
            {
                AddMemberMarker(Family.Root);
            }

            // Ajustar la vista para que incluya todos los marcadores
            if (MarkersOverlay.Markers.Count > 0)
            {
                MapControl.SetZoomToFitRect(GetBounds());
            }
        }

        private void AddMemberMarker(FamilyMember member)
        {
            PointLatLng point = new PointLatLng(member.Location.Latitude, member.Location.Longitude);

            Bitmap bmp;
            if (!string.IsNullOrEmpty(member.PhotoPath) && System.IO.File.Exists(member.PhotoPath))
            {
                bmp = new Bitmap(member.PhotoPath);
            }
            else
            {
                bmp = new Bitmap(40, 40);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.Gray);
                }
            }

            // Redimensionar la imagen para que no sea demasiado grande
            Bitmap smallBmp = new Bitmap(bmp, new Size(40, 40));
            GMarkerGoogle marker = new GMarkerGoogle(point, smallBmp)
            {
                ToolTipText = member.Name,
                ToolTipMode = MarkerTooltipMode.Always
            };

            MarkersOverlay.Markers.Add(marker);
        }

        private RectLatLng GetBounds()
        {
            double minLat = double.MaxValue;
            double maxLat = double.MinValue;
            double minLng = double.MaxValue;
            double maxLng = double.MinValue;

            foreach (var m in MarkersOverlay.Markers)
            {
                if (m.Position.Lat < minLat) minLat = m.Position.Lat;
                if (m.Position.Lat > maxLat) maxLat = m.Position.Lat;
                if (m.Position.Lng < minLng) minLng = m.Position.Lng;
                if (m.Position.Lng > maxLng) maxLng = m.Position.Lng;
            }

            return new RectLatLng(maxLat, minLng, maxLng - minLng, maxLat - minLat);
        }
    }
}
