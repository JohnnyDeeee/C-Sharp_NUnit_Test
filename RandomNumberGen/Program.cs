using System;
using System.Collections.Generic;
using System.IO;

namespace RandomNumberGen
{
    class Program
    {
        // TODO: Make unit tests

        const int AMOUNT_OF_GENERATIONS = 100; // Amount of numbers we are going to generate
        const string OUTPUT_FILE_NAME = "output.txt"; // Name of the output file
        static List<int> uniqueNumbers = new List<int>(); // List that gets filled with the numbers

        /// <summary>
        /// Main function, fills a list with X random numbers
        /// </summary>
        /// <param name="args">Console params [--debug (turns on console logs)]</param>
        static void Main(string[] args)
        {
            // Handle console params
            RandomNumberGen_Util.HandleConsoleParams(args);

            // Create RandomNumberGen service
            RandomNumberGen_Service randomNumberGen = new RandomNumberGen_Service(ref uniqueNumbers);

            // Create RandomNumberGen IO
            RandomNumberGen_IO io = new RandomNumberGen_IO();

            // Fill the list with unique random numbers
            for (int i = 1; i < AMOUNT_OF_GENERATIONS; i++)
            {
                uniqueNumbers.Add(randomNumberGen.GetUniqueRandomNumber());
            }

            // DEBUG
            uniqueNumbers.ForEach((uniqueNumber) => RandomNumberGen_Util.DebugLine(string.Format("UniqueNumber: {0}", uniqueNumber)));

            // Write numbers to file (output.txt) in current directory
            io.WriteToFile(uniqueNumbers);

            // DEBUG
            RandomNumberGen_Util.DebugLine(string.Format("Done writing numbers to {0}", OUTPUT_FILE_NAME));
        }
    }
}
