using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class Word
{
    public string Text { get; set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public string GetDisplayText()
    {
        return IsHidden ? new string('*', Text.Length) : Text;
    }
}

class Reference
{
    public string Verse { get; set; }

    public Reference(string verse)
    {
        Verse = verse;
    }

    public string GetDisplayText()
    {
        return Verse;
    }
}

class Scripture
{
    public List<Word> Words { get; private set; }
    public Reference Reference { get; private set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int numWordsToHide)
    {
        Random random = new Random();

        for (int i = 0; i < numWordsToHide; i++)
        {
            int index = random.Next(Words.Count);
            Words[index].IsHidden = true;
        }
    }

    public bool AreAllWordsHidden()
    {
        return Words.All(word => word.IsHidden);
    }

    public string GetDisplayText()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Reference.GetDisplayText()).Append("\n");

        foreach (Word word in Words)
        {
            sb.Append(word.GetDisplayText()).Append(" ");
        }

        return sb.ToString().Trim();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the scripture reference (e.g., John 3:16):");
        string verse = Console.ReadLine();

        Console.WriteLine("Enter the scripture text:");
        string text = Console.ReadLine();

        Reference reference = new Reference(verse);
        Scripture scripture = new Scripture(reference, text);

        while (!scripture.AreAllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            scripture.HideRandomWords(3); // Hide 3 words at a time
        }

        Console.WriteLine("All words in the scripture are hidden. Program ending.");
    }
}
