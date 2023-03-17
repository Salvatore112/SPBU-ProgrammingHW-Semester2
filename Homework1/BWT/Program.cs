namespace BWT;

using System;

class Program
{
    static void Main(string[] args)
    {
        if (BWT.Tests())
        {
            string oldString = "ABACASD";
            int position = 0;
            string encodedString = BWT.Encode(oldString, ref position);
            Console.WriteLine($"Example string - {oldString}");
            Console.WriteLine($"Encoded string - {encodedString}, position - {position}");
            Console.WriteLine($"Decoded string - {BWT.Decode(encodedString, position)}");
        }
        else
        {
            Console.WriteLine("Tests weren't passed");
        }
    }
}

