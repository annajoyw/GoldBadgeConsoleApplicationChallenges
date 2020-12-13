using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class BadgeRepo
    {
        public List<string> _doorNames = new List<string>();
        Dictionary<int, Badge> badgeDictionary = new Dictionary<int, Badge>();
        //Dictionary<int, Badge> badgeDictionary = new Dictionary<int, Badge>();
        public Dictionary<int, Badge> badgeInfoDictionary()
        {
            //below are objects created for the dictionary 
            Badge badge1 = new Badge()
            {
                BadgeId = 12345,
                DoorA7 = "Door A7"
            };
            Badge badge2 = new Badge()
            {
                BadgeId = 22345,
                DoorA1 = "Door A1",
                DoorA4 = "Door A4",
                DoorB1 = "Door B1",
                DoorB2 = "Door B2"
            };
            Badge badge3 = new Badge()
            {
                BadgeId = 32345,
                DoorA4 = "Door A4",
                DoorA5 = "Door A5",
            };

            Dictionary<int, Badge> badgeDictionary = new Dictionary<int, Badge>();
            badgeDictionary.Add(12345, badge1);
            badgeDictionary.Add(22345, badge2);
            badgeDictionary.Add(32345, badge3);
            return badgeDictionary;


        }

        public void addNewBadge(Badge badge)
        {
            
           badgeDictionary.Add(badge.BadgeId, badge);

           // (newBadge.BadgeId, newBadge.DefaultDoor, newBadge.DoorA1, newBadge.DoorA4, newBadge.DoorA5, newBadge.DoorA7, newBadge.DoorB1, newBadge.DoorB2)
        }


    }

   // public void addNewDoor(string newDoor)
       /* {
            //adds new door to _doorNames list
            _doorNames.Add(newDoor);
            //the following are door names that were provided in challenge info
            _doorNames.Add("A7");
            _doorNames.Add("A1");
            _doorNames.Add("A4");
            _doorNames.Add("B1");
            _doorNames.Add("B2");
            _doorNames.Add("A4");
            _doorNames.Add("A5");
        }*/

        //create create new badge
       // public Dictionary createNewBadge(Badge badge)
       // {
       //     badgeDictionary.Add(badge);
       // }
        //update doors on existing badge

        //delete all doors from existing badge

        //show list of all badge numbers & door access
    
    
}
