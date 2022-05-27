using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RawAssessment
{

    //It is class for execution of test cases for Task 2
    public class TestsRunner
    {
        //Run tests for task of find multipliers for 4 and 6
        public static void MultiplierTestsRun()
        {
            Console.WriteLine("Run tests for multiplier-finder function");
            MethodsRunner(typeof(MultiplierTests));
        }

        //Run tests for task of checking for palindrome function
        public static void PalindromeTestsRun()
        {
            Console.WriteLine("Run tests for palindrome function");
            MethodsRunner(typeof(PalindromeTests));
        }

        //Just for fun, call methods via reflection by Type of testClass
        private static void MethodsRunner(Type testClass)
        {
            //We will collect results of our run
            var executionStatus = new List<bool>();

            //Get every method who:
            //wasn't inherited, who is static (because we call them without instance of object) and public
            foreach (MethodInfo test in testClass.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public))
            {
                //add result to array of results
                executionStatus.Add(
                    //call test case without params and cast object-result to bool value
                    (bool)testClass.GetMethod(test.Name).Invoke(null, null));
            }

            //Print our execution results
            Console.WriteLine($"Executed test count: {executionStatus.Count}");
            Console.WriteLine($"Passed: {executionStatus.Where(c => c).Count()}, Failed: {executionStatus.Where(c => !c).Count()}");
        }
    }
}