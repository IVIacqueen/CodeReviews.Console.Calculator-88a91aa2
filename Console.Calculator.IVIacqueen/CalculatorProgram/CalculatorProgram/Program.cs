using CalculatorLibrary;
using System.Text.RegularExpressions;

namespace CalculatorProgram;

class Program
{
    static void Main(string[] args)
    {
        bool endApp = false;
        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        Calculator calculator = new Calculator();
        while (!endApp)
        {
            double num1 = 0;
            double num2 = 0;
            double result = 0;

            // Ask the user to choose an operator.
            Console.WriteLine("Number of times calculator has been used: " + calculator.CalculatorUses);
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.WriteLine("\tr - Square Root");
            Console.WriteLine("\tp - To the Power");
            Console.WriteLine("\tg - Time to 10x value (in years).\n\t*Have to enter the rate of growth*");
            Console.WriteLine("\tts - Trigonometry: Sine");
            Console.WriteLine("\ttc - Trigonometry: Cosine");
            Console.WriteLine("\ttt - Trigonometry: Tangent");
            Console.Write("Your option? ");

            string? op = Console.ReadLine();

            // Validate input is not null, and matches the pattern
            if (op == null || !Regex.IsMatch(op, "[a|s|m|d|r|p|g|ts|tc|tt]"))
            {
                Console.WriteLine("Error: Unrecognized input.");
            }
            else
            {
                num1 = GetNumber();

                if (!Regex.IsMatch(op, "[r|g|ts|tc|tt]")) num2 = GetNumber();

                try
                {
                    result = calculator.DoOperation(num1, num2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else
                    {
                        PreviousResults.AddResult(result);
                        Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }
            }
            Console.WriteLine("------------------------\n");

            // Wait for the user to respond before closing.
            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;

            Console.WriteLine("\n");
        }
        calculator.Finish();
        return;
    }

    private static double GetNumber()
    {
        string? numInput = "";
        string previousValue = "";
        double cleanNum = 0;
        bool isValidInput = false;

        do
        {
            Console.Clear();

            Console.WriteLine("Enter 'h' to access previous results");
            Console.Write("Or Enter a number: ");
            numInput = Console.ReadLine();

            // Access previous results or gets a number
            if (numInput.ToLower() == "h")
            {
                previousValue = PreviousResultsMenu.DisplayMenu();

                isValidInput = double.TryParse(previousValue, out cleanNum);
            }
            else
            {
                isValidInput = double.TryParse(numInput, out cleanNum);
                if (!isValidInput)
                {
                    Console.WriteLine("This is not valid input, please try again.");
                    Console.ReadLine();
                }
            }
        } while (!isValidInput);

        return cleanNum;
    }
}