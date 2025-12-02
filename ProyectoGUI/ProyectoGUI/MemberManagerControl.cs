using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ProyectoGUI.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoGUI
{
    public partial class MemberManagerControl : UserControl
    {

        MemberDetails Member = new MemberDetails();

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;

        public MemberManagerControl()
        {
            InitializeComponent();
        }

        private void UpdateInformation()
        {
            NameLabel.Text = $"Nombre: {Member.Nombre}";
            //AgeLabel.Text = $"Edad: {Convert.ToString(Member.Edad)}";
            LatitudeLabel.Text = $"Latitud: {Member.Ubicacion.Latitude}";
            LongitudeLabel.Text = $"Longitud: {Member.Ubicacion.Longitude}";
            IDLabel.Text = $"Cédula:{string.Join("", Generator.GenerateID(Member.Edad, Member.Ubicacion.Latitude, Member.Ubicacion.Longitude))}";
        }

        private void MemberManagerControl_Load(object sender, EventArgs e)
        {
            // Propiedades iniciales del mapa
            MemberLocationControl.ShowCenter = false;
            MemberLocationControl.DragButton = MouseButtons.Left;
            MemberLocationControl.CanDragMap = true;
            MemberLocationControl.MapProvider = GMapProviders.GoogleMap;
            MemberLocationControl.Position = new PointLatLng(Member.Ubicacion.Latitude, Member.Ubicacion.Longitude);
            MemberLocationControl.MinZoom = 0;
            MemberLocationControl.MaxZoom = 24;
            MemberLocationControl.Zoom = 17;
            MemberLocationControl.AutoScroll = true;

            // Marcador
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(Member.Ubicacion.Latitude, Member.Ubicacion.Longitude), GMarkerGoogleType.red);
            markerOverlay.Markers.Add(marker); // Se agrega el marcador al mapa.

            // Agregado del tooltip de texto al marcador
            marker.ToolTipMode = MarkerTooltipMode.Always;
            //marker.ToolTipText = string.Format(" \n Ubicación: \n (Latitud:{0} / Longitud:{1}) ", Initial.Latitude, Initial.Longitude);

            // Agregado del overlay al mapa
            MemberLocationControl.Overlays.Add(markerOverlay);

            //LatitudeLabel.Text = $"Latitud: {Member.Ubicacion.Latitude}";
            //LongitudeLabel.Text = $"Longitud: {Member.Ubicacion.Longitude}";
            UpdateInformation();
        }

        private void MemberLocationControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Obtención de datos (latitud y longitud) del mapa donde el usuario presiona

            Member.Ubicacion = (MemberLocationControl.FromLocalToLatLng(e.X, e.Y).Lat, MemberLocationControl.FromLocalToLatLng(e.X, e.Y).Lng);
            marker.Position = new PointLatLng(Member.Ubicacion.Latitude, Member.Ubicacion.Longitude);
            //marker.ToolTipText = string.Format(" \n Ubicación: \n (Latitud:{0} / Longitud:{1}) ", UserSelection.Latitude, UserSelection.Longitude);

            //LatitudeLabel.Text = $"Latitud: {Member.Ubicacion.Latitude}";
            //LongitudeLabel.Text = $"Longitud: {Member.Ubicacion.Longitude}";
            UpdateInformation();
        }

        private void CreateFamilyMemberButton_Click(object sender, EventArgs e)
        {
            // Adds the node to the family tree
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            Member.Nombre = NameTextBox.Text;
            //NameLabel.Text = $"Nombre: {Member.Nombre}";
            UpdateInformation();
        }

        private void DateofBirthPicker_ValueChanged(object sender, EventArgs e)
        {

            Member.Edad = Generator.GenerateAge(DateTime.UtcNow.Date, DateofBirthPicker.Value);
            AgeLabel.Text = $"Edad: {Convert.ToString(Member.Edad)}";
            UpdateInformation();

        }

        // Photo Selection Button
        private void PhotoSelectionButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;
                    Member.Foto = imagePath;
                    SelectedPictureBox.Image = Image.FromFile(imagePath);
                }
            }
        }

        private void IsDeadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = IsDeadCheckBox.Checked;

            if (isChecked)
            {
                DeathInfoContainer.Enabled = true;
                DateofDeathPicker.MinDate = DateofBirthPicker.Value;
                DateofBirthPicker.Enabled = false;
                DateofDeathPicker_ValueChanged(sender, e);
          
            }

            else
            {
                DeathInfoContainer.Enabled = false;
                DateofBirthPicker.Enabled = true;
                DateofBirthPicker_ValueChanged(sender, e);
            }
        }

        private void DateofDeathPicker_ValueChanged(object sender, EventArgs e)
        {

            Member.Edad = Generator.GenerateAge(DateofDeathPicker.Value, DateofBirthPicker.Value);
            AgeLabel.Text = $"Edad de muerte: {Convert.ToString(Member.Edad)}";
            
        }
    }
}
