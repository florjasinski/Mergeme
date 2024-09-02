using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class Rating
    {
        public User User { get; set; } 
        public int Score { get; set; }  
        public string Comment { get; set; } 

        public Rating(int score, string comment)
        {
            
            Score = score;
            Comment = comment;
        }
    }
}
