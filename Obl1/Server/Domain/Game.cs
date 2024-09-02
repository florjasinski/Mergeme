using System;
using Server.Domain;

namespace Server.Domain
{
    public class Game
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }
        public int AvailableUnits { get; set; }
        public string CoverImagePath { get; set; }

        public List<Rating> Ratings { get; set; }

        public Game()
        {
            Ratings = new List<Rating>();
        }

        public override bool Equals(object obj)
        {
            return obj is Game && Title == ((Game)obj).Title;
        }
    }





}
