using System;

namespace RawAssessment
{
    //Test scenarios for palindrome function and it's interface
    public class PalindromeTests
    {
        private const bool trueResult = true;
        private const bool falseResult = false;

        //Positive test case with even number of letters
        public static bool TestCase1()
        {
            Console.WriteLine("TC1 - Positive, even letters, without space");

            var testString = "abccba";
            
            return CheckPalindromeResult(testString, trueResult);
        }

        //Positive test case with odd number of letters
        public static bool TestCase2()
        {
            Console.WriteLine("TC2 - Positive, odd letters, without space");

            var testString = "abcdcba";
            
            return CheckPalindromeResult(testString, trueResult);
        }

        //Positive test case with even number of letters with symmetric spaces
        public static bool TestCase3()
        {
            Console.WriteLine("TC3 - Positive, even letters, with symmetric spaces");

            var testString = "a bccb a";
            
            return CheckPalindromeResult(testString, trueResult);
        }

        //Positive test case with odd number of letters with symmetric spaces
        public static bool TestCase4()
        {
            Console.WriteLine("TC4 - Positive, odd letters, with symmetric spaces");

            var testString = "a bc d cb a";
            
            return CheckPalindromeResult(testString, trueResult);
        }

        //Positive test case with even number of letters with asymmetric spaces
        public static bool TestCase5()
        {
            Console.WriteLine("TC5 - Positive, even letters, with asymmetric spaces");

            var testString = "a bc cba";
            
            return CheckPalindromeResult(testString, trueResult);
        }

        //Positive test case with odd number of letters with asymmetric spaces
        public static bool TestCase6()
        {
            Console.WriteLine("TC6 - Positive, odd letters, with asymmetric spaces");

            var testString = "a bc d cba";
            
            return CheckPalindromeResult(testString, trueResult);
        }

        //Positive test case with multiple spaces in a row
        public static bool TestCase7()
        {
            Console.WriteLine("TC7 - Positive, multiple spaces in a row");

            var testString = "ab   ba";
            
            return CheckPalindromeResult(testString, trueResult);
        }

        //Positive test case with special symbols
        public static bool TestCase8()
        {
            Console.WriteLine("TC8 - Positive, with special symbols");

            var testString = "\".%&!()@``@)(!&%.\"";
            
            return CheckPalindromeResult(testString, trueResult);
        }

        //Positive test case with one symbol
        public static bool TestCase9()
        {
            Console.WriteLine("TC9 - Positive, one symbol");

            var testString = "a";
            
            return CheckPalindromeResult(testString, trueResult);
        }

        //Positive test case with UNICODE
        public static bool TestCase10()
        {

            Console.WriteLine("TC10 - Positive, unicode");

            var testString = "привет тевирп";

            return CheckPalindromeResult(testString, trueResult);
        }

        //Positive test case with upper case letters
        public static bool TestCase11()
        {

            Console.WriteLine("TC11 - Positive, upper case");

            var testString = "Do od";

            return CheckPalindromeResult(testString, trueResult);
        }

        //----------------------SCENARIOS WITH FALSE RESULT---------------------

        // test case with even letters without spaces
        public static bool TestCaseF1()
        {
            Console.WriteLine("TC-F1 - false, even, w/o spaces");

            var testString = "abab";
            return CheckPalindromeResult(testString, falseResult);
        }

        // test case with odd letters without spaces
        public static bool TestCaseF2()
        {
            Console.WriteLine("TC-F2 - false, odd, w/o spaces");

            var testString = "abcab";
            return CheckPalindromeResult(testString, falseResult);
        }

        // test case with even letters with spaces
        public static bool TestCaseF3()
        {
            Console.WriteLine("TC-F3 - false, even, w spaces");

            var testString = "a a a v";
            return CheckPalindromeResult(testString, falseResult);
        }

        // test case with odd letters with spaces
        public static bool TestCaseF4()
        {
            Console.WriteLine("TC-F4 - false, odd, w spaces");

            var testString = "a a v a v";
            return CheckPalindromeResult(testString, falseResult);
        }

        // test case with even letters with asymmetric spaces
        public static bool TestCaseF5()
        {
            Console.WriteLine("TC-F5 - false, even, w asymmetric spaces");

            var testString = "aa a v";
            return CheckPalindromeResult(testString, falseResult);
        }

        // test case with odd letters with asymmetric spaces
        public static bool TestCaseF6()
        {
            Console.WriteLine("TC-F6 - false, odd, w asymmetric spaces");

            var testString = "a a v av";
            return CheckPalindromeResult(testString, falseResult);
        }

        // test case with multiple spaces in a row
        public static bool TestCaseF7()
        {
            Console.WriteLine("TC-F7 - false, multiple spaces in a row");

            var testString = "ab b      c";
            return CheckPalindromeResult(testString, falseResult);
        }

        // test case with special symbols
        public static bool TestCaseF8()
        {
            Console.WriteLine("TC-F8 - false, special symbols");

            var testString = "\".%&!()@`---+`@)(!&%.\"";
            return CheckPalindromeResult(testString, falseResult);
        }

        //test case with UNICODE
        //This TC is neccessary, because he is failed on some PCs and work great on my. Maybe problem with encoding
        public static bool TestCaseF9()
        {

            Console.WriteLine("TCF9 - false, unicode");

            var testString = "привет пока";

            return CheckPalindromeResult(testString, falseResult);
        }

        //test case with upper case letters
        public static bool TestCaseF10()
        {

            Console.WriteLine("TCF10 - false, upper case");

            var testString = "Do DDO";

            return CheckPalindromeResult(testString, falseResult);
        }

        //-------------NEGATIVE SCENARIOS-----------------

        //Negative test with incorrect data - empty entry
        //Comment: It is not clear, if empty row is considered a palindrome,
        //because palindrome is a row of symbols which can be read similarly both ways
        public static bool TestCaseID1()
        {
            Console.WriteLine("TC-ID1 - Empty entry");

            var testString = "";
            return CheckPalindromeResult(testString, falseResult);
        }

        //Negative test with incorrect data - only space
        //Comment: By the rules of palindrome space is not important, 
        //therefore there is can be 2 ways to check if it is palindrome: exact comparison or comparing without spaces
        //we choose second way
        public static bool TestCaseID2()
        {
            Console.WriteLine("TC-ID2 - Space string");

            var testString = " ";
            return CheckPalindromeResult(testString, falseResult);
        }


        //Negative test with incorrect data - null entry
        //Comment: This case is not accessible via user interface but necessary for testing is we speak about a stand-alone function
        public static bool TestCaseID3()
        {
            Console.WriteLine("TC-ID2 - Null entry");

            var testString = (string) null;
            return CheckPalindromeResult(testString, falseResult);
        }

        //----------method executor with check
        private static bool CheckPalindromeResult(string testString, bool trueResult)
        {
            var result = Functions.IsStringPalindrome(testString);
            Console.WriteLine($"Tested value: \"{testString ?? "null"}\". Execution result: {result}, test {(result ? "passed" : $"failed, expected result: {trueResult}")}");
            return result == trueResult;
        }
    }
}