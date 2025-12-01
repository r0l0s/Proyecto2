using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace ProyectoGUI
{
    public partial class MemberManagerControl : UserControl
    {
        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        (double Latitude, double Longitude) Initial = (9.855270259973693, -83.90901312232018);


        public MemberManagerControl()
        {
            InitializeComponent();
        }

        private void MemberManagerControl_Load(object sender, EventArgs e)
        {
            // Propiedades iniciales del mapa
            MemberLocationControl.ShowCenter = false;
            MemberLocationControl.DragButton = MouseButtons.Left;
            MemberLocationControl.CanDragMap = true;
            MemberLocationControl.MapProvider = GMapProviders.GoogleMap;
            MemberLocationControl.Position = new PointLatLng(Initial.Latitude, Initial.Longitude);
            MemberLocationControl.MinZoom = 0;
            MemberLocationControl.MaxZoom = 24;
            MemberLocationControl.Zoom = 17;
            MemberLocationControl.AutoScroll = true;

            // Marcador
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(Initial.Latitude, Initial.Longitude), GMarkerGoogleType.red);
            markerOverlay.Markers.Add(marker); // Se agrega el marcador al mapa.

            // Agregado del tooltip de texto al marcador
            marker.ToolTipMode = MarkerTooltipMode.Always;
            //marker.ToolTipText = string.Format(" \n Ubicación: \n (Latitud:{0} / Longitud:{1}) ", Initial.Latitude, Initial.Longitude);

            // Agregado del overlay al mapa
            MemberLocationControl.Overlays.Add(markerOverlay);

            LatitudeLabel.Text = $"Latitud: {Initial.Latitude}";
            LongitudeLabel.Text = $"Longitud: {Initial.Longitude}";
        }

        private void MemberLocationControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Obtención de datos (latitud y longitud) del mapa donde el usuario presiona

            (double Latitude, double Longitude) UserSelection = (MemberLocationControl.FromLocalToLatLng(e.X, e.Y).Lat, MemberLocationControl.FromLocalToLatLng(e.X, e.Y).Lng);
            marker.Position = new PointLatLng(UserSelection.Latitude, UserSelection.Longitude);
            //marker.ToolTipText = string.Format(" \n Ubicación: \n (Latitud:{0} / Longitud:{1}) ", UserSelection.Latitude, UserSelection.Longitude);

            LatitudeLabel.Text = $"Latitud: {UserSelection.Latitude}";
            LongitudeLabel.Text = $"Longitud: {UserSelection.Longitude}";
        }

        private void CreateFamilyMemberButton_Click(object sender, EventArgs e)
        {
            // Adds the node to the family tree
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            NameLabel.Text = $"Nombre: {NameTextBox.Text}";
        }

        private void DateofBirthPicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime currentDate = DateTime.UtcNow.Date;
            DateTime dateSelected = DateofBirthPicker.Value;
            AgeLabel.Text = $"Edad: {Convert.ToString(currentDate.Year - dateSelected.Year)}";
        }
    }
}
