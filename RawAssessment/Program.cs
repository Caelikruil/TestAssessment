using System;

namespace RawAssessment
{
    class Program
    {
        static void Main()
        {
            //I tried to use one console app, so navigation will be by user input
            //Each function accessable by its own number
            //Navigation maid by inf cycle with bool variable terminator by user input
            //choosing of function made by switch case operator
            var terminateFlag = false;
            while (!terminateFlag)
            {
                Console.WriteLine("1) Try out multipliers of 4 and 6 function");
                Console.WriteLine("2) Try out palindrome function");
                Console.WriteLine("3) Run tests for function 1)");
                Console.WriteLine("4) Run tests for function 2)");
                Console.WriteLine("Or enter 5 for terminate");
                Console.WriteLine("Insert number of function or test scenario:");
                var input = Console.ReadLine();
                switch (input)
                {
                    //Every number call execute function for every task
                    //for readability I moved code by different logical classes
                    case "1":                        
                        FunctionExecutor.RunMultipliers();
                        break;
                    case "2":
                        FunctionExecutor.RunPalindrome();
                        break;
                    case "3":
                        TestsRunner.MultiplierTestsRun();
                        break;
                    case "4": 
                        TestsRunner.PalindromeTestsRun(); 
                        break;
                    case "5":
                        terminateFlag = true;
                        break;
                    default: 
                        Console.WriteLine("Input Error! Try digit from 1 to 5"); 
                        break;
                }
                Console.WriteLine("Press Enter to proceed...");
                Console.ReadLine();
                Console.WriteLine();
            }

        }
    }
}