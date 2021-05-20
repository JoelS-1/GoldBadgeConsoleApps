using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesClassLibrary
{
    public class Badge
    {
        //public enum Doors { A1, A2, A3, A4, A5, B1, B2, B3, B4, B5 }

        public int BadgeId { get; set; }
        public List<string> AccesibleDoors { get; set; }

        public Badge() { }

        public Badge(int badgeId, List<string> accessibleDoors)
        {
            BadgeId = badgeId;
            AccesibleDoors = accessibleDoors;
        }
    }
}
