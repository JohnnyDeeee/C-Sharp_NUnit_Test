using System;

namespace RandomNumberGen
{
    /* Class: RandomNumberGen_Util
     * Description: Contains logic for logging to the terminal
     */
    public static class RandomNumberGen_Util
    {
        private static bool debug = false; // Used for turning on/off debugging
        
        /// <summary>
        /// Handles given (if any) console params
        /// </summary>
        /// <param name="args">Console params [--debug (turns on console logs)]</param>
        public static void HandleConsoleParams(string[] args)
        {
            foreach (string argument in args)
            {
                if(argument.ToString().ToLower() == "--debug") // Turn on debug
                    debug = true;
            }
        }

        /// <summary>
        /// Writes console log when debug setting is enabled
        /// </summary>
        /// <param name="line">The string to log</param>
        public static void DebugLine(string line)
        {
            if(!debug)
                return;

            Console.WriteLine(line);
        }
    }
}