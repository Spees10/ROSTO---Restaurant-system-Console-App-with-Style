using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosto
{
    internal interface IUser
    {
        void ShowBranch(CustEmp CustChoice, Customer c);

        void ShowMenu(Customer c);
    }
}