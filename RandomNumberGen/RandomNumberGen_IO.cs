using System;
using System.Collections.Generic;
using System.IO;

namespace RandomNumberGen
{
    /* Class: RandomNumberGen_IO
     * Description: Contains logic for writing the output file
     */
    public class RandomNumberGen_IO
    {
        private readonly string outputName = "output.txt"; // Output file name

        /// <summary>
        /// Write the list of numbers to a file
        /// </summary>
        /// <param name="uniqueNumbers">The list of uniqueRandom numbers</param>
        /// <returns>FileInfo object of the created file</returns>
        public FileInfo WriteToFile(List<int> uniqueNumbers)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(outputName))
                {
                    foreach (int number in uniqueNumbers) // Go through all unique random numbers
                    {
                        file.WriteLine(number); // Write unique number to the file on its own line
                        return new FileInfo(outputName);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Could not write output file");
            }

            return null;
        }
    }
}