using System;

class Program
{
    static void Main(string[] args)
    {
        
        Reference reference = new Reference("1 Nephi", 11, 17);
        string text = "I know that He loveth His children; nevertheless, I do not know the meaning of all things.";

        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit" || scripture.IsCompletelyHidden())
                break;

            scripture.HideRandomWords(3); 
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nAll words are now hidden. Program has ended.");
    }
}