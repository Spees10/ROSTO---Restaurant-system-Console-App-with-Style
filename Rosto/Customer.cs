using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosto
{
    internal class Customer : User
    {
        public void CreateCustomer()
        {
            try
            {
                string connetionString = @"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connetionString);
                SqlCommand command = cnn.CreateCommand();
                cnn.Open();
                Console.Clear();
                Methods.TopColorfullCorners(1);
                Methods.displayMiddleScreenNotLine("Greetings ..... ummm, What's Your Name ( -.-\"): ");
                Name = Console.ReadLine();
                Methods.LineWithColor();
                Methods.displayMiddleScreenNotLine("Enter Address: ");
                Address = Console.ReadLine();
                Methods.LineWithColor();
            PhoneAgain:
                Methods.displayMiddleScreenNotLine("Enter Mobile: ");
                Phone = Console.ReadLine();
                if (!Methods.IsValidPhone(Phone))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Methods.displayMiddleScreen("Incorrect Phone Number . . . . (-_-)*");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.ReadKey();
                    goto PhoneAgain;
                }
                Methods.LineWithColor();
                Methods.BotColorfullCorners(1);

                if (cnn.State == ConnectionState.Open)
                {
                    command.CommandText = $"INSERT INTO Customer VALUES ({GenerateID()},'{Name}','{Address}','{Phone}')";
                    command.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        public void DeleteCus()
        {
            try
            {
                string connetionString = @"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True";
                SqlConnection cnn = new(connetionString);
                SqlCommand command = cnn.CreateCommand();
                cnn.Open();
                if (cnn.State == ConnectionState.Open)
                {
                    command.CommandText = $"delete from Customer where Cid= {Customer.num()}";
                    command.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        public void CreateOrder(int x)
        {
            try
            {
                string connetionString = @"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connetionString);
                SqlCommand command = cnn.CreateCommand();
                cnn.Open();
                if (cnn.State == ConnectionState.Open)
                {
                    command.CommandText = $"INSERT INTO Orders VALUES ({Orders.GenerateID()},'{DateTime.Now}',{Customer.num()},{x})";
                    command.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        public void ShowTprice()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand($"SELECT Sum(price) as tprice FROM Orders O , MenuItems M , OrderItem OI WHERE O.Oid = OI.OrderId and M.IName = OI.ItemName and o.Oid={Orders.num()}", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal x = (decimal)reader["tprice"];
                            decimal tax = x * 1.14m;
                            Console.WriteLine("\n");
                            List<string> ShowPrice = new List<string>() { $"Total Price is (≥^_^)≥   {x}.00$ ", $"Total Price after adding Taxes is {tax}.00$" };
                            Methods.displayListOfStrings(ShowPrice);
                        }

                        Console.WriteLine();
                    }
                }
            }
        }

        public void ShowOrder()
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"select o.Oid ,o.Date,OI.ItemName,m.price from MenuItems as m,Orders as o,OrderItem as OI where o.Oid=OI.OrderId and m.IName=OI.ItemName and o.Oid={Orders.num()}", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Methods.TopColorfullCorners(0);
                            Methods.displayMiddleScreen($"Order ID is :   { reader["Oid"].ToString()}");
                            Methods.displayMiddleScreen($"Date is : { reader["Date"].ToString()} ");
                            Methods.displayMiddleScreenNotLine($"             ");
                            Methods.displayMiddleScreen($"Orders");
                            Methods.displayMiddleScreen($"◌◌◌◌◌◌◌◌◌◌◌◌◌◌◌");
                            Methods.displayMiddleScreen($"»»   Food Name   »»»»  Food Price  »»»»");
                            Methods.displayMiddleScreenNotLine($"{reader["itemName"].ToString()}" + $"            {reader["price"].ToString()}" + ".00$");
                            Methods.displayMiddleScreen("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ");
                            break;
                        }

                        while (reader.Read())
                        {
                            Methods.displayMiddleScreen(reader["itemName"].ToString() + "          " + reader["price"].ToString() + ".00$");
                            Methods.displayMiddleScreen("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ");
                        }

                        ShowTprice();

                        Console.WriteLine();
                    }
                }
            }
        }

        public void DeleteOrder()
        {
            try
            {
                string connetionString = @"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connetionString);
                SqlCommand command = cnn.CreateCommand();
                cnn.Open();
                if (cnn.State == ConnectionState.Open)
                {
                    command.CommandText = $"delete from OrderItem where OrderId= {Orders.num()}";
                    command.ExecuteNonQuery();
                    command.CommandText = $"delete from Orders where Oid= {Orders.num()}";
                    command.ExecuteNonQuery();
                    command.CommandText = $"delete from Customer where Cid= {num()}";
                    command.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        public static int GenerateID()
        {
            int x = Customer.num();
            return ++x;
        }

        public static int num()
        {
            int ne = 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT TOP (1) [Cid] FROM[Rosto].[dbo].[Customer] order by Cid DESC; ", connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return ne = (int)reader.GetValue(0);
                            }
                        }
                    }
                }
                return ne;
            }
            catch
            {
                Console.WriteLine("Exp");
                return 0;
            }
        }
    }
}