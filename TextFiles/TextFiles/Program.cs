using System.Diagnostics;
using System.Text;
using Microsoft.VisualBasic;

void WriteToFile(string fileName)
{
    StringBuilder sb = new StringBuilder();
    string input = "abc";
    while (input != "")
    {
        input = Console.ReadLine();
        if (input == "")
            break;
        sb.Append($"{input}\n");
    }
    if (!File.Exists(fileName))
        File.WriteAllText(fileName, sb.ToString());
    else
    {
        Console.WriteLine($"File at {fileName} already exists");
        File.AppendAllText(fileName, sb.ToString());
    }
}

List<string> FindStation(string fileName, string str)
{
    List<string> output = new List<string> { };
    foreach (var line in File.ReadAllLines(fileName))
    {
        if (line.ToLower().Contains(str))
            output.Add(line);
    }
    return output;
}

List<string> FindNoSharedLetters(string fileName, string str)
{
    List<string> output = new List<string> { };
    foreach (var line in File.ReadAllLines(fileName))
    {
        string[] sections = line.Split(',');
        bool contains = false;
        foreach (char c in str)
        {
            if (sections[0].ToLower().Contains(c))
            {
                contains = true;
                break;
            }
        }
        if (!contains)
        {
            output.Add(line);
        }
    }
    return output;
}

List<string> AlliterationStations(string fileName)
{
    List<string> output = new List<string> { };
    foreach (var line in File.ReadAllLines(fileName))
    {
        string[] sections = line.Split(',');
        string[] names = sections[0].Split(' ');
        if (names.Count() != 2)
            continue;
        else
        {
            if (names[1][0] == names[0][0])
            {
                output.Add(line);
            }
        }
    }
    return output;
}

// Question 2
Debug.Assert(FindStation("./stations.txt", "station").SequenceEqual(new List<string> { "Battersea Power Station, Northern" }));
// Question 3
Debug.Assert(FindNoSharedLetters("./stations.txt", "mackerel").SequenceEqual(new List<string>{ "St. John's Wood, Jubilee"}));
Debug.Assert(FindNoSharedLetters("./stations.txt", "piranha").SequenceEqual(new List<string> { "Stockwell, Victoria, Northern" }));
Debug.Assert(FindNoSharedLetters("./stations.txt", "sturgeon").SequenceEqual(new List<string> { "Balham, Northern", "Blackwall, Docklands Light Railway" }));
Debug.Assert(FindNoSharedLetters("./stations.txt", "bacteria").SequenceEqual(new List<string> { }));
// Question 4
Debug.Assert(AlliterationStations("./stations.txt").SequenceEqual(new List<string> {"Charing Cross, Bakerloo, Northern", "Clapham Common, Northern", "Golders Green, Northern", "Seven Sisters, Victoria", "Sloane Square, Circle, District"}));