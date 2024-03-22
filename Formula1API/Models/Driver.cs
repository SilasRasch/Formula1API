using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Formula1API.Models
{
    public class Driver
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DriverNumber { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public int Points { get; set; }
        public int Championships { get; set; }
        public string PortraitImgPath { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public int TeamId { get; set; }
        public Team? Team { get; set; } = null!;

        public Driver(int driverNumber, string name, string code, string country, int points, int championships, string portraitImgPath, DateOnly dateOfBirth, int teamId)
        {
            DriverNumber = driverNumber;
            Name = name;
            Code = code;
            Country = country;
            Points = points;
            Championships = championships;
            PortraitImgPath = portraitImgPath;
            DateOfBirth = dateOfBirth;
            TeamId = teamId;
        }

        public Driver()
        {
            
        }
    }
}