using System.Text;

namespace LZWTask;

internal class LZW
{
   public void Compress(string filePath)
    {
        string zippedFileName = GetName(filePath);
        var fileStream = new FileStream($@"D:\LZWTask\{zippedFileName}.zipped", FileMode.Create, FileAccess.Write);
        var output = new StreamWriter(fileStream);

        byte[] arrayOfBytes = File.ReadAllBytes(filePath);

        var trie = new Trie();

        for (int i = 0; i < 256; i++)
        {
            trie.AddWithKey(((char)i).ToString(), ((char)i));
        }

        string currentString = "";
        int keyCount = 0;

        foreach (char character in arrayOfBytes)
        {
            string newString = currentString + character;
            if (trie.Contains(newString))
            {
                currentString = newString;
            }
            else
            {
                byte[] buffer = BitConverter.GetBytes(trie.GetKey(currentString.ToString()));
                trie.AddWithKey(currentString + character, ((char)(256 + keyCount)));
                keyCount++;
                foreach (byte b in buffer)
                {
                    fileStream.WriteByte(b);
                }
                currentString = character.ToString();
            }
        }
    }

    public static string Decompress(List<int> compressed)
    {
        Dictionary<int, string> dictionary = new Dictionary<int, string>();
        for (int i = 0; i < 256; i++)
        {
            dictionary.Add(i, ((char)i).ToString());
        }
            
        string tempString = dictionary[compressed[0]];
        compressed.RemoveAt(0);
        StringBuilder decompressed = new StringBuilder(tempString);

        foreach (int k in compressed)
        {
            string sequence = "";
            
            if (dictionary.ContainsKey(k))
            {
                sequence = dictionary[k];
            }
                
            else if (k == dictionary.Count)
            {
                sequence = tempString + tempString[0];
            }
                
            decompressed.Append(sequence);
            
            dictionary.Add(dictionary.Count, tempString + sequence[0]);

            tempString = sequence;
        }

        return decompressed.ToString();
    }

    private string GetName(string path)
    {
        string[] names = path.Split('\\');
        names = names[names.Length - 1].Split('.');
        return names[0];
    }
}



    