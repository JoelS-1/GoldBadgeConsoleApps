using OutingsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OutingsClassLibrary.Outing;

namespace KomodoOutingsApp
{
    class ProgramUI
    {
        private OutingRepo _repo = new OutingRepo();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option\n" +
                    "1. Display a list of all outings\n" +
                    "2. Add individual outing to list of all outings\n" +
                    "3. View total cost of all outings by category, and in total\n" +
                    "5. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        DisplayAllOutings();
                        break;
                    case "2":
                    case "two":
                        AddOuting();
                        break;
                    case "3":
                    case "three":
                        CalculateAllOutingCost();
                        break;
                    case "4":
                    case "four":
                    case "exit":
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;

                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void DisplayAllOutings()
        {
            Console.Clear();

            List<Outing> allOutings = _repo.GetAllOutings();

            foreach (Outing outing in allOutings)
            {
                Console.WriteLine($"The outing ID is: {outing.OutingId}\n" +
                    $"This outing was a: {outing.TypeOfEvent}\n" +
                    $"The number of people who attended: {outing.PeopleAtEvent}\n" +
                    $"It occured on the following date {outing.Date}\n" +
                    $"Overall cost of outing: {outing.OverallTotalCost}\n" +
                    $"Total cost per person: {outing.TotalCostPerPerson}\n");
            }
        }

        private void AddOuting()
        {
            Console.Clear();
            Outing newOuting = new Outing();

            bool keepRunningOutingId = true;
            while (keepRunningOutingId)
            {
                Console.WriteLine("What is the new outing Identifier number?");

                int outingIdInput;
                bool isInt = Int32.TryParse(Console.ReadLine(), out outingIdInput);

                if (isInt)
                {
                    newOuting.OutingId = outingIdInput;
                    keepRunningOutingId = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

            bool keepRunningEventType = true;
            while (keepRunningEventType)
            {
            Console.WriteLine("What is type of event?\n" +
                    "1. Golf\n" +
                    "2. Bowling\n" +
                    "3. Amusment Park\n" +
                    "4. Concert\n");

                string eventInput = Console.ReadLine();

                switch (eventInput)
                {
                    case "1":
                    case "one":
                        newOuting.TypeOfEvent = EventType.Golf;
                        keepRunningEventType = false;
                        break;
                    case "2":
                    case "two":
                        newOuting.TypeOfEvent = EventType.Bowling;
                        keepRunningEventType = false;
                        break;
                    case "3":
                    case "three":
                        newOuting.TypeOfEvent = EventType.AmusmentPark;
                        keepRunningEventType = false;
                        break;
                    case "4":
                    case "four":
                        newOuting.TypeOfEvent = EventType.Concert;
                        keepRunningEventType = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

            }

            Console.WriteLine("How many people attended the event?");
            newOuting.PeopleAtEvent = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("What date did this event occur on? Please enter in the following format: 'yyyy, dd, mm'");
            newOuting.Date = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("What was the overall cost of the event?");
            newOuting.OverallTotalCost = Convert.ToInt32(Console.ReadLine());

            bool wasAddedSuccessfully = _repo.AddOuting(newOuting);
            if (wasAddedSuccessfully)
            {
                Console.WriteLine("The outing was added successfully");
            }
            else
            {
                Console.WriteLine("The outing could not be added. Please try again.");
            }
        }

        private void CalculateAllOutingCost()
        {
            Console.Clear();

            double totalCost = _repo.CostOfAllOutings();
            Console.WriteLine("The total cost of all outings is: " + totalCost);

            double totalCostGolf = _repo.CostOfEventType(EventType.Golf);
            Console.WriteLine("The total cost of all golf outings is: " + totalCostGolf);

            double totalCostBowling = _repo.CostOfEventType(EventType.Bowling);
            Console.WriteLine("The total cost of all golf outings is: " + totalCostBowling);

            double totalCostAmusment = _repo.CostOfEventType(EventType.AmusmentPark);
            Console.WriteLine("The total cost of all golf outings is: " + totalCostAmusment);

            double totalCostConcert = _repo.CostOfEventType(EventType.Concert);
            Console.WriteLine("The total cost of all golf outings is: " + totalCostConcert);
        }
    }
}
