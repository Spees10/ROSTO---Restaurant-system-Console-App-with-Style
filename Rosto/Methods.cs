using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Rosto
{
    internal class Methods
    {
        //?                        (ㆆ_ㆆ) (ㆆ_ㆆ) (ㆆ_ㆆ) (ㆆ_ㆆ) (ㆆ_ㆆ) (ㆆ_ㆆ) (ㆆ_ㆆ) (ㆆ_ㆆ) (ㆆ_ㆆ) (ㆆ_ㆆ) (ㆆ_ㆆ) (ㆆ_ㆆ)
        /*! ~~~~~~~~~~~~~~~~~~~~~~~~# START OF THE CONTEXT #~~~~~~~~~~~~~~~~~~~~~~~~~ !*/

        #region Centering ROSTO Restaurant Text (. ͡ᵔ ⍨ ͡ᵔ.)

        // Displaying text in the Center in the Center of The Console with a NEW LINE:
        public static void displayMiddleScreen(string gomla)
        {
            Console.SetCursorPosition((Console.WindowWidth - gomla.Length) / 2, Console.CursorTop + 1);
            Console.WriteLine(gomla);
        }

        // Displaying text in the Center in the Center of The Console without a NEW LINE:
        public static void displayMiddleScreenNotLine(string gomla)
        {
            Console.SetCursorPosition((Console.WindowWidth - gomla.Length) / 2, Console.CursorTop + 1);
            Console.Write(gomla);
        }

        // Displaying List of string in the Center of the Console:
        public static void displayListOfStrings(List<string> ListyStringy)
        {
            TopColorfullCorners(0);
            foreach (string item in ListyStringy)
            {
                displayMiddleScreen(item);
            }
            BotColorfullCorners(0);
        }

        #endregion Centering ROSTO Restaurant Text (. ͡ᵔ ⍨ ͡ᵔ.)

        /*! ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ !*/

        #region Colorfull ROSTO Restaurant Text ¯\_( ͡° ⍨ ͡°)_/¯

        // Displaying Colorfull 'Tob Border' + 'Text' + 'Bor Border':
        public static void FullColorfullTextBars(string text, int newLine)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            TopColorfullCorners(newLine);
            displayMiddleScreenNotLine(text);
            BotColorfullCorners(newLine);
        }

        // Coloring THe Top  Borders:
        public static void TopColorfullCorners(int newLine)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\t\t\t\t  \u2554\u2550");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\u2550\u2550");
            for (int i = 0; i < newLine; i++)
            {
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        // Coloring The Bottom Borders:
        public static void BotColorfullCorners(int newLine)
        {
            for (int i = 0; i < newLine; i++)
            {
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\t\t\t\t  \u255a\u2550");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\u2550\u255d");
            Console.ForegroundColor = ConsoleColor.Green;
        }

        // Coloing Middile Line With Corners:
        public static void LineWithColor()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t\t\t\t          \u2550");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550\u2550");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\u2550");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        #endregion Colorfull ROSTO Restaurant Text ¯\_( ͡° ⍨ ͡°)_/¯

        /*! ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ !*/

        public static void ItemOrder(string x)
        {
            try
            {
                string connetionString = @"Data Source=Lenovo\LOAI;Initial Catalog=Rosto;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(connetionString);
                SqlCommand command = cnn.CreateCommand();
                cnn.Open();
                int y = Orders.num();

                if (cnn.State == ConnectionState.Open)
                {
                    command.CommandText = $"INSERT INTO OrderItem VALUES ({y},'{x}')";
                    command.ExecuteNonQuery();
                }
                cnn.Close();
            }
            catch
            {
                Console.WriteLine("Exp");
            }
        }

        public static void CompleteOrder()
        {
            Console.WriteLine("\n\n\n");
            TopColorfullCorners(0);
            displayMiddleScreen("Are you SURE to Complete Order??");
            displayMiddleScreen("yes  /  No");
            string CompleteOrder = Console.ReadLine().ToLower();
            if (CompleteOrder == "yes")
            {
                ThankYou();
                Console.WriteLine();
                displayMiddleScreen("Come Order Again :-) *** Press Any Key To Exit . . . . ʕ•́ᴥ•̀ʔっ 👋≧◉ᴥ◉≦ (>‿◠)✌");
                Console.ReadKey();
            }
            else
            {
                Customer c = new Customer();
                c.DeleteOrder();
                displayMiddleScreen("Your Order Has Been Declined");
                LineWithColor();
                displayMiddleScreen("Thanks for visting ..... Comming Soon  👋≧◉ᴥ◉≦ (>‿◠)✌");
                Console.ReadKey();
            }
            BotColorfullCorners(0);
        }

        /*! ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ !*/

        #region Main Main Menu Of Rosto Restaurant All Calling Code (. ͡° ⍨ ͡°.)

        // Display Welcom List ::
        public static void WelcomListCall()
        {
            /*###  Creating List of Welcom Form  ###*/
            Console.Clear();
            List<string> CustEmpList = new List<string> { "✶ Welcom To ✶ ",
                "∞ ∞ ∞ ∞ ∞ ∞ ∞ ∞ ∞ ∞ ∞",
                "♥ (ͽ^_^)ͽ \u1D19ostooooo\u2122 ͼ(^_^ͼ) ♥", "∞ ∞ ∞ ∞ ∞ ∞ ∞ ∞ ∞ ∞ ∞",
                "~ ▒ ~ ▒ ~ ▒ ~ ▒ ~ ▒ ~ ▒ ~ ▒ ~ ▒ ~ ▒ ~ ▒ ~ ▒ ~ ▒ ~ ▒ ~\n\n"
                };
            displayListOfStrings(CustEmpList);
            Console.ForegroundColor = ConsoleColor.Yellow;
            displayMiddleScreen("♥ Press Any Key TO Continue  . . . . ʕ•́ᴥ•̀ʔͽ   ");
            Console.ReadKey();

            Console.Clear();
            mainMenu();
        }

        public static void mainMenu()
        {
            List<string> CustEmpList2 = new List<string> {" \u263a Choose an Option (>_^)", "~~~~~~~~~~~~~~~~~~~~~~~~",
                "\u2776 \u2212\u2212\u2192 Create an Order \u2190\u2212\u2212 \u2776",
                "\u2777 \u2212\u2212\u2192 Manager \u2190\u2212\u2212 \u2777 (ⱴ︡'-'︠)ⱴ",
                "\u2778 \u2212\u2212\u2192 Exit \u2190\u2212\u2212 \u2778 (╥_╥)\n"  };
            displayListOfStrings(CustEmpList2);
        }

        // Calling of  boCode ::
        public static void SwitchOnWelcomList()
        {
        ChoiceAgain:
            Customer c = new Customer();
            CustEmp CustChoice = (CustEmp)int.Parse(Console.ReadLine());

            User user = new User();
            if (CustChoice == (CustEmp)1 || CustChoice == (CustEmp)2 || CustChoice == (CustEmp)3)
            {
                user.ShowBranch(CustChoice, c);
                Console.Clear();
                user.ShowMenu(c);
            }
            else
            {
                Console.Clear();
                TopColorfullCorners(0);
                displayMiddleScreen("Invalid Choice ... Press any key to back\n");
                BotColorfullCorners(0);
                Console.ReadKey();
                Console.Clear();
                mainMenu();
                goto ChoiceAgain;
            }
            // Branches Choices as a Customer:
        }

        #endregion Main Main Menu Of Rosto Restaurant All Calling Code (. ͡° ⍨ ͡°.)

        /*! ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ !*/

        #region Arigato Kozaimathuuu ( ͡ᵔ ‿‿ ͡ᵔ) (. ͡ᵔ ᴗ ͡ᵔ.)

        // Last Called Function :) :) :)
        public static void ThankYou()
        {
            List<string> ThankYou = new List<string> { "شكرًا", "Gracias", "Merci", "Grazie", "Danke", "Bedankt", "Teşekkürler", "谢谢", "감사합니다", "Cảm ơn", "Dzięki" };
            displayListOfStrings(ThankYou);
            Console.ForegroundColor = ConsoleColor.Magenta;
            displayMiddleScreen(". . . . I AM SO PROUD TO BE IN THIS TEAM & I HOPE TO MEET AGAIN SOON ( ͡ᵔ ᴗ ͡ᵔ) . . . .");
        }

        #endregion Arigato Kozaimathuuu ( ͡ᵔ ‿‿ ͡ᵔ) (. ͡ᵔ ᴗ ͡ᵔ.)

        /*! ~~~~~~~~~~~~~~~~~~~~~~~~# END OF THE CONTEXT #~~~~~~~~~~~~~~~~~~~~~~~~~ !*/

        //?                         ( ˘︹˘ )( ˘︹˘ )( ˘︹˘ )( ˘︹˘ )( ˘︹˘ )( ˘︹˘ )( ˘︹˘ )( ˘︹˘ )( ˘︹˘ )( ˘︹˘ )
        public static bool IsValidPhone(string Phone)
        {
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                var r = new Regex("^01[0125][0-9]{8}$");
                return r.IsMatch(Phone);
            }
            catch (Exception)
            {
                displayMiddleScreen("Invalid Input ...Press Any Key to Try Again");
                Console.ReadKey();
                return false;
            }
        }
    }
}