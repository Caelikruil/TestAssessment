using System;
using System.Collections.Generic;
using System.Linq;

//Class with functions described in task 1
class Functions
{

    //Get array of int for input and return count of numbers, who is 
    //multiplier of 4 or 6
    public static int CheckForMultipliers(List<int> numbers)
    {
        //Using LINQ we check the remainder of the division and if one of check is valid - proceed with number
        //after checks - we count of numbers who passed the rule
        return numbers?
            .Where(number => 
                //0 is special, skip it
                number != 0
                //check remainders of 4 or six
                && (number % 4 == 0 || number % 6 == 0))           
            .Count() ?? 0;

        //If it is needed to solve it without LINQ, code will be
        /*
         int counter = 0;
        foreach (int number in numbers)
        {
            if (number != 0 && (number % 4 == 0 || number % 6 == 0))
                counter++;
        }
        return counter;
         */
    }

    //Get prepared string for input and check if it halfs is similar
    public static bool IsStringPalindrome(string input)
    {
        //Prepare string by removing spaces and make it lower-case
        var preparedInput = Parser.SimplifyStringInput(input);

        //check if it is empty string - return false
        //and compare string by it reversed self
        return !string.IsNullOrWhiteSpace(preparedInput)
            && preparedInput.Equals(new string(preparedInput.Reverse().ToArray()));
    }
}
