namespace Formula1API.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoImgPath { get; set; }
        //public List<Driver>? Drivers { get; set; }
        public string TeamColors { get; set; }
        public int Points { get; set; }
        public int WorldChampionships { get; set; }
        public string TeamChief { get; set; }

        public Team(string name, string logoImgPath, string teamColors, int points, int worldChampionships, string teamChief)
        {
            Name = name;
            LogoImgPath = logoImgPath;
            //Drivers = new List<Driver>();
            TeamColors = teamColors;
            Points = points;
            WorldChampionships = worldChampionships;
            TeamChief = teamChief;
        }

        public Team()
        {
            
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(LogoImgPath)}={LogoImgPath}, {nameof(TeamColors)}={TeamColors}, {nameof(Points)}={Points.ToString()}, {nameof(WorldChampionships)}={WorldChampionships.ToString()}, {nameof(TeamChief)}={TeamChief}}}";
        }
    }
}
