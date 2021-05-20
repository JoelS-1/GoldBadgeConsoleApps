using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuRepository
{
    public class MenuRepo
    {
        //we will store all added menu items to this list or later reference
        private List<MenuItem> _menuDirectory = new List<MenuItem>();

        public bool AddMenuItem(MenuItem newMenuItem)
        {
            //takes initial count of the list
            int startingCount = _menuDirectory.Count;

            //adds menu item to list
            _menuDirectory.Add(newMenuItem);

            //checks current list count agains initial count of list
            bool addedSuccessfully = (_menuDirectory.Count > startingCount) ? true : false;
            return addedSuccessfully;
        }

        public List<MenuItem> GetMenuItems()
        {
            return _menuDirectory;
        }

        public MenuItem GetMenuItemByMealNumber(int mealNumber)
        {
            foreach(MenuItem m in _menuDirectory)
            {
                if(mealNumber == m.MealNumber)
                {
                    return m;
                }
            }
            return null;
        }

        public bool UpdateMenuItem(int mealNumber, MenuItem menuItem)
        {
            MenuItem mealToUpdate = GetMenuItemByMealNumber(mealNumber);

            if(mealToUpdate == null)
            {
                return false;
            }
            else
            {
                mealToUpdate.MealNumber = menuItem.MealNumber;
                mealToUpdate.MealName = menuItem.MealName;
                mealToUpdate.Description = menuItem.Description;
                mealToUpdate.Ingredients = menuItem.Ingredients;
                mealToUpdate.Price = menuItem.Price;

                return true;
            }
        }

        public bool DeleteMenuItemByMealNumber(int mealNumber)
        {
            int startingCount = _menuDirectory.Count;

            MenuItem mealToDelete = GetMenuItemByMealNumber(mealNumber);

            _menuDirectory.Remove(mealToDelete);

            bool addedSuccessfully = (_menuDirectory.Count < startingCount) ? true : false;
            return addedSuccessfully;
        }
    }
}
