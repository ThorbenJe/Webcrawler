using System;
using System.Collections.Generic;

namespace Webcrawler
{
    class Gui
    {
        public static string ReadLine(string message)
        {
            Gui.Write(message);
            var input = Console.ReadLine();
            Gui.WriteLine();

            return input;
        }

        public static void WriteLine(string text = "")
        {
            Console.WriteLine(text);
        }

        public static void Write(string text)
        {
            Console.Write(text);
        }

        public static void WriteRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Gui.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Gui.WriteLine(text);
            Console.ResetColor();
        }

        public static string UserRequest()
        {
            string userRequest = Console.ReadLine();
            return userRequest;
        }

        public static void WriteList(List<string> list)
        {
            list.ForEach(i => Console.Write("{0}\n", i));
        }

        public static int UserYN()
        {
            string userRequest = System.Console.ReadLine();
            if (userRequest == "y" | userRequest == "Y")
            {
                return 1;
            }
            else if (userRequest == "n" | userRequest == "N")
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }
    }
}
