using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rosto
{
    internal class Employees : User
    {
        //private static int x = 5;
        //private static int ID = num(ref x);

        public Employees()
        { }

        public Employees(decimal salary, byte age)
        {
            Salary = salary;
            Age = age;
        }

        public static int GenerateID()
        {
            int x = num();
            return ++x;
        }

        public decimal Salary { get; set; }
        public byte Age { get; set; }

        public static int num()
        {
            int ne = 1;
            try
            {
                using (SqlConnection connection = new SqlConnection(@"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True"))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT TOP (1) [Eid] FROM[Rosto].[dbo].[Employee] order by Eid DESC; ", connection))
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