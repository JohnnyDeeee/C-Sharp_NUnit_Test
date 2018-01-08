using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.IO;

namespace RandomNumberGen
{
    /* Class: RandomNumberGen_Test
     * Description: Contains Unit tests
     */
    [TestFixture]
    public class RandomNumberGen_Test
    {    
        private RandomNumberGen_Service randomNumberGen;
        private RandomNumberGen_IO io;
        private List<int> uniqueNumbers;
        private TerminalMock terminalMock;
        
        [SetUp]
        protected void SetUp()
        {
            uniqueNumbers = new List<int>(); // Make an empty int list
            randomNumberGen = new RandomNumberGen_Service(ref uniqueNumbers); // Get instance of RandomNumberGen_Service
            io = new RandomNumberGen_IO(); // Get instance of RandomNumberGen_IO
            terminalMock = new TerminalMock(new string[]{"--debug"}); // Create terminal mock with debug flag to enable logs
        }

        // Tests if the output from RandomNumberGen_Service.GetUniqueRandomNumber()
        // is of type int
        [Test]
        public void CheckIfTypeInt()
        {
            // Create a random unique number
            var number = randomNumberGen.GetUniqueRandomNumber();

            // Check if its type is an integer
            Assert.IsInstanceOf<int>(number, "UniqueRandomNumber is not of type int!");
        }

        // Test if the output from RandomNumberGen_Service.GetUniqueRandomNumber()
        // has a max length of 5
        [Test]
        public void CheckMaxLenghth()
        {
            // Create a random unique number
            var number = randomNumberGen.GetUniqueRandomNumber();

            // Check if its length is max 5
            Assert.That(number, Is.AtMost(99999), "Number is greater than max number length of 5");
        }

        // Tests if the method RandomNumberGen_Service.GetUniqueRandomNumber()
        // can make an X amount of unqiue random numbers
        [Test]
        public void CheckCanMakeUnqiueNumbers()
        {
            // Create some random unique numbers
            int amountToMake = 100;
            for(int i = 0; i < amountToMake; i++)
            {
                uniqueNumbers.Add(randomNumberGen.GetUniqueRandomNumber());
            }

            // Check if we made N numbers
            Assert.That(uniqueNumbers, Has.Count.EqualTo(amountToMake), string.Format("Array does not contain %1 numbers!"));
            
            // Check if all numbers are unique
            foreach(int number in uniqueNumbers)
            {
                Assert.That(uniqueNumbers, Has.Exactly(1).EqualTo(number), "Array contains duplicates!");
            }
        }

        // Tests if we can create the output file
        [Test]
        public void CheckCanMakeOutputFile()
        {
            // Create some random unique numbers
            int amountToMake = 100;
            for(int i = 0; i < amountToMake; i++)
            {
                uniqueNumbers.Add(randomNumberGen.GetUniqueRandomNumber());
            }
            
            // Write the output file
            FileInfo createdFile = io.WriteToFile(uniqueNumbers);

            // Check if the file exists
            FileAssert.Exists(createdFile, "Output file does not exist!");

            // Cleanup
            createdFile.Delete();
        }

        // Test the Terminal mock logging functon
        [Test]
        public void TestTerminalMock()
        {
            const string testLine = "Test line 1"; // String to throw into output
            terminalMock.DebugLine(testLine); // Log the string to output

            Assert.That(terminalMock.getOutput(), Is.EqualTo(testLine)); // Compare terminal output to original string
        }
    }   
}