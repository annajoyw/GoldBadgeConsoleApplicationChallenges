using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class Badge
    {
        //public List<string> _doorNames = new List<string>();
        
        public int BadgeId { get; set; }
        public List<string> ListOfDoors { get; set; } = new List<string>();
        

        public Badge() { }
        public Badge(int badgeId, List<string>_ListOfDoors)
        {
            BadgeId = badgeId;
            ListOfDoors = ListOfDoors;
        }
    }
   
}
