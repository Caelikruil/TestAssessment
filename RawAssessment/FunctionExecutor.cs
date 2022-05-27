using System;

//FunctionExecutor - is user-interface methods provider
//It's purpose - ask user about input, validate it and call function
//Input is in inf cycle, so user can enter values until you decide to exit
public class FunctionExecutor
{
    //Function used for execution of function that count multipliers for 4 and 6
    public static void RunMultipliers()
    {
        while (true)
        {
            Console.WriteLine($"Enter your numbers divided by '{Parser.separator}' or type 'exit' to return to main menu:");
            
            var input = Console.ReadLine();

            if (input.ToLower().Trim() == "exit")
                break;
            
            //input for numbers check is parsed from string and remove every non integer values
            var numbers = Parser.IntArrayParse(input);

            //if we see, that array is empty, skip check and write error
            if (numbers.Count > 0)
            {
                var result = Functions.CheckForMultipliers(numbers);
                Console.WriteLine($"Number of multipliers for 4 and 6 are {result}");
                continue;
            }
            Console.WriteLine("Parse error! Please, try another input:");
        }
    }

    //Function for reading input string and execute function thats check is it palindrome or not
    public static void RunPalindrome()
    {
        while (true)
        {
            Console.WriteLine($"Enter your string to check it for palindrome or type 'exit' to return to main menu:");

            var input = Console.ReadLine();
            if (input.ToLower().Trim() == "exit")
                break;

            //call function and check bool answer - for true answer that its palindrome and for false - that it is not.
            Console.WriteLine(
                Functions.IsStringPalindrome(input)
                    ? "It is a palindrome"
                    : "It is not a palindrome");
        }
    }
}
