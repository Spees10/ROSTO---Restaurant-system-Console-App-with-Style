using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosto
{
    internal class User : IUser
    {
        public User()
        { }

        public User(string name, string address, string phone, int branchID)
        {
            Name = name;
            Address = address;
            Phone = phone;
            BranchID = branchID;
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int BranchID { get; set; }

        public void ShowBranch(CustEmp CustChoice, Customer c)
        {
            switch (CustChoice)
            {
                #region First Choices  < Customer > , < Manager > ;

                /*       CUSTOMER        */
                case CustEmp.Customer:
                    //cus_id = Customer.GenerateID();
                    c.CreateCustomer();
                    break;
                /*       EMPLOYEE        */
                case CustEmp.Employee:
                try_User_PW_Again:
                    Console.Clear();
                    Manager Manager = new Manager();
                    Methods.TopColorfullCorners(0);
                    Methods.displayMiddleScreenNotLine("Enter Manager User Name:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string UN = Console.ReadLine();
                    Methods.LineWithColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Methods.displayMiddleScreenNotLine("Enter Manager Password:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string PW = Console.ReadLine();
                    Methods.BotColorfullCorners(0);

                    /*###  Checking Username & Password  ###*/
                    if (UN == Manager._UserName && PW == Manager._Password)
                    {
                    Manageragain:
                        List<string> ManagerChoices = new List<string> { $"Welcom {UN} (҂U_U)\u2202, Choose an Option:", "●●●●●●●●●●●●●●●●●●●●●●●●●", "❶ Create Employee ❶", "❷ Update Employee ❷", "❸ Delete Employee ❸", "❹ Show Employee ❹", "❺ Creat Food ❺", "❻ Update Food ❻", "❼ Delete Food ❼", "❽ Show Food ❽", "❾ Show Orders ❾", "❿ Exit ❿" };
                        Console.Clear();
                        Methods.displayListOfStrings(ManagerChoices);
                        MangerChoices ManagerChoice = (MangerChoices)byte.Parse(Console.ReadLine());

                        #endregion First Choices  < Customer > , < Manager > ;

                        /*###  Switch on Manager Choices ALL METHODS ###*/

                        #region Second Choices   < CRUD Employee >  , < CRUD Food > ;

                        switch (ManagerChoice)
                        {
                            /*?       CreateEmp        */
                            case MangerChoices.CreateEmp:
                                Console.Clear();
                                Manager.CreateEmp();
                                goto Manageragain;

                            /*?       UpdateEmp        */
                            case MangerChoices.UpdateEmp:
                                Console.Clear();
                                Methods.TopColorfullCorners(0);
                                Manager.UpdateEmp();
                                Methods.BotColorfullCorners(0);
                                goto Manageragain;

                            /*?       DeleteEmp        */
                            case MangerChoices.DeleteEmp:
                                Console.Clear();
                                Methods.TopColorfullCorners(0);
                                Manager.DeleteEmp();
                                Methods.BotColorfullCorners(0);
                                goto Manageragain;

                            /*?       ShowEmp        */
                            case MangerChoices.ShowEmp:
                                Console.Clear();
                                Methods.TopColorfullCorners(3);
                                Manager.ShowEmp();
                                Console.WriteLine("\n\n");
                                Methods.displayMiddleScreenNotLine("Press Any Key to Continue . . . . . \u266a");
                                Console.ReadKey();
                                Methods.BotColorfullCorners(0);
                                goto Manageragain;

                            /*?       CreateFood        */
                            case MangerChoices.CreateFood:
                                Console.Clear();
                                Methods.TopColorfullCorners(0);
                                Manager.CreatItem();
                                Methods.BotColorfullCorners(0);
                                goto Manageragain;

                            /*?       UpdateFood        */
                            case MangerChoices.UpdateFood:
                                Console.Clear();
                                Methods.TopColorfullCorners(0);
                                Manager.UpdateItem();
                                Methods.BotColorfullCorners(0);
                                goto Manageragain;

                            /*?       DeleteFood        */
                            case MangerChoices.DeleteFood:
                                Console.Clear();
                                Methods.TopColorfullCorners(0);
                                Manager.DeleteItem();
                                Methods.BotColorfullCorners(0);
                                goto Manageragain;

                            /*?       ShowFood        */
                            case MangerChoices.ShowFood:
                                Console.Clear();
                                Methods.TopColorfullCorners(0);
                                Manager.ShowItem();
                                Methods.BotColorfullCorners(0);
                                Console.ReadKey();
                                goto Manageragain;

                            /*?       ShowOrders        */
                            case MangerChoices.ShowOrders:
                                Console.Clear();
                                Methods.TopColorfullCorners(0);
                                Manager.ShowOrders();
                                Console.WriteLine("\n\n");
                                Methods.displayMiddleScreenNotLine("Press Any Key to Continue . . . . . \u266a");
                                Console.ReadKey();
                                Methods.BotColorfullCorners(0);
                                goto Manageragain;

                            case MangerChoices.Exit:
                                Methods.displayMiddleScreenNotLine("Press Any Key to Exit . . . . . \u266b");
                                Console.ReadKey();
                                Environment.Exit(0);
                                break;

                            default:
                                Console.WriteLine(". . . . WRONG CHOICE . . . . .");
                                Methods.displayMiddleScreenNotLine("Press Any Key to Try Again . . . . . \u266b");
                                Console.ReadKey();
                                goto Manageragain;
                        }
                    }

                    #endregion Second Choices   < CRUD Employee >  , < CRUD Food > ;

                    else
                    {
                        Console.Clear();
                        Methods.FullColorfullTextBars(".....invalid username or password......", 2);
                        Methods.displayMiddleScreenNotLine("Press Any Key to Exit . . . . . \u266b");
                        Console.ReadKey();
                        goto try_User_PW_Again;
                    }
                    break;

                case CustEmp.Exit:

                    Environment.Exit(0);
                    break;

                default:
                    Methods.FullColorfullTextBars("Invalid Choice!!!", 2);
                    Methods.displayMiddleScreenNotLine("Press Any Key to Exit . . . . . \u266b");
                    Console.ReadKey();
                    Methods.WelcomListCall();
                    break;
            }
        }

        public void ShowMenu(Customer c)
        {
            List<string> BranchesList = new List<string> { $"Greetings . . .", "\u1D6a\u1D6a\u1D6a\u1D6a\u1D6a\u1D6a\u1D6a\u1D6a\u1D6a\u1D6a\u1D6a", "❶ Pizza Branch ❶", "❷ Sandwitches Branch ❷", "❸ Ramen Branch ❸", "❹ Exit ❹" };
            Methods.displayListOfStrings(BranchesList);
            BranchesChoices BranchChoice = (BranchesChoices)byte.Parse(Console.ReadLine());
            Customer cus1 = new Customer();
            switch (BranchChoice)
            {
                //?                                           Pizza Menu:

                #region Pizza Branch Choices   < Pizza Menu > ;

                ///////////////////////////////// Displaying Pizza Menu:
                case BranchesChoices.PizzaBranch:
                    cus1.CreateOrder(1);
                    Console.Clear();
                pizzaAgain:

                    List<string> PizzaItems = new List<string> { "Pizza Menu:", "\u1D25\u1D25\u1D25\u1D25\u1D25\u1D25\u1D25\u1D25\u1D25\u1D25\u1D25", "❶ Peperonipi ❶", "❷ PizzaMargherita ❷", "❸ CheesyPizza ❸", "❹ SicilianPizza ❹", "❺ RostoPizza ❺", "❻ EiffelPizza ❻", "❼ Check Out ❼" };
                    Methods.displayListOfStrings(PizzaItems);
                    PizzaChoices PizzaChoice = (PizzaChoices)byte.Parse(Console.ReadLine());
                    switch (PizzaChoice)
                    {
                        case PizzaChoices.Peperonipi:
                            Methods.ItemOrder("Peperonipi");
                            Console.Clear();
                            goto pizzaAgain;

                        case PizzaChoices.PizzaMargherita:
                            Methods.ItemOrder("PizzaMargherita");
                            Console.Clear();
                            goto pizzaAgain;

                        case PizzaChoices.CheesyPizza:
                            Methods.ItemOrder("CheesyPizza");
                            Console.Clear();
                            goto pizzaAgain;

                        case PizzaChoices.SicilianPizza:
                            Methods.ItemOrder("SicilianPizza");
                            Console.Clear();
                            goto pizzaAgain;

                        case PizzaChoices.RostoPizza:
                            Methods.ItemOrder("RostoPizza");
                            Console.Clear();
                            goto pizzaAgain;

                        case PizzaChoices.EiffelPizza:
                            Methods.ItemOrder("EiffelPizza");
                            Console.Clear();
                            goto pizzaAgain;

                        case PizzaChoices.CheckOut:
                            Console.Clear();
                            c.ShowOrder();
                            Methods.displayMiddleScreenNotLine("Press Any Key to Continue . . . . . \u266b");
                            Console.ReadKey();
                            Methods.CompleteOrder();
                            break;

                        default:
                            Methods.FullColorfullTextBars("Invalid Choice!!!", 2);
                            Methods.displayMiddleScreenNotLine("Press Any Key to Try Again . . . . . \u266b");
                            Console.ReadKey();
                            goto pizzaAgain;
                    }
                    break;

                #endregion Pizza Branch Choices   < Pizza Menu > ;

                //?                                           Sandwitches Menu:

                #region Sandwitches Branch Choices < Sandwitch Menu >  ;

                case BranchesChoices.SandwitchesBranch:
                    cus1.CreateOrder(2);
                    Console.Clear();
                SandwitchAgain:

                    List<string> SandwitchesChoices = new List<string> { "Sandwitches Menu:", "\u047a\u047a\u047a\u047a\u047a\u047a\u047a\u047a\u047a\u047a\u047a\u047a", "❶ Bagel Toast ❶", "❷ Bologna Sandwitch ❷", "❸ Bánhmì ❸", "❹ Seafood Sandwich ❹", "❺ BarrosJarpa ❺", "❻ Nutella Sandwich ❻", "❼ Check Out ❼" };
                    Methods.displayListOfStrings(SandwitchesChoices);
                    SandwitchesChoices SandwitchesChoice = (SandwitchesChoices)byte.Parse(Console.ReadLine());
                    switch (SandwitchesChoice)
                    {
                        case Rosto.SandwitchesChoices.Bageltoast:
                            Methods.ItemOrder("Bagel Toast");
                            Console.Clear();
                            goto SandwitchAgain;

                        case Rosto.SandwitchesChoices.BolognaSandwich:
                            Methods.ItemOrder("Bologna Sandwitch");
                            Console.Clear();
                            goto SandwitchAgain;

                        case Rosto.SandwitchesChoices.Bánhmì:
                            Methods.ItemOrder("Bánhmì");
                            Console.Clear();
                            goto SandwitchAgain;

                        case Rosto.SandwitchesChoices.SeafoodSandwich:
                            Methods.ItemOrder("Seafood Sandwich");
                            Console.Clear();
                            goto SandwitchAgain;

                        case Rosto.SandwitchesChoices.BarrosJarpa:
                            Methods.ItemOrder("BarrosJarpa");
                            Console.Clear();
                            goto SandwitchAgain;

                        case Rosto.SandwitchesChoices.NutellaSandwich:
                            Methods.ItemOrder("Nutella Sandwich");
                            Console.Clear();
                            goto SandwitchAgain;

                        case Rosto.SandwitchesChoices.CheckOut:
                            Console.Clear();
                            c.ShowOrder();
                            Methods.displayMiddleScreenNotLine("Press Any Key to Try Continue . . . . . \u266b");
                            Console.ReadKey();
                            Methods.CompleteOrder();
                            break;

                        default:
                            Methods.FullColorfullTextBars("Invalid Choice!!!", 2);
                            Methods.displayMiddleScreenNotLine("Press Any Key to Try Again . . . . . \u266b");
                            Console.ReadKey();
                            goto SandwitchAgain;
                    }
                    break;

                #endregion Sandwitches Branch Choices < Sandwitch Menu >  ;

                //?                                           Ramen Menu:

                #region Ramen Branch Choices < Ramen Menu >  ;

                case BranchesChoices.RamenBranch:
                    cus1.CreateOrder(3);
                    Console.Clear();
                RamenAgain:

                    List<string> RamenChoices = new List<string> { "Ramen's Menu:", "\u03D4\u03D4\u03D4\u03D4\u03D4\u03D4\u03D4\u03D4\u03D4\u03D4\u03D4\u03D4\u03D4\u03D4", "❶ Shio Ramen ❶", "❷ Qena Ramen ❷", "❸ Noodles ❸", "❹ Shoyu Ramen ❹", "❺ Miso Ramen ❺", "❻ Tonkotsu Ramen ❻", "❼ Check Out ❼" };
                    Methods.displayListOfStrings(RamenChoices);
                    RamenChoices RamenChoice = (RamenChoices)byte.Parse(Console.ReadLine());
                    switch (RamenChoice)
                    {
                        case Rosto.RamenChoices.ShioRamen:
                            Methods.ItemOrder("Shio Ramen");
                            Console.Clear();
                            goto RamenAgain;
                        case Rosto.RamenChoices.QenaRamen:
                            Methods.ItemOrder("Qena Ramen");
                            Console.Clear();
                            goto RamenAgain;

                        case Rosto.RamenChoices.Noodles:
                            Methods.ItemOrder("Noodles");
                            Console.Clear();
                            goto RamenAgain;

                        case Rosto.RamenChoices.ShoyuRamen:
                            Methods.ItemOrder("Shoyu Ramen");
                            Console.Clear();
                            goto RamenAgain;

                        case Rosto.RamenChoices.MisoRamen:
                            Methods.ItemOrder("Miso Ramen");
                            Console.Clear();
                            goto RamenAgain;

                        case Rosto.RamenChoices.Tonkotsuramen:
                            Methods.ItemOrder("Tonkotsu Ramen");
                            Console.Clear();
                            goto RamenAgain;

                        case Rosto.RamenChoices.CheckOut:
                            Console.Clear();
                            c.ShowOrder();
                            Console.ReadKey();
                            Methods.CompleteOrder();
                            break;

                        default:
                            Methods.FullColorfullTextBars("Invalid Choice!!!", 2);
                            Methods.displayMiddleScreenNotLine("Press Any Key to Try Again . . . . . \u266b");
                            Console.ReadKey();
                            goto RamenAgain;
                    }
                    break;

                #endregion Ramen Branch Choices < Ramen Menu >  ;

                case BranchesChoices.Exit:
                    c.DeleteCus();
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    Methods.FullColorfullTextBars("Invalid Choice!!!", 2);
                    Methods.displayMiddleScreenNotLine("Press Any Key to Try Again . . . . . \u266b");
                    Console.ReadKey();
                    Methods.WelcomListCall();
                    break;
            }
        }
    }
}