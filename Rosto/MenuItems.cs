using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosto
{
    internal class MenuItems
    {
        public MenuItems()
        { }

        public MenuItems(string foodType, int price, int branchID)
        {
            FoodType = foodType;
            Price = price;
            BranchID = branchID;
        }

        public string FoodType { get; set; }
        public int Price { get; set; }
        public int BranchID { get; set; }
    }
}