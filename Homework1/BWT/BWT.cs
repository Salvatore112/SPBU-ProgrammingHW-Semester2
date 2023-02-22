namespace BWT;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Class that contains a BWT transform implementation.
static class BWT
{
    static string Rotate(String oldString)
    {
        string newString = "" + oldString[oldString.Length - 1];
        for (int i = 0; i < oldString.Length - 1; i++)
        {
            newString += oldString[i];
        }

        return newString;
    }

    // Function that puts a string through BWT transformation.
    public static string Encode(string oldString, ref int position)
    {
        string buffer = oldString;
        var table = new string[buffer.Length];
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

    // Function thant decodes string that was put through BWT transformation.
    public static string Decode(string encodedString, int position)
    {
        var buffer = new List<string>();
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

    // Tests for BWT tranfsormation implementation functions.
    public static bool Tests()
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