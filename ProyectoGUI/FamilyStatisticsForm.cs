using System;
using System.Windows.Forms;
using ProyectoGUI.Logica;

namespace ProyectoGUI
{
    public partial class FamilyStatisticsForm : Form
    {
        private FamilyTree Family;
        private GeographicGraph Graph = new GeographicGraph();

        public FamilyStatisticsForm(FamilyTree family)
        {
            InitializeComponent();
            Family = family;

            LoadFamilyIntoGraph();
            ComputeStatistics();
        }

        private void LoadFamilyIntoGraph()
        {
            // Agregar todos los miembros al grafo
            foreach (var kv in Family.Members)
            {
                Graph.AddMember(kv.Value);
            }

            // También agregar Root si existe y no estaba en Members
            if (Family.Root != null)
                Graph.AddMember(Family.Root);
        }

        private void ComputeStatistics()
        {
            // Si no hay miembros suficientes en el grafo, mostrar mensaje seguro
            if (Graph == null)
            {
                FarLabel.Text = "Error: grafo no inicializado.";
                CloseLabel.Text = "";
                AvgLabel.Text = "";
                return;
            }

            var all = Graph.GetAllMembers();
            if (all == null || all.Count < 2)
            {
                FarLabel.Text = "No hay suficientes miembros para calcular estadísticas.";
                CloseLabel.Text = "Necesitan estar al menos 2 miembros.";
                AvgLabel.Text = "";
                return;
            }

            var far = Graph.FindFarthestPair();
            var close = Graph.FindClosestPair();
            var avg = Graph.CalculateAverageDistance();

            if (far == null || close == null)
            {
                FarLabel.Text = "No hay datos para calcular par más lejano o más cercano.";
                CloseLabel.Text = "No hay datos para calcular par más cercano.";
            }
            else
            {
                FarLabel.Text =
                    $"Más lejos: {far.Item1?.Name ?? "N/A"} ↔ {far.Item2?.Name ?? "N/A"}\n" +
                    $"Distancia: {far.Item3:F2} km";

                CloseLabel.Text =
                    $"Más cerca: {close.Item1?.Name ?? "N/A"} ↔ {close.Item2?.Name ?? "N/A"}\n" +
                    $"Distancia: {close.Item3:F2} km";
            }

            AvgLabel.Text = $"Distancia promedio entre familiares:\n{avg:F2} km";
        }

    }
}
