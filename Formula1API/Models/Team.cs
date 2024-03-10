namespace Formula1API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeamColors { get; set; }
        public int Points { get; set; }
        public int WorldChampionships { get; set; }
        public string TeamChief { get; set; }
        public string LogoImgPath { get; set; }
        public IEnumerable<Driver> Drivers { get; set; } = new List<Driver>();

        public Team(int id, string name, string teamColors, int points, int worldChampionships, string teamChief, string logoImgPath, IEnumerable<Driver> drivers)
        {
            Id = id;
            Name = name;
            TeamColors = teamColors;
            Points = points;
            WorldChampionships = worldChampionships;
            TeamChief = teamChief;
            LogoImgPath = logoImgPath;
            Drivers = drivers;
        }

        public Team()
        {
            
        }
    }
}
