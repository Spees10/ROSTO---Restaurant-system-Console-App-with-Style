using System;
using System.Collections.Generic;

namespace Rosto
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Allowing Console to read & show Consolas Font Emojis::
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Methods.WelcomListCall();
            Methods.SwitchOnWelcomList();
        }
    }
}