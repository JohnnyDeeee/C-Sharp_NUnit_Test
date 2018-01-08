using System.Collections.Generic;

namespace RandomNumberGen
{
    /* Class: TerminalMock
     * Description: Contains logic for mocking RandomNumberGen_Util
     */
    public class TerminalMock
    {
        private bool debug = false; // Used for turning on/off debugging
        private string output; // Mocking the terminal output

        public string getOutput()
        {
            return output;
        }

        public TerminalMock(string[] args)
        {
            HandleConsoleParams(args);
        }

        /// <summary>
        /// Handles given (if any) console params
        /// </summary>
        /// <param name="args">Console params [--debug (turns on console logs)]</param>
        public void HandleConsoleParams(string[] args)
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
        public void DebugLine(string line)
        {
            if(!debug)
                return;

            output = line;
        }
    }
}