using System.ComponentModel.DataAnnotations;

namespace Formula1API.Models
{
    public class Driver
    {
        [Key]
        public int DriverNumber { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public int Points { get; set; }
        public int Championships { get; set; }
        public string PortraitImgPath { get; set; }

        public Driver(string name, int teamId, int driverNumber, string country, int points, int championships, string portraitImgPath)
        {
            Name = name;
            TeamId = teamId;
            DriverNumber = driverNumber;
            Country = country;
            Points = points;
            Championships = championships;
            PortraitImgPath = portraitImgPath;
        }

        public Driver()
        {
            
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(TeamId)}={TeamId}, {nameof(DriverNumber)}={DriverNumber.ToString()}, {nameof(Country)}={Country}, {nameof(Points)}={Points.ToString()}, {nameof(Championships)}={Championships.ToString()}}}";
        }
    }
}
