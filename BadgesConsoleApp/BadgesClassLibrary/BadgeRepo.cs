using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BadgesClassLibrary.Badge;

namespace BadgesClassLibrary
{
    public class BadgeRepo
    {
        public Dictionary<int, List<string>> _badgeRepo = new Dictionary<int, List<string>> { };


        public bool AddNewBadge(Badge newBadge)
        {
            int startingCount = _badgeRepo.Count;

            _badgeRepo.Add(newBadge.BadgeId, newBadge.AccesibleDoors);

            bool addedSuccessfully = (_badgeRepo.Count > startingCount) ? true : false;
            return addedSuccessfully;
        }

        public List<int> ShowAllBadgesId()
        {
            List<int> valuesToDisplay = new List<int>();

            foreach (var kvp in _badgeRepo)
            {
                valuesToDisplay.Add(kvp.Key);

            }
            return valuesToDisplay;
        }

        //not pretty but it should work
        public List<string> ShowBadgeById(int badgeId)
        {
            if (_badgeRepo.ContainsKey(badgeId))
            {
                List<string> listOfDoors;
                foreach(KeyValuePair<int, List<string>> kvp in _badgeRepo)
                {
                    if(kvp.Key == badgeId)
                    {
                        listOfDoors = kvp.Value;
                        return listOfDoors;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateBadge(int oldBadgeId, string doorToAdd)
        {
            int startingCount = 0;
            if (_badgeRepo.ContainsKey(oldBadgeId))
            {
                foreach (KeyValuePair<int, List<string>> kvp in _badgeRepo)
                {
                    if (kvp.Key == oldBadgeId)
                    {
                        if (!kvp.Value.Contains(doorToAdd))
                        {
                            kvp.Value.Add(doorToAdd);
                            startingCount++;
                        }
                    }
                }
            }
            if (startingCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteDoor(int oldBadgeId, string doorToAdd)
        {
            int startingCount = 0;
            if (_badgeRepo.ContainsKey(oldBadgeId))
            {
                foreach (KeyValuePair<int, List<string>> kvp in _badgeRepo)
                {
                    if (kvp.Key == oldBadgeId)
                    {
                        if (kvp.Value.Contains(doorToAdd))
                        {
                            kvp.Value.Remove(doorToAdd);
                            startingCount++;
                        }
                    }
                }
            }
            if (startingCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
