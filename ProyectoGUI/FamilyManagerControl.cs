using ProyectoGUI.Logica;
using System;
using System.Collections.Generic;
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
            LoadFamilyTree();
        }

        private void LoadFamilyTree()
        {
            if (Family.Root != null)
            {
                PopulateTreeView(Family.Root);
            }
        }

        private void PopulateTreeView(FamilyMember rootModel)
        {
            FamilyTreeView.BeginUpdate();
            FamilyTreeView.Nodes.Clear();
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
                treeNode.Nodes.Add(CreateTreeNodeFromModel(childModel));
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

        private void FamilyTreeButton_Click(object sender, EventArgs e)
        {
            // Solo refresca o muestra el árbol
            PopulateTreeView(Family.Root);
        }

        private void FamilyStatisticsButton_Click(object sender, EventArgs e)
        {
            using (FamilyStatisticsForm statsForm = new FamilyStatisticsForm(Family))
            {
                statsForm.ShowDialog();
            }
        }

        private void ViewMapButton_Click(object sender, EventArgs e)
        {
            using (FamilyMapForm mapForm = new FamilyMapForm(Family))
            {
                mapForm.ShowDialog();
            }
        }
    }
}
