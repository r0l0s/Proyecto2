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
        public event EventHandler EnterFamilyConfig;
        public FamilyDataControl()
        {
            InitializeComponent();
        }

        private void UpdateList()
        {
            AvailableFamiliesList.Items.Clear();
            foreach(var Family in FamilyTreeContainer.Families)
            {
                AvailableFamiliesList.Items.Add(Family.FamilyName);
            }
        }
        private void CreateFamilyButton_Click(object sender, EventArgs e)
        {
            string FamilyName = FamilyNameTextBox.Text;
            if (!string.IsNullOrEmpty(FamilyName))
            {
                FamilyTree NewFamily = new FamilyTree(FamilyName);
                FamilyTreeContainer.Families.Add(NewFamily);
                UpdateList();
            }
            
        }

        private void RemoveFamilyButton_Click(object sender, EventArgs e)
        {
            // Eliminates FamilyTree
        }

        private void FamilyConfigButton_Click(object sender, EventArgs e)
        {

            EnterFamilyConfig?.Invoke(this, e);
            // Creates new window for selected family configuration (Adding members, viewing the map and getting the family's statistics)
        }
    }
}
