using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Domain
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public override bool Equals(object obj)
        {
            return obj is User && UserName == ((User)obj).UserName;
        }
        
    }
}
