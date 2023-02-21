using System;

namespace bwt
{
    class Program
    {
        static void Main(string[] args)
        {
            if (BWT.Tests())
            {
                string oldString = "ABACABA";
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
    static class BWT
    {
        static public string Rotate(String oldString)
        {
            string newString = "" + oldString[oldString.Length - 1];
            for(int i = 0; i < oldString.Length - 1; i++) 
            { 
                newString += oldString[i];
            }
            return newString;
        }
        static public string Encode(string oldString, ref int position)
        {
            string buffer = oldString;
            string[] table = new string[buffer.Length];
            table[buffer.Length - 1] = buffer;
            for (int i = 0; i < buffer.Length - 1; i++)
            {
                buffer = BWT.Rotate(buffer);
                table[i] = buffer;
            }
            Array.Sort(table);
            string output = "";
            for (int i = 0; i < table.Length; i++) 
            { 
                output += table[i][oldString.Length - 1];
                if (table[i] == oldString)
                {
                    position = i;
                }
            }
            return output;
        }
        static public string Decode(string encodedString, int position)
        {
            List<string> buffer = new List<string>();
            for (int i = 0; i < encodedString.Length; i++)
            {
                buffer.Add("" + encodedString[i]);
            }
            
            while (buffer[0].Length != encodedString.Length)
            {
                buffer.Sort();
                for (int i = 0; i < encodedString.Length; i++)
                {
                    buffer[i] = encodedString[i] + buffer[i];
                }
                buffer.Sort();
            }
            return buffer[position];
        }
        static public bool Tests()
        {
            string testString1 = "SIX.MIXED.PIXIES.SIFT.SIXTY.PIXIE.DUST.BOXES";
            int testPosition1 = 0;
            string expectedResult1 = "TEXYDST.E.IXIXIXXSSMPPS.B..E.S.EUSFXDIIOIIIT";
            if (BWT.Encode(testString1, ref testPosition1) != expectedResult1)
            {
                Console.WriteLine("Tests failed on encoding");
                return false;
            }

            string testString2 = "TEXYDST.E.IXIXIXXSSMPPS.B..E.S.EUSFXDIIOIIIT";
            int testPosition2 = 29;
            testString2 = BWT.Decode(testString2, testPosition2);
            string expectedResult2 = "SIX.MIXED.PIXIES.SIFT.SIXTY.PIXIE.DUST.BOXES";
            if (testString2 != expectedResult2)
            {
                Console.WriteLine("Tests failed on decoding");
                return false;
            }
            return true;
        }
    }
}