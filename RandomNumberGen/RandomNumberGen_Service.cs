using System;
using System.Collections.Generic;

namespace RandomNumberGen
{
    /* Class: RandomNumberGen_Service
     * Description: Contains logic for generating random unique numbers
     */
    public class RandomNumberGen_Service
    {
        private List<int> uniqueNumbers;
        private Random rand = new Random(); // Instance of the Random library

        public RandomNumberGen_Service(ref List<int> uniqueNumbers)
        {
            this.uniqueNumbers = uniqueNumbers;
        }

        /// <summary>
        /// Checks if a number is unique in the list
        /// </summary>
        /// <returns>The unique number</returns>
        public int GetUniqueRandomNumber()
        {
            int uniqueNumber; // Return value
            int max_tries = 20; // Timeout for the loop
            int current_tries = 0; // Current amount of loops
            
            do
            {
                if(current_tries == max_tries)
                    throw new Exception("Could not generate random number");
                current_tries++;

                uniqueNumber = GenerateRandomNumber();
            } while (uniqueNumbers.Contains(uniqueNumber));

            return uniqueNumber;
        }

        /// <summary>
        /// Generates a random number
        /// </summary>
        /// <returns>Returns the random number</returns>
        private int GenerateRandomNumber()
        {
            return rand.Next(0, 99999);            
        }
    }
}