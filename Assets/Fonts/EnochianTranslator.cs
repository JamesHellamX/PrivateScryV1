using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;

public class EnochianTranslator
{
    // Method to translate English phrases to Enochian-like phrases
    public static string TranslateToEnochian(string englishPhrase)
    {
        // Split the English phrase into individual words
        string[] words = englishPhrase.Split(' ');

        // StringBuilder to store the Enochian-like translation
        StringBuilder enochianPhrase = new StringBuilder();

        // Dictionary of mappings from English letters to Enochian-like symbols or sounds
        Dictionary<char, string> letterMappings = new Dictionary<char, string>
        {
            {'a', "An"},
            {'b', "Ba"},
            {'c', "Com"},
            {'d', "Dor"},
            {'e', "En"},
            {'f', "Fa"},
            {'g', "Gon"},
            {'h', "Ha"},
            {'i', "Ish"},
            {'j', "Jun"},
            {'k', "Ka"},
            {'l', "Lus"},
            {'m', "Mol"},
            {'n', "Nim"},
            {'o', "Om"},
            {'p', "Pol"},
            {'q', "Quar"},
            {'r', "Run"},
            {'s', "Sol"},
            {'t', "Tar"},
            {'u', "Urn"},
            {'v', "Van"},
            {'w', "Wen"},
            {'x', "Xol"},
            {'y', "Yar"},
            {'z', "Zel"}
            // You can extend this dictionary with more mappings as needed
        };

        // Translate each word in the English phrase to Enochian-like form
        foreach (string word in words)
        {
            // Translate each character in the word
            foreach (char letter in word.ToLower())
            {
                // Append the Enochian-like symbol or sound for the letter
                if (letterMappings.ContainsKey(letter))
                {
                    enochianPhrase.Append(letterMappings[letter]);
                }
                else
                {
                    // If the letter is not in the dictionary, just append it as is
                    enochianPhrase.Append(letter);
                }
            }

            // Add space between words
            enochianPhrase.Append(" ");
        }

        // Trim any leading or trailing whitespace
        return enochianPhrase.ToString().Trim();
    }

    /* Example usage
    public static void Main(string[] args)
    {
        // English phrase to translate
        string englishPhrase = "hear me detective";

        // Translate the English phrase to Enochian-like form
        string enochianPhrase = TranslateToEnochian(englishPhrase);

        // Print the translated phrase
        Console.WriteLine(enochianPhrase);
    }*/
    
}





