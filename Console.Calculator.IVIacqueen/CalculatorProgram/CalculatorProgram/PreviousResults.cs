namespace CalculatorProgram;

internal static class PreviousResults
{
    internal static List<double> previousResults = new List<double>()
    {
        78
    };

    internal static void AddResult(double result)
    {
        previousResults.Add(result);
    }

    internal static void DeleteResult(int index)
    {
        previousResults.RemoveAt(index);
    }

    internal static void DisplayResults()
    {
        Console.Clear();
        if (previousResults.Count == 0)
        {
            Console.WriteLine("There are no previous results to display");
        }
        else
        {
            Console.WriteLine("Previous Results:");
            for (int i = 0; i < previousResults.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {previousResults[i]}");
            }
        }
    }

    internal static double SelectResult(int index)
    {
        return previousResults[index];
    }
}
