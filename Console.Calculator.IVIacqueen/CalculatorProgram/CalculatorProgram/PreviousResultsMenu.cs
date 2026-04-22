using System;

namespace CalculatorProgram;

internal class PreviousResultsMenu
{
    internal static string DisplayMenu()
    {
        string? resultSelection = "";
        string? actionSelection = "";
        int resultIndex = 0;
        string resultValue = "";
        bool isValidInput = false;

        do
        {
            Console.Clear();

            PreviousResults.DisplayResults();
            Console.WriteLine("\nType the index of the result you wish to use, or Enter to go back");
            resultSelection = Console.ReadLine();

            if (int.TryParse(resultSelection, out resultIndex))
            {
                resultIndex--; // Adjust index to be zero-based

                Console.WriteLine("Type 'U' to use or 'D' to delete the result");
                actionSelection = Console.ReadLine();

                if (actionSelection.ToLower() == "u")
                {
                    try
                    {
                        resultValue = "" + PreviousResults.SelectResult(resultIndex);
                        isValidInput = true;
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine("Invalid index. Press Enter to continue. Details: " + e.Message);
                        Console.ReadLine();
                        continue;
                    }
                }
                else if (actionSelection.ToLower() == "d")
                {
                    try
                    {
                        PreviousResults.DeleteResult(resultIndex);
                        Console.WriteLine("Result deleted successfully. Press Enter to continue.");
                        Console.ReadLine();
                        isValidInput = true;
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine("Invalid index. Press Enter to continue. Details: " + e.Message);
                        Console.ReadLine();
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid action. Press Enter to continue");
                    Console.ReadLine();
                }
            }
            else if (String.IsNullOrEmpty(resultSelection))
            {
                isValidInput = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to continue");
                Console.ReadLine();
            }
        } while (!isValidInput);

        return resultValue;
    }
}
