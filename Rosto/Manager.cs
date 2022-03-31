using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Rosto
{
    internal class Manager : User
    {
        public Manager()
        {
            Password = "xcv"; UserName = "asd";
        }

        private string UserName;

        public string _UserName
        {
            get { return UserName; }
            set { UserName = "asd"; }
        }

        private string Password;

        public string _Password
        {
            get { return Password; }
            set { Password = "xcv"; }
        }

        #region Methods:

        public void CreateEmp()
        {
            try
            {
                string connetionString = @"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connetionString);
                SqlCommand command = cnn.CreateCommand();
                cnn.Open();

                if (cnn.State == ConnectionState.Open)
                {
                    Employees emp = new Employees();
                    Console.Clear();
                    Methods.TopColorfullCorners(1);

                    Methods.displayMiddleScreenNotLine("Enter Employee Full Name: ");
                    emp.Name = Console.ReadLine();
                    Methods.LineWithColor();

                    Methods.displayMiddleScreenNotLine($"Enter {emp.Name}'s Address: ");
                    emp.Address = Console.ReadLine();
                    Methods.LineWithColor();

                PhoneAgain:
                    Methods.displayMiddleScreenNotLine("Enter Mobile: ");
                    emp.Phone = Console.ReadLine();
                    if (!Methods.IsValidPhone(emp.Phone))
                    {
                        goto PhoneAgain;
                    }
                    Methods.LineWithColor();

                    Methods.displayMiddleScreenNotLine("Enter Salary: ");
                    emp.Salary = decimal.Parse(Console.ReadLine());
                    Methods.LineWithColor();

                    Methods.displayMiddleScreenNotLine("Enter BranchID : ");
                    emp.BranchID = int.Parse(Console.ReadLine());
                    Methods.BotColorfullCorners(1);
                    Console.Clear();

                    command.CommandText = $"INSERT INTO Employee VALUES ({Employees.GenerateID()},'{emp.Name}','{emp.Address}','{emp.Phone}',{emp.BranchID},{emp.Salary})";
                    command.ExecuteNonQuery();

                    List<string> InsertedData = new List<string> { $"{emp.Name}'s Inserted Data:\u0489 ID \u25BA {""} \u25CC Name \u25BA {emp.Name} \u25CC Address \u25BA {emp.Address} \u25CC Phone \u25BA {emp.Phone} \u25CC Branch ID \u25BA {emp.BranchID} \u25CC Salary \u25BA {emp.Salary} \u0489" };
                    Methods.displayListOfStrings(InsertedData);

                ChooseYesOrNoAgain:
                    Methods.displayMiddleScreen($"Do you need to CHANGE Anything of {emp.Name}'s Data?");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Methods.displayMiddleScreen("\u201f 1 for Accept \u201e / \u201f 2 for Decline \u201e");
                    Methods.LineWithColor();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    int ChangeCheck = int.Parse(Console.ReadLine());

                    if (ChangeCheck == 1)
                    {
                        Methods.displayMiddleScreen("\u2219\u2219\u2219\u2219\u2219\u2219\u2219\u2219\u2219\u2219\u2219\u2219\u2219\u2219\u2219");
                        Methods.displayMiddleScreen("Which Change DO You Want Sir:");
                        Methods.displayMiddleScreen("1-Name.  2-Address.  3-Phone.  4-Branch ID.  5-Salary.  6-Back.");
                        int ChangeCheck2 = int.Parse(Console.ReadLine());

                        switch (ChangeCheck2)
                        {
                            case 1:
                                Methods.displayMiddleScreen("Enter the New Name:");
                                emp.Name = Console.ReadLine();
                                command.CommandText = $"update Employee set EName='{emp.Name}' Where Eid = {Employees.num()}";
                                command.ExecuteNonQuery();
                                Methods.displayMiddleScreen(emp.Name);
                                goto ChooseYesOrNoAgain;

                            case 2:
                                Methods.displayMiddleScreen("Enter the New Address:");
                                emp.Address = Console.ReadLine();
                                command.CommandText = $"update Employee set EAddress='{emp.Address}' Where Eid = {Employees.num()}";
                                command.ExecuteNonQuery();
                                Console.WriteLine(emp.Address);
                                goto ChooseYesOrNoAgain;

                            case 3:
                                Methods.displayMiddleScreen("Enter the New Phone:");
                                emp.Phone = Console.ReadLine();
                                command.CommandText = $"update Employee set EPhone='{emp.Phone}' Where Eid = {Employees.num()}";
                                command.ExecuteNonQuery();
                                Console.WriteLine(emp.Phone);
                                goto ChooseYesOrNoAgain;

                            case 4:
                                Methods.displayMiddleScreen("Enter the New Branch ID:");
                                emp.BranchID = int.Parse(Console.ReadLine());
                                command.CommandText = $"update Employee set BId='{emp.BranchID}' Where Eid = {Employees.num()}";
                                command.ExecuteNonQuery();
                                Console.WriteLine(emp.BranchID);
                                goto ChooseYesOrNoAgain;

                            case 5:
                                Methods.displayMiddleScreen("Enter the New Salary:");
                                emp.Salary = decimal.Parse(Console.ReadLine());
                                command.CommandText = $"update Employee set ESalary='{emp.Salary}' Where Eid = {Employees.num()}";
                                command.ExecuteNonQuery();
                                Console.WriteLine(emp.Salary);
                                goto ChooseYesOrNoAgain;

                            case 6:
                                break;

                            default:
                                break;
                        }
                        Methods.displayMiddleScreen($"\u221a\u221a\u221a {emp.Name} has been Created as Employee and Saved to the Data Base \u221a\u221a\u221a");
                        Console.ReadKey();
                    }
                    else if (ChangeCheck == 2)
                    {
                        Methods.displayMiddleScreen($"\u221a\u221a\u221a {emp.Name} has been Created as Employee and Saved to the Data Base \u221a\u221a\u221a");
                        Console.ReadKey();
                    }
                    else
                    {
                        Methods.displayMiddleScreen("Invalid Number!!!");
                        Console.ReadKey();
                        goto ChooseYesOrNoAgain;
                    }
                    Methods.BotColorfullCorners(1);
                }
                cnn.Close();
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        public void ShowEmp()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT *  FROM Employee", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("║  ID  ║  ◊  ║  Name  ║  ║   Address   ║  ◊  ║       Phone       ║  ║  Branch ID  ║  ◊  ║  Salary  ║\n");
                        while (reader.Read())
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("   " + reader["Eid"].ToString() + "           " + reader["EName"].ToString() + "           " + reader["EAddress"].ToString() + "                " + reader["EPhone"].ToString() + "             " + reader["Bid"].ToString() + "                " + reader["ESalary"].ToString());
                            Console.WriteLine();
                        }
                        Methods.BotColorfullCorners(3);
                    }
                }
            }
        }

        public void UpdateEmp()
        {
            try
            {
                string connetionString = @"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                Employees emp = new Employees();
                Methods.TopColorfullCorners(1);
                Methods.displayMiddleScreenNotLine("Enter employee ID : ");
                int i = int.Parse(Console.ReadLine());
                Methods.displayMiddleScreenNotLine("Enter Name: ");
                emp.Name = Console.ReadLine();
                Methods.displayMiddleScreenNotLine("Enter Address: ");
                emp.Address = Console.ReadLine();
                Methods.displayMiddleScreenNotLine("Enter Mobile: ");
                emp.Phone = Console.ReadLine();
                Methods.displayMiddleScreenNotLine("Enter Salary: ");
                emp.Salary = decimal.Parse(Console.ReadLine());
                Methods.displayMiddleScreenNotLine("Enter BranchID: ");
                emp.BranchID = int.Parse(Console.ReadLine());
                Methods.BotColorfullCorners(1);
                SqlCommand command = cnn.CreateCommand();
                if (cnn.State == ConnectionState.Open)
                {
                    command.CommandText = $"update Employee set EName='{emp.Name}',EAddress='{emp.Address}',EPhone='{emp.Phone}',BId={emp.BranchID},ESalary={emp.Salary} where Eid={i}";
                    command.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        public void DeleteEmp()
        {
            try
            {
                string connetionString = @"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connetionString);
                SqlCommand command = cnn.CreateCommand();
                cnn.Open();
                Employees emp = new Employees();
                Methods.displayMiddleScreenNotLine("Enter Employee ID to Delete: ");
                int i = int.Parse(Console.ReadLine());

                if (cnn.State == ConnectionState.Open)
                {
                    command.CommandText = $"delete from Employee where Eid= {i}";
                    command.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        //! ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void ShowOrders()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT O.Oid,O.Date,C.CName,B.BName,Sum(price) as Total_Price FROM Orders O , MenuItems M , OrderItem OI,Branches B,Customer C WHERE O.Oid = OI.OrderId and M.IName = OI.ItemName and  c.Cid=o.CId and B.Bid=o.BId Group by O.Oid,O.Date,C.CName,B.BName", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    Console.Write($"| {reader.GetName(i)} :" + reader.GetValue(i) + "               ");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        //! ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public void CreatItem()
        {
            try
            {
                string connetionString = @"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connetionString);
                SqlCommand command = cnn.CreateCommand();
                cnn.Open();
                MenuItems setItem = new MenuItems();
                Methods.displayMiddleScreenNotLine("Enter Item Name: ");
                setItem.FoodType = Console.ReadLine();
                Methods.displayMiddleScreenNotLine("Enter Item Price: ");
                setItem.Price = int.Parse(Console.ReadLine());
                Methods.displayMiddleScreenNotLine("Enter Item Branch id : ");
                setItem.BranchID = int.Parse(Console.ReadLine());

                if (cnn.State == ConnectionState.Open)
                {
                    command.CommandText = $"INSERT INTO MenuItems VALUES ('{setItem.FoodType}','{setItem.Price}','{setItem.BranchID}')";
                    command.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        public void ShowItem()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM MenuItems", connection))
                    {
                        //using (SqlDataReader reader = command.ExecuteReader())
                        //{
                        //    Console.WriteLine("║  Food Name  ║  ◊  ║  Price  ║  ║   Branch ID   ║\n");
                        //    while (reader.Read())
                        //    {
                        //        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        //        Console.WriteLine("   " + reader["IName"].ToString() + "           " + reader["price"].ToString() + "           " + reader["BId"].ToString());
                        //        Console.WriteLine();
                        //    }
                        //    Methods.BotColorfullCorners(3);
                        //}

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Console.WriteLine("║  Branch ID  ║  ◊  ║  Price  ║  ║   Food Name   ║\n");
                            while (reader.Read())
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("   " + reader["price"].ToString() + "           " + reader["BId"].ToString() + "           " + reader["IName"].ToString());
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        public void UpdateItem()
        {
            try
            {
                string connetionString = @"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connetionString);
                SqlCommand command = cnn.CreateCommand();
                cnn.Open();
                MenuItems setItem = new MenuItems();
                Methods.displayMiddleScreenNotLine("Enter item name that you will update: ");
                string update_item_name = Console.ReadLine();
                Methods.displayMiddleScreenNotLine("Enter item branch id for this item: ");
                int update_item_Bid = int.Parse(Console.ReadLine());
                Methods.displayMiddleScreen("~~~~~~~~~~~ A New Data for this item ~~~~~~~~~~");
                Methods.displayMiddleScreenNotLine("Enter new item name: ");
                setItem.FoodType = Console.ReadLine();
                Methods.displayMiddleScreenNotLine("Enter new item price : ");
                setItem.Price = int.Parse(Console.ReadLine());
                Methods.displayMiddleScreenNotLine("Enter new item branch id : ");
                setItem.BranchID = int.Parse(Console.ReadLine());

                if (cnn.State == ConnectionState.Open)
                {
                    command.CommandText = $"update MenuItems set IName='{setItem.FoodType}',BId = {setItem.BranchID},price = {setItem.Price} where IName = '{update_item_name}' and BId = {update_item_Bid}";
                    command.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        public void DeleteItem()
        {
            try
            {
                string connetionString = @"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connetionString);
                SqlCommand command = cnn.CreateCommand();
                cnn.Open();
                MenuItems setItem = new MenuItems();
                Methods.displayMiddleScreenNotLine("Enter item name: ");
                setItem.FoodType = Console.ReadLine();
                Methods.displayMiddleScreenNotLine("Enter item branch id : ");
                setItem.BranchID = int.Parse(Console.ReadLine());

                if (cnn.State == ConnectionState.Open)
                {
                    command.CommandText = $"delete From MenuItems where IName='{setItem.FoodType}' and BId = {setItem.BranchID}";
                    command.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        #endregion Methods:
    }
}