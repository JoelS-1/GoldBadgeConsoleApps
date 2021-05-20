using ClaimsClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsApp
{
    class ProgramUI
    {
        private ClaimRepo _repo = new ClaimRepo();

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
                   "1. See all claims\n" +
                   "2. Take care of a claim\n" +
                   "3. Enter a new claim\n" +
                   "4. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        SeeClaims();
                        break;
                    case "2":
                    case "two":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
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

        private void SeeClaims()
        {
            Console.Clear();

            Queue<Claim> allClaims = _repo.SeeAllClaims();
            int startingCount = 0;

            foreach (Claim c in allClaims)
            {
                startingCount++;
                Console.WriteLine("Claim ID: " + c.ClaimId);
                Console.WriteLine("Type is: " + c.ClaimType);
                Console.WriteLine("Description: " + c.Description);
                Console.WriteLine("Claim amount: " + c.ClaimAmount);
                Console.WriteLine("Date of accident: " + c.DateOfIncident);
                Console.WriteLine("Date of claim: " + c.DateOfClaim);
                Console.WriteLine("Claim valid: " + c.IsValid + "\n\n");
            }
            if(startingCount == 0)
            {
                Console.WriteLine("There are no claims in the system at this time");
            }
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();

            Claim nextClaim = new Claim();
            nextClaim = _repo.PeekAtNextClaim();

            if (nextClaim == null)
            {
                Console.WriteLine("There are no claims in the system at this time");
            }
            else
            {

                Console.WriteLine("Here is the next claim for you to take care of:\n");
                Console.WriteLine("Claim ID: " + nextClaim.ClaimId);
                Console.WriteLine("Type is: " + nextClaim.ClaimType);
                Console.WriteLine("Description: " + nextClaim.Description);
                Console.WriteLine("Claim amount: " + nextClaim.ClaimAmount);
                Console.WriteLine("Date of accident: " + nextClaim.DateOfIncident);
                Console.WriteLine("Date of claim: " + nextClaim.DateOfClaim);
                Console.WriteLine("Claim valid: " + nextClaim.IsValid + "\n\n");

                Console.WriteLine("Press any key to continue\n");
                Console.ReadKey();
                Console.WriteLine("Do you want to take care of this claim now? y/n?");
                Console.WriteLine("'y' Yes, this claim can be removed from the list");
                Console.WriteLine("'n' No, this claim is not ready to be removed");

                bool keepRunningDeleteMethod = true;

                while (keepRunningDeleteMethod)
                {
                    string input = Console.ReadLine();
                    switch (input.ToLower())
                    {
                        case "y":
                        case "yes":
                            bool wasDeleted = _repo.DeleteNextClaimInQueue();
                            if (wasDeleted)
                            {
                                Console.WriteLine("The claim was removed from the queue successfully");
                            }
                            else
                            {
                                Console.WriteLine("The claim was unable to be removed.");
                            }
                            keepRunningDeleteMethod = false;
                            break;
                        case "n":
                        case "no":
                            Console.WriteLine("The claim will not be removed from the list");
                            keepRunningDeleteMethod = false;
                            break;
                        default:
                            {
                                Console.WriteLine("Please enter a valid menu option");
                            }
                            break;
                    }
                }

            }
        }

        private void EnterNewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();

            Console.WriteLine("You have chosen to enter a new claim.");

            bool keepRunningClaimId = true;
            while (keepRunningClaimId)
            {
                Console.WriteLine("\nWhat is the claim id number for the new claim?");
                int claimIdInput;
                bool isInt = Int32.TryParse(Console.ReadLine(), out claimIdInput);

                if (isInt)
                {
                    newClaim.ClaimId = claimIdInput;
                    keepRunningClaimId = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

            Console.WriteLine("\nWhat is the claim type?");
            Console.WriteLine("Select a menu option\n" +
                   "1. Home\n" +
                   "2. Car\n" +
                   "3. Theft");

            bool keepRunningClaimType = true;

            while (keepRunningClaimType)
            {
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                    case "car":
                        newClaim.ClaimType = ClaimType.Car;
                        keepRunningClaimType = false;
                        break;
                    case "2":
                    case "two":
                    case "home":
                        newClaim.ClaimType = ClaimType.Home;
                        keepRunningClaimType = false;
                        break;
                    case "3":
                    case "three":
                    case "theft":
                        newClaim.ClaimType = ClaimType.Theft;
                        keepRunningClaimType = false;
                        break;
                    default:
                        {
                            Console.WriteLine("Please enter a valid menu option");
                        }
                        break;
                }
            }

            Console.WriteLine("\nWhat is the description for the new claim?");
            newClaim.Description = Console.ReadLine();


            bool keepRunningClaimAmount = true;
            while (keepRunningClaimAmount)
            {
                Console.WriteLine("\nWhat is the claim amount for the new claim?");

                double claimAmountInput;
                bool isInt = double.TryParse(Console.ReadLine(), out claimAmountInput);

                if (isInt)
                {
                    newClaim.ClaimAmount = claimAmountInput;
                    keepRunningClaimAmount = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

            Console.WriteLine("\nWhat is the date of the incident?");
            Console.WriteLine("Please enter in the following format: yyyy, mm, dd");
            newClaim.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("\nWhat is the date the claim was made?");
            Console.WriteLine("Please enter in the following format: yyyy, mm, dd");
            newClaim.DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            bool wasAddedSuccessfully = _repo.AddNewClaim(newClaim);

            Console.WriteLine("\nThis claim is valid: " + newClaim.IsValid);

            if (wasAddedSuccessfully)
            {
                Console.WriteLine("\nThe claim was added successfully");
            }
            else
            {
                Console.WriteLine("\nThe claim was not added at this time.");
            }
        }
    }
}
