using BadgesClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BadgesClassLibrary.Badge;

namespace BadgesApp
{
    class ProgramUI
    {
        public BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("As Security Admin, What would you like to do?\n" +
                    "Select a menu option\n" +
                  "1. Add a badge\n" +
                  "2. Edit a badge\n" +
                  "3. List all Badges\n" +
                  "4. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        AddBadge();
                        break;
                    case "2":
                    case "two":
                        UpdateBadge();
                        break;
                    case "3":
                        ListAllBadgesRevised();
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

        private void AddBadge()
        {
            Console.Clear();
            Badge newBadge = new Badge();

            bool keepRunningAddBadge = true;
            while (keepRunningAddBadge)
            {
                Console.WriteLine("What is the number of the new badge?");
                int badgeIdInput;
                bool isInt = Int32.TryParse(Console.ReadLine(), out badgeIdInput);

                if (isInt)
                {
                    newBadge.BadgeId = badgeIdInput;
                    keepRunningAddBadge = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid badge number");
                }
            }

            bool keepRunningDoorAdd = true;
            List<string> doorToAdd = new List<string>();

            while (keepRunningDoorAdd)
            {
                Console.WriteLine("List a door that this badge needs acccess to:");
                doorToAdd.Add(Console.ReadLine());

                newBadge.AccesibleDoors = doorToAdd;

                Console.WriteLine("Any other doors(y/n)?");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "y":
                    case "yes":
                        break;
                    case "n":
                    case "no":
                        keepRunningDoorAdd = false;
                        break;
                    default:
                        {
                            Console.WriteLine("Please enter a valid menu option");
                        }
                        break;
                }
            }
            bool wasAdded = _badgeRepo.AddNewBadge(newBadge);
            if (wasAdded)
            {
                Console.WriteLine("The badge was added successfully");
            }
            else
            {
                Console.WriteLine("The badge could not be added at this time");
            }
        }

        private void UpdateBadge()
        {
            Console.Clear();

            bool keepRunningAddBadge = true;
            int badgeIdInput = 0;
            bool runUpdateStep = true;
            while (keepRunningAddBadge)
            {
                Console.WriteLine("What is the badge number to update?");
                bool isInt = Int32.TryParse(Console.ReadLine(), out badgeIdInput);

                if (isInt)
                {
                    keepRunningAddBadge = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid badge number");
                }
            }

            List<string> listOfDoors = _badgeRepo.ShowBadgeById(badgeIdInput);
            if (listOfDoors != null)
            {
                Console.WriteLine("The doors that badge Id: " + badgeIdInput + " has access to:");
                foreach (string door in listOfDoors)
                {
                    Console.WriteLine(door);
                }
            }
            else
            {
                Console.WriteLine("This door could not be found, please ensure that the door entered is correct and try again");
                runUpdateStep = false;
            }

            if (runUpdateStep)
            {

                bool keepRunningDoorUpdate = true;
                bool wasAdded = false;
                bool wasRemoved = false;

                while (keepRunningDoorUpdate)
                {
                    Console.WriteLine("What would you like to do?\n" +
                        "1.Remove a door\n" +
                        "2.Add a door");
                    string input = Console.ReadLine();
                    switch (input.ToLower())
                    {
                        case "1":
                        case "one":
                            Console.WriteLine("Which door would you like to remove?");
                            string doorToRemove = Console.ReadLine();
                            wasRemoved = _badgeRepo.DeleteDoor(badgeIdInput, doorToRemove);
                            keepRunningDoorUpdate = false;
                            break;
                        case "2":
                        case "two":
                            Console.WriteLine("Which door would you like to add?");
                            string doorToAdd = Console.ReadLine();
                            wasAdded = _badgeRepo.UpdateBadge(badgeIdInput, doorToAdd);
                            keepRunningDoorUpdate = false;
                            break;
                        default:
                            {
                                Console.WriteLine("Please enter a valid menu option");
                            }
                            break;
                    }
                }
                if (wasAdded || wasRemoved)
                {
                    Console.WriteLine("The door was updated successfully");
                }
                else
                {
                    Console.WriteLine("The door could not be updated at this time. Please ensure that the door number entered was correct and try again");
                }
            }
        }

        private void ListAllBadgesRevised()
        {
            Console.Clear();
            Console.WriteLine("Here is a list of all badges and the doors they have access to:");

            List<int> listOfKeys = _badgeRepo.ShowAllBadgesId();

            foreach (int key in listOfKeys)
            {
                List<string> listOfDoors = _badgeRepo.ShowBadgeById(key);

                Console.WriteLine("\nThe doors that badge Id " + key + " has access to:");
                foreach (string door in listOfDoors)
                {
                    Console.WriteLine(door);
                }
            }
        }
    }
}




