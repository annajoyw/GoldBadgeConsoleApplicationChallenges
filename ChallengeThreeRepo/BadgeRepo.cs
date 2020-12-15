using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeThreeRepo
{
    public class BadgeRepo
    {
        
        public Dictionary<int, Badge> _badgeDictionary = new Dictionary<int, Badge>();
        public void AddBadgeToDictionary(Badge badge)
        {    
           _badgeDictionary.Add(badge.BadgeId, badge);
        }

        public Dictionary<int, Badge> SeeAllBadges()
        {
            return _badgeDictionary;
        }

        public bool UpdateExistingBadge(int originalBadge, Badge newBadge)
        {
            Badge oldBadge = GetBadgeByID(originalBadge);
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

        public bool DeleteBadge(int id)
        {
            Badge badge = GetBadgeByID(id);
            
            if(badge.BadgeId != id)
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
        public Badge GetBadgeByID(int idNum)
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

}
