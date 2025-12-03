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

        private FamilyTree? CurrentFamSelection = null;

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
            string FamilyName = FamilyNameTextBox.Text;
            if (!string.IsNullOrEmpty(FamilyName))
            {
                FamilyTree NewFamily = new FamilyTree(FamilyName);
                FamilyTreeContainer.Families.Add(FamilyName, NewFamily);
                UpdateList();
            }

        }

        private void RemoveFamilyButton_Click(object sender, EventArgs e)
        {
            // Eliminates FamilyTree
        }

        private void FamilyConfigButton_Click(object sender, EventArgs e)
        {
            //string? famName = AvailableFamiliesList.SelectedItem?.ToString();
            EnterFamilyConfig?.Invoke(CurrentFamSelection!);

        }

        private void AvailableFamiliesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string? selectedFamilyName = AvailableFamiliesList.SelectedItem?.ToString();
            CurrentFamSelection = FamilyTreeContainer.Families[selectedFamilyName!];
        }
    }
}
