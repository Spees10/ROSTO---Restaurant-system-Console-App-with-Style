using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                SqlConnection cnn;
                string connetionString = @"Data Source=DESKTOP-30NR859\LOAI;Initial Catalog=Rosto;Integrated Security=True";
                cnn = new SqlConnection(connetionString);
                cnn.Open();
                //   SqlCommand command = cnn.CreateCommand();
                if (cnn.State == ConnectionState.Open)
                {
                    Console.WriteLine("open");
                }
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }
    }
}