using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class BadgeRepo
    {
        //public List<string> _doorNames = new List<string>();
        ///Dictionary<int, Badge> badgeDictionary = new Dictionary<int, Badge>();
        Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();
        

        public Dictionary<int, Badge> badgeInfoDictionary()
        {
            //below are objects created for the dictionary 
            
            Badge badge1 = new Badge()
            {
                BadgeId = 12345,
                ListOfDoors="A1"

                
            };
            Badge badge2 = new Badge()
            {
                BadgeId = 22345,
                ListOfDoors="A1",
                ListOfDoors="A4",
                ListOfDoors="B1",
                ListOfDoors="B2"
        
            };
            Badge badge3 = new Badge()
            {
                BadgeId = 32345,
                ListOfDoors=
               
            };
            //accessing _badgedictionary to add data to
            Dictionary<int, Badge> badgeDictionary = _badgeDictionary;
            badgeDictionary.Add(12345, badge1);
            badgeDictionary.Add(22345, badge2);
            badgeDictionary.Add(32345, badge3);
            return badgeDictionary;
        }
        

        public void addBadgeToDictionary(Badge badge)
        {    
           _badgeDictionary.Add(badge.BadgeId, badge);
        }

        public Dictionary<int, Badge> seeAllBadges()
        {
            return _badgeDictionary;
        }

        public bool updateExistingBadge(int originalBadge, Badge newBadge)
        {
            Badge oldBadge = getBadgeByID(originalBadge);
            if(oldBadge != null)
            {
                oldBadge.BadgeId = newBadge.BadgeId;
                oldBadge.ListOfDoors = newBadge.ListOfDoors;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteAllDoorsFromBadge(int id)
        {
            Badge badge = getBadgeByID(id);
            if(badge == null)
            {
                return false;
            }
            int initialCount = _badgeDictionary.Count;
            _badgeDictionary.Remove(badge.BadgeId);
            if(initialCount> _badgeDictionary.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //helper method
        public Badge getBadgeByID(int idNum)
        {
            foreach(var badge in _badgeDictionary)
            {
                if (badge.Key== idNum)
                {
                    return badge.Value;
                }
            }
            return null;
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
