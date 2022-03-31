using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosto
{
    internal class Orders
    {
        public Orders()
        { }

        public Orders(int orderID, DateTime orderDate)
        {
            OrderID = orderID;
            OrderDate = orderDate;
        }

        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        public static int GenerateID()
        {
            int x = Orders.num();
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
                    using (SqlCommand command = new SqlCommand("SELECT TOP (1) [Oid] FROM[Rosto].[dbo].[Orders] order by Oid DESC; ", connection))
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