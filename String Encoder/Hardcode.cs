using System;
using System.Collections.Generic;

namespace SampleConApp
{
    class TextEncoder
    {
        private string baseText = "The quick and brown fox jumps over the Lazy Dog";

        public string Encode(string input)
        {

            if (input == null)
            {
                throw new NullReferenceException("Input string cannot be null.");
            }


            if (input.Trim().Length == 0)
            {
                throw new ArgumentException("Input string cannot be empty.", "input");
            }

            string[] words = baseText.ToLower().Split(' ');
            Dictionary<char, string> letterCodes = new Dictionary<char, string>();


            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    char letter = words[i][j];
                    if (!letterCodes.ContainsKey(letter))
                    {
                        letterCodes[letter] = i.ToString() + j.ToString();
                    }
                }
            }


            List<string> encodedStrings = new List<string>();
            foreach (char c in input.ToLower())
            {
                if (letterCodes.ContainsKey(c))
                {
                    encodedStrings.Add(letterCodes[c]);
                }
            }


            return string.Join(",", encodedStrings);
        }
    }

    class StringEncoder
    {
        static void Main(string[] args)
        {
            TextEncoder encoder = new TextEncoder();


            string input = "banglore";

            try
            {
                string encodedResult = encoder.Encode(input);
                Console.WriteLine(encodedResult);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("NullReferenceException: " + ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("ArgumentException: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }  }