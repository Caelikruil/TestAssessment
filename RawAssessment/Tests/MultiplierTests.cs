using System;
using System.Collections.Generic;

namespace RawAssessment
{
    //Test scenarios for stand-alone multiply-checker function
    public class MultiplierTests{

        //----------Positive------------
        public static bool TestCase1()
        {
            Console.WriteLine("TC1 - Positive, only 4");

            var testArray = new List<int>() { 4 };
            var expectedResult = 1;
            return CheckArrayForMultipliers(testArray, expectedResult);
        }
        public static bool TestCase2()
        {
            Console.WriteLine("TC2 - Positive, only 6");

            var testArray = new List<int>() { 6 };
            var expectedResult = 1;
            return CheckArrayForMultipliers(testArray, expectedResult);
        }
        public static bool TestCase3()
        {
            Console.WriteLine("TC3 - Positive, only 12");

            var testArray = new List<int>() { 12 };
            var expectedResult = 1;
            return CheckArrayForMultipliers(testArray, expectedResult);
        }
        public static bool TestCase4()
        {
            Console.WriteLine("TC4 - Positive, only 3");

            var testArray = new List<int>() { 3 };
            var expectedResult = 0;
            return CheckArrayForMultipliers(testArray, expectedResult);
        }
        public static bool TestCase5()
        {
            Console.WriteLine("TC5 - Positive, some same digits");

            var testArray = new List<int>() { 4, 4 };
            var expectedResult = 2;
            return CheckArrayForMultipliers(testArray, expectedResult);
        }
        public static bool TestCase6()
        {
            Console.WriteLine("TC6 - Positive, different numbers w/o multipliers");

            var testArray = new List<int>() { 1, 45, 67, 13 };
            var expectedResult = 0;
            return CheckArrayForMultipliers(testArray, expectedResult);
        }
        public static bool TestCase7()
        {
            Console.WriteLine("TC7 - Positive, negative numbers");

            var testArray = new List<int>() { -4, -12, -6 };
            var expectedResult = 3;
            return CheckArrayForMultipliers(testArray, expectedResult);
        }

        public static bool TestCase8()
        {
            Console.WriteLine("TC8 - Negative, empty array");

            var testArray = new List<int>();
            var expectedResult = 0;
            return CheckArrayForMultipliers(testArray, expectedResult);
        }

        public static bool TestCase9()
        {
            Console.WriteLine("TC9 - Negative, null value");

            var testArray = (List<int>) null;
            var expectedResult = 0;
            return CheckArrayForMultipliers(testArray, expectedResult);
        }

        //By the rule, myltiplier of 0 is only 0, but 0 divided by every num doesn't have remainder
        //so, it makes this an unique case
        public static bool TestCase10()
        {
            Console.WriteLine("TC10 - zero value");

            var testArray = new List<int>() { 0 };
            var expectedResult = 0;
            return CheckArrayForMultipliers(testArray, expectedResult);
        }

        //----------method executor with check
        //simple repeated code for checking
        private static bool CheckArrayForMultipliers(List<int> testArray, int expectedResult)
        {
            //call func
            var result = Functions.CheckForMultipliers(testArray);
            //check result with expected value
            var testPassed = result == expectedResult;
            //log result
            Console.WriteLine($"Tested value: [{(testArray is null ? "null" : string.Join(", ", testArray))}]" +
                $".Execution result: {result}, test {(testPassed ? "passed" : $"failed, expected result: {expectedResult}")}");
            return testPassed;
        }
    }
}