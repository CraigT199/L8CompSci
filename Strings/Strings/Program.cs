using System.Security.Permissions;
using System.Text;

void PrintList(List<string> list)
{
    String str = String.Join(", ",list);
    Console.WriteLine($"[{str}]");
}

List<string> Wave(string input)
{
    List<string> list = new List<string> { };
    for (int c = 0; c < input.Length; c++) {
        string output = "";
        for (int i = 0; i < input.Length; i++)
        {
            if (i == c)
                output += input[i].ToString().ToUpper();
            else
                output += input[i].ToString();
        }
        list.Add(output);
    }
    return list;
}

void ToCode(string s)
{
    List<int> output = new List<int> { };
    foreach (char c in s)
    {
        output.Add((int)c);
    }
    Console.WriteLine($"{s}: {String.Join(' ', output)}");
}

void ToByteCode(string s)
{
    byte[] byteArray = Encoding.Default.GetBytes(s);
    Console.WriteLine($"{s}: {String.Join(' ', byteArray)}");
}

String ToString(int[] charCodes)
{
    return charCodes == null ? null : string.Concat(Array.ConvertAll(charCodes, code => (char)code));
}

PrintList(Wave("hello"));
ToCode("Hello");
ToCode("你好");
ToByteCode("Hello");
ToByteCode("你好");

Console.WriteLine(ToString([72, 101, 108, 108, 111]));
