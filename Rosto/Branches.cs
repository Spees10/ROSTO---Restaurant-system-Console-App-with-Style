using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosto
{
    internal class Branches
    {
        public Branches()
        { }

        public Branches(int branchID, string branchName, string phone, string address, int managerID, int employeeID)
        {
            BranchID = branchID;
            BranchName = branchName;
            Phone = phone;
            Address = address;
            ManagerID = managerID;
            EmployeeID = employeeID;
        }

        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int ManagerID { get; set; }
        public int EmployeeID { get; set; }
    }
}