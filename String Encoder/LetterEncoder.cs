using System.Text;

public class Encoder
{
    private static readonly string referenceString = "the quick and brown fox jumps over the lazy dog";

    public static string Encode(string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            throw new ArgumentNullException(nameof(inputString), "Input string cannot be null or empty.");
        }

        StringBuilder encodedStringBuilder = new StringBuilder();
        foreach (char letter in inputString)
        {
            int wordIndex = referenceString.IndexOf(letter);
            if (wordIndex != -1)
            {
                int letterIndex = referenceString.Substring(wordIndex).IndexOf(letter);
                encodedStringBuilder.Append($"{wordIndex}{letterIndex},");
            }
        }
      
         //trial for empty space to hash
        inputString = inputString.Replace(" ", "-");

        //ringBuilder encodedStringBuilder = new StringBuilder();
        foreach (char letter in inputString)
        {
            int wordIndex = referenceString.IndexOf(letter);
            if (wordIndex != -1)
            {
                int letterIndex = referenceString.Substring(wordIndex).IndexOf(letter);
                encodedStringBuilder.Append($"{wordIndex}{letterIndex},");
            }
        }


        
        if (encodedStringBuilder.Length > 0)
        {
            encodedStringBuilder.Remove(encodedStringBuilder.Length - 1, 1);
        }

        return encodedStringBuilder.ToString();
    }
}
