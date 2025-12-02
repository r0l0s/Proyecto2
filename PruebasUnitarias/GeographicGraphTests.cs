using Xunit;
using ProyectoGUI;  // ← Namespace de tu proyecto principal

namespace PruebasUnitarias
{
    public class GeographicGraphTests
    {
        [Fact]
        public void Test5_GeographicGraph_AgregarMiembro()
        {
            // Arrange
            var graph = new GeographicGraph();
            var member = new FamilyMember
            {
                Id = 1,
                Name = "Juan",
                Latitude = 9.9281,
                Longitude = -84.0907
            };
            
            // Act
            graph.AddMember(member);
            var allMembers = graph.GetAllMembers();
            
            // Assert
            Assert.Single(allMembers);
            Assert.Equal("Juan", allMembers[0].Name);
        }
        
        [Fact]
        public void Test6_GeographicGraph_DistanciaEntreDosPuntos()
        {
            // Arrange
            // San José y Alajuela (distancia real ~18.5 km)
            double lat1 = 9.9281, lon1 = -84.0907;  // San José
            double lat2 = 10.0163, lon2 = -84.2116; // Alajuela
            
            // Act
            double distancia = GeographicGraph.CalculateDistance(lat1, lon1, lat2, lon2);
            
            // Assert
            Assert.True(distancia > 15 && distancia < 22);
            Assert.Equal(18.5, distancia, 1); // 18.5 ± 0.1 km
        }
        
        [Fact]
        public void Test7_GeographicGraph_ParMasCercano()
        {
            // Arrange
            var graph = new GeographicGraph();
            
            var a = new FamilyMember { Id = 1, Name = "A", Latitude = 9.9, Longitude = -84.1 };
            var b = new FamilyMember { Id = 2, Name = "B", Latitude = 9.91, Longitude = -84.11 };
            var c = new FamilyMember { Id = 3, Name = "C", Latitude = 10.5, Longitude = -85.0 };
            
            graph.AddMember(a);
            graph.AddMember(b);
            graph.AddMember(c);
            
            // Act
            var closest = graph.FindClosestPair();
            
            // Assert
            Assert.NotNull(closest);
            Assert.Equal("A", closest.Item1.Name);
            Assert.Equal("B", closest.Item2.Name);
            Assert.True(closest.Item3 > 0);
        }
        
        [Fact]
        public void Test8_GeographicGraph_ParMasLejano()
        {
            // Arrange
            var graph = new GeographicGraph();
            
            var a = new FamilyMember { Id = 1, Name = "San José", Latitude = 9.9281, Longitude = -84.0907 };
            var b = new FamilyMember { Id = 2, Name = "Limón", Latitude = 9.9901, Longitude = -83.0390 };
            var c = new FamilyMember { Id = 3, Name = "Puntarenas", Latitude = 9.9760, Longitude = -84.8384 };
            
            graph.AddMember(a);
            graph.AddMember(b);
            graph.AddMember(c);
            
            // Act
            var farthest = graph.FindFarthestPair();
            
            // Assert
            Assert.NotNull(farthest);
            Assert.True(farthest.Item3 > 100); // Más de 100 km
        }
        
        [Fact]
        public void Test9_GeographicGraph_DistanciaPromedio()
        {
            // Arrange
            var graph = new GeographicGraph();
            
            var a = new FamilyMember { Id = 1, Name = "A", Latitude = 10.0, Longitude = -84.0 };
            var b = new FamilyMember { Id = 2, Name = "B", Latitude = 10.1, Longitude = -84.0 };
            var c = new FamilyMember { Id = 3, Name = "C", Latitude = 10.05, Longitude = -84.1 };
            
            graph.AddMember(a);
            graph.AddMember(b);
            graph.AddMember(c);
            
            // Act
            double promedio = graph.CalculateAverageDistance();
            
            // Assert
            Assert.True(promedio > 0);
        }
        
        [Fact]
        public void Test10_GeographicGraph_MiembrosEnRadio()
        {
            // Arrange
            var graph = new GeographicGraph();
            
            var centro = new FamilyMember { Id = 1, Name = "Centro", Latitude = 10.0, Longitude = -84.0 };
            var cerca1 = new FamilyMember { Id = 2, Name = "Cerca1", Latitude = 10.01, Longitude = -84.01 };
            var cerca2 = new FamilyMember { Id = 3, Name = "Cerca2", Latitude = 10.02, Longitude = -84.02 };
            var lejos = new FamilyMember { Id = 4, Name = "Lejos", Latitude = 10.1, Longitude = -84.1 };
            
            graph.AddMember(centro);
            graph.AddMember(cerca1);
            graph.AddMember(cerca2);
            graph.AddMember(lejos);
            
            // Act
            var dentroDe10km = graph.FindMembersWithinRadius(1, 10);
            
            // Assert
            Assert.Equal(2, dentroDe10km.Count);
            Assert.Contains(dentroDe10km, m => m.Item1.Name == "Cerca1");
            Assert.Contains(dentroDe10km, m => m.Item1.Name == "Cerca2");
        }
    }
}