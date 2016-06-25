using System;

namespace Past.Utils
{
    public class ConsoleUtils
    {
        public enum type { INFO, WARNING, ERROR, DONE, DEBUG, RECEIV, SEND };

        public static string[] logo = new string[]
        {
            "                                   ",
            "     #####     ##     ####   ##### ",
            "     #    #   #  #   #         #   ",
            "     #    #  #    #   ####     #   ",
            "     #####   ######       #    #   ",
            "     #       #    #  #    #    #   ",
            "     #       #    #   ####     #   ",
            "                                   "
        };

        public static void InitializeConsole()
        {
            Console.Title = "#PAST";
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < logo.Length; i++)
            {
                string text = logo[i];
                Console.WriteLine(text.PadLeft((int)(Console.BufferWidth + text.Length) / 2));
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Write(type type, string text, params object[] args)
        {
            switch (type)
            {
                case type.INFO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("[{0}]", type);
                    break;
                case type.WARNING:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("[{0}]", type);
                    break;
                case type.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("[{0}]", type);
                    break;
                case type.DONE:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("[{0}]", type);
                    break;
                case type.DEBUG:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("[{0}]", type);
                    break;
                case type.RECEIV:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("[{0}]", type);
                    break;
                case type.SEND:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("[{0}]", type);
                    break;

            }
            Console.SetCursorPosition(10, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text, args);
        }
    }
}
