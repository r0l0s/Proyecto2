using Xunit;
using ProyectoGUI;  // ← Namespace de tu proyecto principal

namespace PruebasUnitarias
{
    public class FamilyMemberTests
    {
        [Fact]
        public void Test1_FamilyMember_CreacionCorrecta()
        {
            // Arrange & Act
            var member = new FamilyMember
            {
                Id = 1,
                Name = "Juan Pérez",
                IdNumber = "1-1234-5678",
                BirthDate = new DateTime(1990, 5, 15),
                DeathDate = null,
                Latitude = 9.9281,
                Longitude = -84.0907,
                FamilyName = "Familia Pérez"
            };
            
            // Assert
            Assert.Equal(1, member.Id);
            Assert.Equal("Juan Pérez", member.Name);
            Assert.Equal("1-1234-5678", member.IdNumber);
            Assert.Equal(new DateTime(1990, 5, 15), member.BirthDate);
            Assert.Null(member.DeathDate);
            Assert.Equal(9.9281, member.Latitude);
            Assert.Equal(-84.0907, member.Longitude);
            Assert.Equal("Familia Pérez", member.FamilyName);
        }
        
        [Fact]
        public void Test2_FamilyMember_EdadCalculoCorrecto()
        {
            // Arrange
            var birthDate = DateTime.Now.AddYears(-25).AddMonths(-6);
            var member = new FamilyMember
            {
                Id = 1,
                Name = "María",
                IdNumber = "2-8765-4321",
                BirthDate = birthDate,
                DeathDate = null,
                FamilyName = "Familia Rodríguez"
            };
            
            // Act
            int edad = member.Age;
            
            // Assert
            Assert.Equal(25, edad);
        }
        
        [Fact]
        public void Test3_FamilyMember_EdadSiFallecido()
        {
            // Arrange
            var member = new FamilyMember
            {
                Id = 1,
                Name = "Carlos",
                IdNumber = "3-1111-2222",
                BirthDate = new DateTime(1980, 1, 1),
                DeathDate = new DateTime(2010, 1, 1),
                FamilyName = "Familia López"
            };
            
            // Act
            int edad = member.Age;
            
            // Assert
            Assert.Equal(30, edad);
        }
        
        [Fact]
        public void Test4_FamilyMember_IsAlivePropiedad()
        {
            // Arrange
            var vivo = new FamilyMember
            {
                Id = 1,
                Name = "Ana",
                BirthDate = new DateTime(1995, 3, 20),
                DeathDate = null
            };
            
            var fallecido = new FamilyMember
            {
                Id = 2,
                Name = "Pedro",
                BirthDate = new DateTime(1970, 7, 10),
                DeathDate = new DateTime(2020, 12, 25)
            };
            
            // Act & Assert
            Assert.True(vivo.IsAlive);
            Assert.False(fallecido.IsAlive);
        }
    }
}