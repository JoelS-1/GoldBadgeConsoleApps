using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OutingsClassLibrary.Outing;

namespace OutingsClassLibrary
{
    class OutingRepo
    {
        private List<Outing> _outingRepo = new List<Outing>();

        public bool AddOuting(Outing newOuting)
        {
            int startingCount = _outingRepo.Count;

            _outingRepo.Add(newOuting);
            bool wasAdded = (_outingRepo.Count > startingCount);
            return wasAdded;
        }

        public bool UpdateOuting()

        public List<Outing> GetAllOutings()
        {
            return _outingRepo;
        }

        public double CostOfAllOutings()
        {
            double totalCost = 0;
            foreach(Outing outing in _outingRepo)
            {
                totalCost += outing.OverallTotalCost;
            }
            return totalCost;
        }

       public double CostOfEventType(EventType eventToCheck)
        {
            double totalCostOfType = 0;
            foreach(Outing outing in _outingRepo)
            {
                if(outing.TypeOfEvent == eventToCheck)
                {
                    totalCostOfType += outing.OverallTotalCost;
                }
            }
            return totalCostOfType;
        }
    }
}
