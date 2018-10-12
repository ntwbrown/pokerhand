using System;
using System.Collections.Generic;
using System.Text;

internal class Helpers
{
    public static void Display(string text, int option)
    {
        switch (option)
        {
            case 1:
              Console.ForegroundColor = ConsoleColor.Green;
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Red;
                break;

            default:
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }

        Console.WriteLine(text);

    }

}