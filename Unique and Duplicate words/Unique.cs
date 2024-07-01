using System;
using System.Collections.Generic;
using System.Linq;

internal class Unique
{
    static (List<string>, List<string>) SeparateUniqueAndDuplicateWords(string inputString)
    {
        if (inputString == null)
            throw new NullReferenceException("Input string cannot be null.");
        else if (string.IsNullOrWhiteSpace(inputString))
            throw new Exception("EmptyStringArgument: Input string cannot be empty.");

        // Convert the input string to lowercase and split it into words
        string[] words = inputString.ToLower().Split(new[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        // Initialize dictionaries to store word counts
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();
        List<string> uniqueWords = new List<string>();
        List<string> duplicateWords = new List<string>();

        // Count the occurrences of each word
        foreach (string word in words)
        {
            if (wordCounts.ContainsKey(word))
                wordCounts[word]++;
            else
                wordCounts[word] = 1;
        }

        // Separate unique and duplicate words
        foreach (var kvp in wordCounts)
        {
            if (kvp.Value == 1)
                uniqueWords.Add(kvp.Key);
            else
                duplicateWords.Add(kvp.Key);
        }

        return (uniqueWords, duplicateWords);
    }

    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter a sentence: ");
            string inputString = Console.ReadLine();

            var (uniqueWords, duplicateWords) = SeparateUniqueAndDuplicateWords(inputString);

            Console.WriteLine("Unique: " + string.Join(", ", uniqueWords));
            Console.WriteLine("Duplicate: " + string.Join(", ", duplicateWords));
        }
        catch (NullReferenceException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
