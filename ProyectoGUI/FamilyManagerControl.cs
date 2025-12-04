using ProyectoGUI.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProyectoGUI
{
    public partial class FamilyManagerControl : UserControl
    {

        public delegate void EnterAddMemberHandler(FamilyTree Family);
        public event EnterAddMemberHandler? AddMember;

        private FamilyTree Family;
        public FamilyManagerControl(FamilyTree family)
        {
            if (family == null)
                throw new ArgumentNullException(nameof(family));

            Family = family;
            InitializeComponent();
        }



        private void PopulateTreeView(FamilyMember rootModel)
        {
            FamilyTreeView.BeginUpdate();
            var rootNode = CreateTreeNodeFromModel(rootModel);
            FamilyTreeView.Nodes.Add(rootNode);
            FamilyTreeView.EndUpdate();
            FamilyTreeView.ExpandAll();
        }

        private TreeNode CreateTreeNodeFromModel(FamilyMember modelNode)
        {
            var treeNode = new TreeNode(modelNode.Name)
            {
              
                Tag = modelNode
            };

            foreach (var childModel in modelNode.Children)
            {
                var childTreeNode = CreateTreeNodeFromModel(childModel);
                treeNode.Nodes.Add(childTreeNode);
            }
            return treeNode;
        }



        private void FamilyManagerControl_Load(object sender, EventArgs e)
        {
            SelectedFamilyLabel.Text = $"Familia {Family.FamilyName}";

            // Si ya existe un root, poblar el TreeView para mostrar miembros
            FamilyTreeView.Nodes.Clear();
            if (Family.Root != null)
            {
                PopulateTreeView(Family.Root);
            }
        }


        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            AddMember?.Invoke(Family);
        }

        private void ViewMapButton_Click(object sender, EventArgs e)
        {
            // Enter the world map to view graphs
        }

        private void FamilyTreeButton_Click(object sender, EventArgs e)
        {
            // View the FamilyTree data structure
        }

        private void FamilyStatisticsButton_Click(object sender, EventArgs e)
        {
            FamilyStatisticsForm statsForm = new FamilyStatisticsForm(Family);
            statsForm.ShowDialog();
        }


    }
}
