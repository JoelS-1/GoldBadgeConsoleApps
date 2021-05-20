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

        public EventType TypeOfEvent { get; set; }
        public int PeopleAtEvent { get; set; }
        public DateTime Date { get; set; }
        public double TotalCostPerPerson { get; set; }
        public double OverallTotalCost
        {
            get
            {
                return TotalCostPerPerson * PeopleAtEvent;
            }
        }

        public Outing(EventType typeOfEvent, int peopleAtEvent, DateTime date, double totalCostPerPerson)
        {
            TypeOfEvent = typeOfEvent;
            PeopleAtEvent = peopleAtEvent;
            Date = date;
            TotalCostPerPerson = totalCostPerPerson;
        }

    }
}
