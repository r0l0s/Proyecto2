using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoGUI.Logica;
namespace ProyectoGUI.Logica
{
    public class GeographicGraph
    {
        private const double EARTH_RADIUS_KM = 6371.0;
        private List<FamilyMember> vertices;
        private Dictionary<int, List<Tuple<int, double>>> adjacencyList;
        
        public GeographicGraph()
        {
            vertices = new List<FamilyMember>();
            adjacencyList = new Dictionary<int, List<Tuple<int, double>>>();
        }
        
        // Agregar miembro al grafo
        public void AddMember(FamilyMember member)
        {
            if (member == null) return;
            
            if (!vertices.Any(v => v.ID == member.ID))
            {
                vertices.Add(member);
                adjacencyList[member.ID] = new List<Tuple<int, double>>();
                UpdateAllDistances();
            }
        }
        
        // Calcular distancia usando fórmula de Haversine
        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);
            
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
                    
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            
            return EARTH_RADIUS_KM * c;
        }
        
        private static double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }
        
        // Actualizar todas las distancias (grafo completo)
        private void UpdateAllDistances()
        {
            if (vertices.Count < 2) return;
            
            // Limpiar conexiones existentes
            foreach (var key in adjacencyList.Keys.ToList())
            {
                adjacencyList[key] = new List<Tuple<int, double>>();
            }
            
            // Calcular nuevas distancias entre todos los pares
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = i + 1; j < vertices.Count; j++)
                {
                    var member1 = vertices[i];
                    var member2 = vertices[j];
                    
                    double distance = CalculateDistance(
                        member1.Location.Latitude, member1.Location.Longitude,
                        member2.Location.Latitude, member2.Location.Longitude
                    );
                    
                    // Agregar conexión bidireccional
                    adjacencyList[member1.ID].Add(new Tuple<int, double>(member2.ID, distance));
                    adjacencyList[member2.ID].Add(new Tuple<int, double>(member1.ID, distance));
                }
            }
        }
        
        // Obtener todos los miembros
        public List<FamilyMember> GetAllMembers()
        {
            return new List<FamilyMember>(vertices);
        }
        
        // Obtener distancias desde un miembro específico
        public List<Tuple<FamilyMember, double>> GetDistancesFrom(int memberId)
        {
            var result = new List<Tuple<FamilyMember, double>>();
            
            if (!adjacencyList.ContainsKey(memberId))
                return result;
                
            foreach (var connection in adjacencyList[memberId])
            {
                var member = vertices.Find(v => v.ID == connection.Item1);
                if (member != null)
                {
                    result.Add(new Tuple<FamilyMember, double>(member, connection.Item2));
                }
            }
            
            return result.OrderBy(x => x.Item2).ToList();
        }
        
        // Encontrar par más cercano
        public Tuple<FamilyMember, FamilyMember, double> FindClosestPair()
        {
            if (vertices.Count < 2) return null;
            
            FamilyMember closest1 = null, closest2 = null;
            double minDistance = double.MaxValue;
            
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = i + 1; j < vertices.Count; j++)
                {
                    var member1 = vertices[i];
                    var member2 = vertices[j];
                    
                    var connection = adjacencyList[member1.ID]
                        .FirstOrDefault(c => c.Item1 == member2.ID);
                        
                    if (connection != null && connection.Item2 < minDistance)
                    {
                        minDistance = connection.Item2;
                        closest1 = member1;
                        closest2 = member2;
                    }
                }
            }
            
            return new Tuple<FamilyMember, FamilyMember, double>(closest1, closest2, minDistance);
        }
        
        // Encontrar par más lejano
        public Tuple<FamilyMember, FamilyMember, double> FindFarthestPair()
        {
            if (vertices.Count < 2) return null;
            
            FamilyMember farthest1 = null, farthest2 = null;
            double maxDistance = 0;
            
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = i + 1; j < vertices.Count; j++)
                {
                    var member1 = vertices[i];
                    var member2 = vertices[j];
                    
                    var connection = adjacencyList[member1.ID]
                        .FirstOrDefault(c => c.Item1 == member2.ID);
                        
                    if (connection != null && connection.Item2 > maxDistance)
                    {
                        maxDistance = connection.Item2;
                        farthest1 = member1;
                        farthest2 = member2;
                    }
                }
            }
            
            return new Tuple<FamilyMember, FamilyMember, double>(farthest1, farthest2, maxDistance);
        }
        
        // Calcular distancia promedio entre todos los miembros
        public double CalculateAverageDistance()
        {
            if (vertices.Count < 2) return 0;
            
            double totalDistance = 0;
            int pairCount = 0;
            
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = i + 1; j < vertices.Count; j++)
                {
                    var member1 = vertices[i];
                    var member2 = vertices[j];
                    
                    var connection = adjacencyList[member1.ID]
                        .FirstOrDefault(c => c.Item1 == member2.ID);
                        
                    if (connection != null)
                    {
                        totalDistance += connection.Item2;
                        pairCount++;
                    }
                }
            }
            
            return pairCount > 0 ? totalDistance / pairCount : 0;
        }
        
        // Encontrar todos los miembros dentro de un radio
        public List<Tuple<FamilyMember, double>> FindMembersWithinRadius(int centerMemberId, double radiusKm)
        {
            var result = new List<Tuple<FamilyMember, double>>();
            
            if (!adjacencyList.ContainsKey(centerMemberId))
                return result;
            
            var centerMember = vertices.Find(v => v.ID == centerMemberId);
            if (centerMember == null) return result;
            
            foreach (var connection in adjacencyList[centerMemberId])
            {
                if (connection.Item2 <= radiusKm)
                {
                    var member = vertices.Find(v => v.ID == connection.Item1);
                    if (member != null)
                    {
                        result.Add(new Tuple<FamilyMember, double>(member, connection.Item2));
                    }
                }
            }
            
            return result.OrderBy(x => x.Item2).ToList();
        }
        
        // Imprimir matriz de distancias
        public void PrintDistanceMatrix()
        {
            Console.WriteLine("\n=== MATRIZ DE DISTANCIAS (km) ===");
            Console.Write("         ");
            
            // Encabezados
            foreach (var member in vertices)
            {
                Console.Write($"{member.Name,-10}");
            }
            Console.WriteLine();
            
            // Filas
            for (int i = 0; i < vertices.Count; i++)
            {
                Console.Write($"{vertices[i].Name,-10}");
                for (int j = 0; j < vertices.Count; j++)
                {
                    if (i == j)
                    {
                        Console.Write($"{"0",-10}");
                    }
                    else
                    {
                        var connection = adjacencyList[vertices[i].ID]
                            .FirstOrDefault(c => c.Item1 == vertices[j].ID);
                        Console.Write($"{connection?.Item2:F2}{"",-8}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}