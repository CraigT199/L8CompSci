using System.Text;

// string Decrypt(string word, int shift)
// {
//     shift = shift % 26;

//     char[] letters = word.ToCharArray();

//     for (int i = 0; i < letters.Length; i++)
//     {
//         char letter = letters[i];
//         if (char.IsLetter(letter))
//         {
//             if (char.IsUpper(letter))
//             {
//                 letter = (char)(letter - shift);
//                 if (letter < 'A')
//                 {
//                     letter = (char)(letter + 26);
//                 }
//             }
//             else if (char.IsLower(letter))
//             {
//                 letter = (char)(letter - shift);
//                 if (letter < 'a')
//                 {
//                     letter = (char)(letter + 26);
//                 }
//             }
//             letters[i] = letter;
//         }
//     }
//     return new string(letters);
// }

// Dictionary<char, int> GetLetterFrequency(string encrypted)
// {
//     Dictionary<char, int> frequencies = new Dictionary<char, int>();
//     foreach (char c in encrypted)
//     {
//         if (char.IsLetter(c))
//         {
//             if (frequencies.ContainsKey(c))
//                 frequencies[c] += 1;
//             else
//                 frequencies[c] = 1;
//         }
//     }
//     return frequencies.OrderByDescending(frequency => frequency.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
// }

// int GetLetterShift(Dictionary<char, int> frequencies, char startingLetter)
// {
//     int shift = 0;
//     char mostFrequent = frequencies.Keys.First();
//     if (char.IsUpper(mostFrequent))
//         shift = mostFrequent-char.ToUpper(startingLetter);
//     else
//         shift = mostFrequent-startingLetter;
//     return shift;
// }

// string contents = File.ReadAllText("./Cipher1.txt");
// Console.WriteLine(Decrypt(contents, GetLetterShift(GetLetterFrequency(contents),'e')));

byte[] Apply(byte[] text, byte[] key)
{
    if (key.Length != text.Length) return [0];

    byte[] output = new byte[text.Length];
    for (int i = 0; i < text.Length; i++)
    {
        output[i] = (byte)(text[i] ^ key[i]);
    }
    return output;
}

byte[] GenerateKey(int length)
{
    byte[] key = new byte[length];
    using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
    {
        rng.GetBytes(key);
    }
    return key;
}

string plaintext = "Hello World";
byte[] message = Encoding.UTF8.GetBytes(plaintext);
byte[] key = GenerateKey(message.Length);
byte[] ciphertext = Apply(message, key);
Console.WriteLine($"Cipher: {Encoding.UTF8.GetString(ciphertext)}");
byte[] decrypted = Apply(ciphertext, key);
Console.WriteLine($"Decrypted: {Encoding.UTF8.GetString(decrypted)}");