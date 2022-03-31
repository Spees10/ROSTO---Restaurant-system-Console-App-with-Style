using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosto
{
    internal class EnumChoices
    {
    }

    internal enum CustEmp : int
    {
        Customer = 1,
        Employee = 2,
        Exit = 3
    }

    internal enum BranchesChoices : byte
    {
        PizzaBranch = 1,
        SandwitchesBranch = 2,
        RamenBranch = 3,
        Exit
    }

    internal enum PizzaChoices : byte
    {
        Peperonipi = 1,
        PizzaMargherita = 2,
        CheesyPizza = 3,
        SicilianPizza = 4,
        RostoPizza = 5,
        EiffelPizza = 6,
        CheckOut
    }

    internal enum SandwitchesChoices : byte
    {
        Bageltoast = 1,
        BolognaSandwich = 2,
        Bánhmì = 3,
        SeafoodSandwich = 4,
        BarrosJarpa = 5,
        NutellaSandwich = 6,
        CheckOut
    }

    internal enum RamenChoices : byte
    {
        ShioRamen = 1,
        QenaRamen = 2,
        Noodles = 3,
        ShoyuRamen = 4,
        MisoRamen = 5,
        Tonkotsuramen = 6,
        CheckOut
    }

    internal enum MangerChoices : byte
    {
        CreateEmp = 1,
        UpdateEmp = 2,
        DeleteEmp = 3,
        ShowEmp = 4,
        CreateFood = 5,
        UpdateFood = 6,
        DeleteFood = 7,
        ShowFood = 8,
        ShowOrders = 9,
        Exit
    }
}