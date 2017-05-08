using System;
using System.Collections.Generic;

namespace Webcrawler
{
    class Gui
    {
        public static string UserRequest()
        {
            string userRequest = Console.ReadLine();
            return userRequest;
        }
        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
        public static void Write(string text)
        {
            Console.Write(text);
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
        public static void ResetColor()
        {
            Console.ResetColor();
        }
        public static void WriteFontRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Gui.WriteLine(text);
            Gui.ResetColor();
        }
        public static void WriteFontGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Gui.WriteLine(text);
            Gui.ResetColor();
        }
    }
}
