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
            Family = family;
            foreach(KeyValuePair<string,FamilyMember> kvp in Family.Members)
            {
                Debug.WriteLine($"{kvp.Key}");
            }

            

            InitializeComponent();

            if (Family.Root != null)
                PopulateTreeView(Family.Root);
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
            // View the family's statistics as per required
        }


    }
}
