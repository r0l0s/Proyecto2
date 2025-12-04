using ProyectoGUI.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoGUI
{
    public partial class FamilyDataControl : UserControl
    {
        public delegate void EnterFamilyConfigHandler(FamilyTree Family);
        public event EnterFamilyConfigHandler? EnterFamilyConfig;
        private Dictionary<string, FamilyTree> FamiliesDictionary = new Dictionary<string, FamilyTree>();        private FamilyTree? CurrentFamSelection = null;

        public FamilyDataControl()
        {
            InitializeComponent();
        }

        private void UpdateList()
        {
            AvailableFamiliesList.Items.Clear();
            foreach (var Family in FamilyTreeContainer.Families)
            {
                AvailableFamiliesList.Items.Add(Family.Key);
            }
        }
        private void CreateFamilyButton_Click(object sender, EventArgs e)
        {
            string familyName = FamilyNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(familyName))
            {
                MessageBox.Show("Debe ingresar un nombre para la familia.");
                return;
            }

            if (FamiliesDictionary.ContainsKey(familyName))
            {
                MessageBox.Show("Esta familia ya existe.");
                return;
            }

            FamilyTree newFamily = new FamilyTree(familyName);

            FamiliesDictionary.Add(familyName, newFamily);

            AvailableFamiliesList.Items.Add(familyName);
        }


        private void RemoveFamilyButton_Click(object sender, EventArgs e)
        {
            // Eliminates FamilyTree
        }

        private void FamilyConfigButton_Click(object sender, EventArgs e)
        {
            string? sel = AvailableFamiliesList.SelectedItem?.ToString();
            if (string.IsNullOrWhiteSpace(sel))
            {
                MessageBox.Show("Seleccione una familia primero.");
                return;
            }

            if (!FamiliesDictionary.ContainsKey(sel))
            {
                MessageBox.Show("Familia no encontrada.");
                return;
            }

            var family = FamiliesDictionary[sel];
            CurrentFamSelection = family;
            EnterFamilyConfig?.Invoke(family);
        }


        private void AvailableFamiliesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AvailableFamiliesList.SelectedItem == null)
                return;

            string key = AvailableFamiliesList.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(key))
                return;

            if (!FamiliesDictionary.ContainsKey(key))
            {
                MessageBox.Show($"No se encontró la familia '{key}' en el diccionario.");
                return;
            }

            var family = FamiliesDictionary[key];

            CurrentFamSelection = family;   // ← ← ←  ESTA LÍNEA ARREGLA EL ERROR

            EnterFamilyConfig?.Invoke(family);  
        }


    }
}
