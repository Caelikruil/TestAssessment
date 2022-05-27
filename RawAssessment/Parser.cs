using System;
using System.Collections.Generic;
using System.Linq;


//This class is used to prepare and validate input for functions
public class Parser
{
    //Separator for input row for task with searching of multipliers
    public const char separator = ',';

    //Convert string to int array and remove every non-integer entries
    public static List<int> IntArrayParse(String input)
        => input.Split(separator)
            .Select(c => int.TryParse(c, out int value) ? (int?)value : null)
            .Where(c => c is not null)
            .Select(c => (int)c).ToList();

    //Convert input string to lowercase and trim every space character
    //because palindrome is only about symbols
    public static string SimplifyStringInput(string input)
        => input?.ToLower().Replace(" ", string.Empty) ?? null;
}
