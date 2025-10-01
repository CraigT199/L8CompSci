using System.Text;

void PrintList(List<string> list)
{
    String str = "{";
    foreach (var item in list)
    {
        str += $" {item},";
    }
    str += "}";
    Console.WriteLine(str);
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



PrintList(Wave("hello"));
ToCode("Hello");
ToCode("你好");
ToByteCode("Hello");
ToByteCode("你好");

