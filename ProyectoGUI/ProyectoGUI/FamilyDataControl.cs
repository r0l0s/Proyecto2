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
        public FamilyDataControl()
        {
            InitializeComponent();
        }

        private void CreateFamilyButton_Click(object sender, EventArgs e)
        {
            // Creates a new FamilyTree
        }

        private void RemoveFamilyButton_Click(object sender, EventArgs e)
        {
            // Eliminates FamilyTree
        }

        private void FamilyConfigButton_Click(object sender, EventArgs e)
        {
            // Creates new window for selected family configuration (Adding members, viewing the map and getting the family's statistics)
        }
    }
}
