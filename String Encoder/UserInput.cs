public class InputHandler
{
    public static string GetInputString()
    {
        Console.WriteLine("Enter a string:");
        string inputString = Console.ReadLine();

        if (string.IsNullOrEmpty(inputString))
        {
            throw new ArgumentException("Input string cannot be empty or null.");
        }

        return inputString;
    }

    public static string EncodeString(string inputString)
    {
        string encodedString = Encoder.Encode(inputString.ToLower());
        return encodedString.Replace(' ', '-');
    }

    public static void Main(string[] args)
    {
        try
        {
            string input = GetInputString();
            string encodedString = EncodeString(input);
            Console.WriteLine("Encoded string: {0}", encodedString);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: {0}", ex.Message);
        }
    }
}
