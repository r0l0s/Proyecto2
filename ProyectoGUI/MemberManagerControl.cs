using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using ProyectoGUI.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoGUI
{
    public partial class MemberManagerControl : UserControl
    {

        public delegate void CreateMemberHandler(FamilyTree Family);
        public event CreateMemberHandler? FamilyMemberCreated;

        MemberDetails Member = new MemberDetails();

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;


        private FamilyTree Family;

        public MemberManagerControl(FamilyTree family)
        {
            Family = family;
            InitializeComponent();

            var Parents = Family.GetPossibleParents();
            foreach (string name in Parents)
            {
                AncestorSelectorBox.Items.AddRange(name);
            }
        
            
        }






        private void UpdateInformation()
        {
            Member.ID = Generator.GenerateID(Member.Age, Member.Location.Latitude, Member.Location.Longitude);

            NameLabel.Text = $"Nombre: {Member.Name}";
            LatitudeLabel.Text = $"Latitud: {Member.Location.Latitude}";
            LongitudeLabel.Text = $"Longitud: {Member.Location.Longitude}";
            IDLabel.Text = $"Cédula:{string.Join("", Member.ID)}";
        }

        private void MemberManagerControl_Load(object sender, EventArgs e)
        {
            

            // Propiedades iniciales del mapa
            MemberLocationControl.ShowCenter = false;
            MemberLocationControl.DragButton = MouseButtons.Left;
            MemberLocationControl.CanDragMap = true;
            MemberLocationControl.MapProvider = GMapProviders.GoogleMap;
            MemberLocationControl.Position = new PointLatLng(Member.Location.Latitude, Member.Location.Longitude);
            MemberLocationControl.MinZoom = 0;
            MemberLocationControl.MaxZoom = 24;
            MemberLocationControl.Zoom = 17;
            MemberLocationControl.AutoScroll = true;

            // Marcador
            markerOverlay = new GMapOverlay("Marcador");
            marker = new GMarkerGoogle(new PointLatLng(Member.Location.Latitude, Member.Location.Longitude), GMarkerGoogleType.red);
            markerOverlay.Markers.Add(marker); // Se agrega el marcador al mapa.

            // Agregado del tooltip de texto al marcador
            marker.ToolTipMode = MarkerTooltipMode.Always;
            //marker.ToolTipText = string.Format(" \n Ubicación: \n (Latitud:{0} / Longitud:{1}) ", Initial.Latitude, Initial.Longitude);

            // Agregado del overlay al mapa
            MemberLocationControl.Overlays.Add(markerOverlay);
            FamilyNameLabel.Text = Family.FamilyName;
            UpdateInformation();
        }

        private void MemberLocationControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Obtención de datos (latitud y longitud) del mapa donde el usuario presiona

            Member.Location = (MemberLocationControl.FromLocalToLatLng(e.X, e.Y).Lat, MemberLocationControl.FromLocalToLatLng(e.X, e.Y).Lng);
            marker.Position = new PointLatLng(Member.Location.Latitude, Member.Location.Longitude);
            UpdateInformation();
        }


        private void AncestorSelectorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedParent = AncestorSelectorBox.SelectedItem?.ToString();
            Member.Parent = selectedParent;
        }





        private void CreateFamilyMemberButton_Click(object sender, EventArgs e)
        {
            FamilyMember NewMember = new FamilyMember(
                Member.Family,
                Member.Name,
                Member.DateOfBirth,
                Member.Age,
                Member.Location,
                string.Join("", Member.ID),
                Member.PhotoPath,
                Member.isAlive,
                Member.DateOfDeath
                );

            if (Family.Root == null) // Root
            {
                Family.AddRoot(NewMember);
            }
                
            else // Child
            {
                Family.Members.Add(NewMember.Name, NewMember);
                Family.Members[Member.Parent].Children.Add(NewMember);
            }

            FamilyMemberCreated?.Invoke(Family);
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            Member.Name = NameTextBox.Text;
            //NameLabel.Text = $"Nombre: {Member.Nombre}";
            UpdateInformation();
        }

        private void DateofBirthPicker_ValueChanged(object sender, EventArgs e)
        {
            Member.DateOfBirth = DateofBirthPicker.Value;
            Member.Age = Generator.GenerateAge(DateTime.UtcNow.Date, DateofBirthPicker.Value);
            AgeLabel.Text = $"Edad: {Convert.ToString(Member.Age)}";
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
                    Member.PhotoPath = imagePath;
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
            Member.DateOfDeath = DateofDeathPicker.Value;
            Member.Age = Generator.GenerateAge(DateofDeathPicker.Value, DateofBirthPicker.Value);
            AgeLabel.Text = $"Edad de muerte: {Convert.ToString(Member.Age)}";
            
        }
    }
}
