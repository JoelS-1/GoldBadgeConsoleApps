using MenuRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeConsoleApp
{
    class ProgramUI
    {

        private MenuRepo _repo = new MenuRepo();

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
                    "1. Create New Menu Items\n" +
                    "2. View All Menu Items\n" +
                    "3. View Menu Item By Meal Number\n" +
                    "4. Update Existing Meal Item\n" +
                    "5. Delete Existing Meal Item\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        CreateNewMenuItem();
                        break;
                    case "2":
                    case "two":
                        DisplayAllMeals();
                        break;
                    case "3":
                        DisplayByMealNumber();
                        break;
                    case "4":
                        UpdateMeal();
                        break;
                    case "5":
                        DeleteMealItem();
                        break;
                    case "6":
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

        private void CreateNewMenuItem()
        {
            Console.Clear();
            MenuItem newItem = new MenuItem();

            //try parse to keep from crashing

            bool keepRunningMealNumber = true;
            while (keepRunningMealNumber)
            {
                Console.WriteLine("What is the meal number for the new menu item?");

                int mealNumberInput;
                bool isInt = Int32.TryParse(Console.ReadLine(), out mealNumberInput);

                if (isInt)
                {
                    newItem.MealNumber = mealNumberInput;
                    keepRunningMealNumber = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

            Console.WriteLine("What is the meal's name?");
            newItem.MealName = Console.ReadLine();
            Console.WriteLine("What is the meal's description?");
            newItem.Description = Console.ReadLine();
            Console.WriteLine("What are the ingredients contained in the new meal?");
            newItem.Ingredients = Console.ReadLine();

            bool keepRunningMealPrice = true;
            while (keepRunningMealPrice)
            {
                Console.WriteLine("What is the meal's price?");

                double priceInput;
                bool isDouble = double.TryParse(Console.ReadLine(), out priceInput);

                if (isDouble)
                {
                    newItem.Price = priceInput;
                    keepRunningMealPrice = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

            bool wasAddedSuccessfully = _repo.AddMenuItem(newItem);
            if (wasAddedSuccessfully)
            {
                Console.WriteLine("The menu item was added successfully");
            }
            else
            {
                Console.WriteLine("The menu item could not be added. Please try again.");
            }

        }

        private void DisplayAllMeals()
        {
            Console.Clear();

            List<MenuItem> allItems = _repo.GetMenuItems();

            foreach (MenuItem i in allItems)
            {
                Console.WriteLine($"Meal number: {i.MealNumber}\n" +
                    $"The meal's name is: {i.MealName}\n" +
                    $"The meal's description is: {i.Description}\n" +
                    $"The meal price is: {i.Price}\n");
            }
            Console.WriteLine("For more detailed information about each item you may use the main menu option: 'view menu item by meal number' (option 3)");
        }

        private void DisplayByMealNumber()
        {
            Console.Clear();

            bool keepRunningMealNumberSearch = true;
            while (keepRunningMealNumberSearch)
            {
                Console.WriteLine("What is the meal number for the meal you would like to search?");

                int mealNumberInput;
                bool isInt = Int32.TryParse(Console.ReadLine(), out mealNumberInput);

                if (isInt)
                {
                    MenuItem searchResult = _repo.GetMenuItemByMealNumber(mealNumberInput);

                    Console.WriteLine($"Meal number: {searchResult.MealNumber}\n" +
                   $"The meal's name is: {searchResult.MealName}\n" +
                   $"The meal's description is: {searchResult.Description}\n" +
                   $"The meal contains these ingredients: {searchResult.Ingredients}\n" +
                   $"The meal price is: {searchResult.Price}\n");

                    keepRunningMealNumberSearch = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }
        }

        private void UpdateMeal()
        {
            Console.Clear();
            Console.WriteLine("Enter the meal number of the meal you would like to update");

            int oldMealNumber = Convert.ToInt32(Console.ReadLine());
            MenuItem newMeal = new MenuItem();

            bool keepRunningMealNumber = true;

            while (keepRunningMealNumber)
            {

                Console.WriteLine("What is the meal number for the new menu item?");

                int mealNumberInput;
                bool isInt = Int32.TryParse(Console.ReadLine(), out mealNumberInput);

                if (isInt)
                {
                    newMeal.MealNumber = mealNumberInput;
                    keepRunningMealNumber = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }
            }

            Console.WriteLine("What is the meal's name?");
            newMeal.MealName = Console.ReadLine();
            Console.WriteLine("What is the meal's description?");
            newMeal.Description = Console.ReadLine();
            Console.WriteLine("What are the ingredients contained in the new meal?");
            newMeal.Ingredients = Console.ReadLine();

            bool keepRunningMealPrice = true;
            while (keepRunningMealPrice)
            {
                Console.WriteLine("What is the meal's price?");

                double priceInput;
                bool isDouble = double.TryParse(Console.ReadLine(), out priceInput);

                if (isDouble)
                {
                    newMeal.Price = priceInput;
                    keepRunningMealPrice = false;
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                }

            }

            bool wasAddedSuccessfully = _repo.UpdateMenuItem(oldMealNumber, newMeal);
            if (wasAddedSuccessfully)
            {
                Console.WriteLine("The menu item was updated successfully");
            }
            else
            {
                Console.WriteLine("The menu item could not be updated. Please ensure that the initial meal number entered is correct.");
            }
        }

        private void DeleteMealItem()
        {
            Console.Clear();
            Console.WriteLine("What is the meal number for the meal you would like to delete?");

            bool wasDeleted = _repo.DeleteMenuItemByMealNumber(Convert.ToInt32(Console.ReadLine()));
            if (wasDeleted)
            {
                Console.WriteLine("The meal was deleted successfully");
            }
            else
            {
                Console.WriteLine("The meal number you entered does not match any existing meal number");
            }
        }
    }
}