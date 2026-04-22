using Newtonsoft.Json;

namespace CalculatorLibrary;

public class Calculator
{
    JsonWriter writer;

    public int CalculatorUses { get; private set; }

    public Calculator()
    {
        StreamWriter logFile = File.CreateText("calculatorlog.json");
        logFile.AutoFlush = true;
        writer = new JsonTextWriter(logFile);
        writer.Formatting = Formatting.Indented;
        writer.WriteStartObject();
        writer.WritePropertyName("Operations");
        writer.WriteStartArray();
        CalculatorUses = 0;
    }

    public double DoOperation(double num1, double num2, string op)
    {
        double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.
        writer.WriteStartObject();
        writer.WritePropertyName("Operand1");
        writer.WriteValue(num1);
        writer.WritePropertyName("Operand2");
        writer.WriteValue(num2);
        writer.WritePropertyName("Operation");

        switch (op)
        {
            case "a":
                result = num1 + num2;
                writer.WriteValue("Add");
                break;
            case "s":
                result = num1 - num2;
                writer.WriteValue("Subtract");
                break;
            case "m":
                result = num1 * num2;
                writer.WriteValue("Multiply");
                break;
            case "d":
                if (num2 != 0)
                {
                    result = num1 / num2;
                }
                writer.WriteValue("Divide");
                break;
            case "r":
                if (num1 >= 0)
                {
                    result = Math.Sqrt(num1);
                }
                writer.WriteValue("Square Root");
                break;
            case "p":
                result = Math.Pow(num1, num2);
                writer.WriteValue("Power");
                break;
            case "g":
                if (num1 > 0 && num1 <= 100)
                {
                    result = 1 / Math.Log(num1 / 100 + 1, 10);
                }
                writer.WriteValue("Time to 10x value (in years)");
                break;
            case "ts":
                result = Math.Sin(num1 * Math.PI / 180);
                writer.WriteValue("Sine");
                break;
            case "tc":
                result = Math.Cos(num1 * Math.PI / 180);
                writer.WriteValue("Cosine");
                break;
            case "tt":
                result = Math.Tan(num1 * Math.PI / 180);
                writer.WriteValue("Tangent");
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }
        writer.WritePropertyName("Result");
        writer.WriteValue(result);
        writer.WriteEndObject();

        CalculatorUses++;

        return result;
    }

    public void Finish()
    {
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Close();
    }
}