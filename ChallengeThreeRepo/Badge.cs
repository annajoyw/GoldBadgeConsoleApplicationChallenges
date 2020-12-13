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

        //public string DoorNames { get; set; }

        public string DoorA7 { get; set; }
        public string DoorA1 { get; set; }
        public string DoorA4 { get; set; }
        public string DoorB1 { get; set; }
        public string DoorB2 { get; set; }
        public string DoorA5 { get; set; }
        public string DefaultDoor { get; set; }

        public Badge() { }
        public Badge(int badgeId, string defaultDoor,string doorA1, string doorA7,string doorA4, string doorB1, string doorB2, string doorA5)
        {
            BadgeId = badgeId;
            DefaultDoor = defaultDoor;
            DoorA7 = doorA7;
            DoorA1 = doorA1;
            DoorA4 = doorA4;
            DoorB1 = doorB1;
            DoorB2 = doorB2;
            DoorA5 = doorA5;
        }
    }
   
}
