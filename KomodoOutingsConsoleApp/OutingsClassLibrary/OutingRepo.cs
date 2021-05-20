using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OutingsClassLibrary.Outing;

namespace OutingsClassLibrary
{
    public class OutingRepo
    {
        private List<Outing> _outingRepo = new List<Outing>();

        public bool AddOuting(Outing newOuting)
        {
            int startingCount = _outingRepo.Count;

            _outingRepo.Add(newOuting);
            bool wasAdded = (_outingRepo.Count > startingCount);
            return wasAdded;
        }

        //public Outing GetOutingByIdentifier(int outingId)
        //{
        //    foreach (Outing outing in _outingRepo)
        //    {
        //        if (outingId == outing.OutingId)
        //        {
        //            return outing;
        //        }
        //    }
        //    return null;
        //}

        //public bool UpdateOuting(int outingId, Outing updatedOuting)
        //{
        //    Outing outingToUpdate = GetOutingByIdentifier(outingId);
        //    if (outingToUpdate != null)
        //    {
        //        outingToUpdate.OutingId = updatedOuting.OutingId;
        //        outingToUpdate.TypeOfEvent = updatedOuting.TypeOfEvent;
        //        outingToUpdate.PeopleAtEvent = updatedOuting.PeopleAtEvent;
        //        outingToUpdate.Date = updatedOuting.Date;
        //        outingToUpdate.OverallTotalCost = updatedOuting.OverallTotalCost;
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        public List<Outing> GetAllOutings()
        {
            return _outingRepo;
        }

        //public bool DeleteOuting(int outingId)
        //{
        //    int startingCount = _outingRepo.Count;

        //    Outing outingToDelete = GetOutingByIdentifier(outingId);
        //    _outingRepo.Remove(outingToDelete);

        //    bool wasRemoved = (_outingRepo.Count < startingCount);
        //    return wasRemoved;
        //}

        public double CostOfAllOutings()
        {
            double totalCost = 0;
            foreach (Outing outing in _outingRepo)
            {
                totalCost += outing.OverallTotalCost;
            }
            return totalCost;
        }

        public double CostOfEventType(EventType eventToCheck)
        {
            double totalCostOfType = 0;
            foreach (Outing outing in _outingRepo)
            {
                    if (outing.TypeOfEvent == eventToCheck)
                    {
                        totalCostOfType += outing.OverallTotalCost;
                    }
            }
            return totalCostOfType;
        }
    }
}
