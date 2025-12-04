using ProyectoGUI.Logica;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProyectoGUI
{
    public class MemberDistanceForm : Form
    {
        private TextBox DistancesTextBox;

        public MemberDistanceForm(FamilyMember member, GeographicGraph graph)
        {
            this.Text = $"Distancias desde {member.Name}";
            this.Size = new System.Drawing.Size(300, 400);
            this.StartPosition = FormStartPosition.CenterParent;

            DistancesTextBox = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };

            this.Controls.Add(DistancesTextBox);

            LoadDistances(member, graph);
        }

        private void LoadDistances(FamilyMember member, GeographicGraph graph)
        {
            var distances = graph.GetDistancesFrom(member.ID);
            foreach (var d in distances)
            {
                DistancesTextBox.AppendText($"{d.Item1.Name}: {d.Item2:F2} km{Environment.NewLine}");
            }
        }
    }
}
