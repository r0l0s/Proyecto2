using System;
using System.Collections.Generic;

namespace GraphTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== PRUEBAS DEL GRAFO GENEALÓGICO ===\n");
            
            // Crear grafo
            var graph = new GeographicGraph();
            
            // Datos de ejemplo (coordenadas reales de Costa Rica)
            var juan = new FamilyMember(1, "Juan", 9.9281, -84.0907);      // San José
            var maria = new FamilyMember(2, "María", 10.0163, -84.2116);   // Alajuela
            var carlos = new FamilyMember(3, "Carlos", 9.8644, -83.9194);  // Cartago
            var ana = new FamilyMember(4, "Ana", 10.0022, -84.1165);       // Heredia
            var luis = new FamilyMember(5, "Luis", 9.9760, -84.8384);      // Puntarenas
            var sofia = new FamilyMember(6, "Sofía", 9.9901, -83.0390);    // Limón
            
            // Agregar miembros al grafo
            Console.WriteLine("Agregando miembros al grafo...");
            graph.AddMember(juan);
            graph.AddMember(maria);
            graph.AddMember(carlos);
            graph.AddMember(ana);
            graph.AddMember(luis);
            graph.AddMember(sofia);
            
            // Mostrar todos los miembros
            Console.WriteLine("\n=== MIEMBROS REGISTRADOS ===");
            foreach (var member in graph.GetAllMembers())
            {
                Console.WriteLine($"  {member}");
            }
            
            // Calcular distancias desde un miembro específico
            Console.WriteLine("\n=== DISTANCIAS DESDE JUAN ===");
            var distancesFromJuan = graph.GetDistancesFrom(1);
            foreach (var dist in distancesFromJuan)
            {
                Console.WriteLine($"  → {dist.Item1.Name}: {dist.Item2:F2} km");
            }
            
            // Encontrar par más cercano
            var closest = graph.FindClosestPair();
            if (closest != null)
            {
                Console.WriteLine($"\n=== PAR MÁS CERCANO ===");
                Console.WriteLine($"  {closest.Item1.Name} y {closest.Item2.Name}");
                Console.WriteLine($"  Distancia: {closest.Item3:F2} km");
            }
            
            // Encontrar par más lejano
            var farthest = graph.FindFarthestPair();
            if (farthest != null)
            {
                Console.WriteLine($"\n=== PAR MÁS LEJANO ===");
                Console.WriteLine($"  {farthest.Item1.Name} y {farthest.Item2.Name}");
                Console.WriteLine($"  Distancia: {farthest.Item3:F2} km");
            }
            
            // Calcular distancia promedio
            double averageDistance = graph.CalculateAverageDistance();
            Console.WriteLine($"\n=== DISTANCIA PROMEDIO ===");
            Console.WriteLine($"  {averageDistance:F2} km");
            
            // Encontrar miembros dentro de un radio
            Console.WriteLine($"\n=== FAMILIARES A MENOS DE 30 KM DE JUAN ===");
            var within30km = graph.FindMembersWithinRadius(1, 30);
            if (within30km.Count > 0)
            {
                foreach (var member in within30km)
                {
                    Console.WriteLine($"  → {member.Item1.Name}: {member.Item2:F2} km");
                }
            }
            else
            {
                Console.WriteLine("  No hay familiares dentro de 30 km");
            }
            
            // Matriz de distancias
            graph.PrintDistanceMatrix();
            
            // Prueba con coordenadas internacionales
            Console.WriteLine("\n\n=== PRUEBA CON COORDENADAS INTERNACIONALES ===");
            
            var internationalGraph = new GeographicGraph();
            
            // Coordenadas reales
            var ny = new FamilyMember(10, "Nueva York", 40.7128, -74.0060);
            var paris = new FamilyMember(11, "París", 48.8566, 2.3522);
            var tokyo = new FamilyMember(12, "Tokio", 35.6762, 139.6503);
            
            internationalGraph.AddMember(ny);
            internationalGraph.AddMember(paris);
            internationalGraph.AddMember(tokyo);
            
            Console.WriteLine($"\nDistancia NY-París: {GeographicGraph.CalculateDistance(ny.Latitude, ny.Longitude, paris.Latitude, paris.Longitude):F2} km");
            Console.WriteLine($"Distancia NY-Tokio: {GeographicGraph.CalculateDistance(ny.Latitude, ny.Longitude, tokyo.Latitude, tokyo.Longitude):F2} km");
            Console.WriteLine($"Distancia París-Tokio: {GeographicGraph.CalculateDistance(paris.Latitude, paris.Longitude, tokyo.Latitude, tokyo.Longitude):F2} km");
            
            Console.WriteLine("\n=== TODAS LAS PRUEBAS COMPLETADAS ===");
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}