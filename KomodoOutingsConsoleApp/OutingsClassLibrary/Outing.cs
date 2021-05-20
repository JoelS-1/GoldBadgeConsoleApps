using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingsClassLibrary
{
    public class Outing
    {
        public enum EventType { Golf, Bowling, AmusmentPark, Concert}

        public int OutingId { get; set; }
        public EventType TypeOfEvent { get; set; }
        public int PeopleAtEvent { get; set; }
        public DateTime Date { get; set; }
        public double OverallTotalCost { get; set; }
        public double TotalCostPerPerson
        {
            get
            {
                return OverallTotalCost / PeopleAtEvent;
            }
        }

        public Outing() { }

        public Outing(int outingId, EventType typeOfEvent, int peopleAtEvent, DateTime date, double overallTotalCost)
        {
            TypeOfEvent = typeOfEvent;
            PeopleAtEvent = peopleAtEvent;
            Date = date;
            OverallTotalCost = overallTotalCost;
        }
    }
}
