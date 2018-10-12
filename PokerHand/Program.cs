using System;
using System.IO;
using System.Collections.Generic;
using static Helpers;


namespace PokerHand
{

    class Program
    {
        internal static Dictionary<int, String> Store = new Dictionary<int, String>();
        public const string inputFilePath = "inputFile.txt";
        //  public static Dictionary<string, string> Store = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            // 1.0 Check if File Exists
            if (File.Exists(inputFilePath))
            {

                // 2.0 Initialise Card Deck
                ApplicationLogic.InitialiseCardDeck();

                // 3.0 Pre Process File to ensure it does not have any corrupt data

                if (ApplicationLogic.PreProcessFile(inputFilePath))
                {

                    // 4.0 Finally Process File
                    ApplicationLogic.ProcessFile(inputFilePath);

                }
                else
                {
                    Helpers.Display("Sorry, file " + inputFilePath + " failed Pre-processing, check file and try again.", 2);
                }

            }

            else
            {
                Helpers.Display("Sorry unable to process, file " + inputFilePath + " does not exist", 1);
                Helpers.Display("Press any key to exit", 1);
            }

            Console.ReadKey();
        }
    }
}
