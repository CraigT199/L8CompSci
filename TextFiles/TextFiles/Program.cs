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

string MostStations(string fileName)
{
    Dictionary<string, int> tubeLines = new Dictionary<string, int> { };
    foreach (var line in File.ReadAllLines(fileName))
    {
        string[] sections = line.Split(", ");
        string tubeLine = sections.Last();
        if (tubeLines.ContainsKey(tubeLine))
            tubeLines[tubeLine] += 1;
        else
            tubeLines[tubeLine] = 1;
    }
    // Stack Overflow
    return tubeLines.MaxBy(line => line.Value).Key;
}

Dictionary<string, int> GetWordFrequency(string fileName)
{
    Dictionary<string, int> frequencies = new Dictionary<string, int>();
    foreach (var line in File.ReadAllLines(fileName))
    {
        string word = "";
        foreach (char c in line)
        {
            if (char.IsLetter(c))
                word += char.ToLowerInvariant(c);
            else if (word.Length > 0)
            {
                if (frequencies.ContainsKey(word))
                    frequencies[word] += 1;
                else
                    frequencies[word] = 1;
                word = "";
            }
        }
        if (word.Length > 0)
        {
           if (frequencies.ContainsKey(word))
                    frequencies[word] += 1;
            else
                frequencies[word] = 1; 
        }
    }
    return frequencies.OrderByDescending(frequency => frequency.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
}

// Question 2
Debug.Assert(FindStation("./stations.txt", "station").SequenceEqual(new List<string> { "Battersea Power Station, Northern" }));
// Question 3
Debug.Assert(FindNoSharedLetters("./stations.txt", "mackerel").SequenceEqual(new List<string>{ "St. John's Wood, Jubilee"}));
Debug.Assert(FindNoSharedLetters("./stations.txt", "piranha").SequenceEqual(new List<string> { "Stockwell, Victoria, Northern" }));
Debug.Assert(FindNoSharedLetters("./stations.txt", "sturgeon").SequenceEqual(new List<string> { "Balham, Northern", "Blackwall, Docklands Light Railway" }));
Debug.Assert(FindNoSharedLetters("./stations.txt", "bacteria").SequenceEqual(new List<string> { }));
// Question 4
Debug.Assert(AlliterationStations("./stations.txt").SequenceEqual(new List<string> { "Charing Cross, Bakerloo, Northern", "Clapham Common, Northern", "Golders Green, Northern", "Seven Sisters, Victoria", "Sloane Square, Circle, District" }));
// Question 5
Debug.Assert(MostStations("./stations.txt") == "District");
// Question 6
var frequencies = GetWordFrequency("./stations.txt");
Debug.Assert(frequencies.Take(5).SequenceEqual(new Dictionary<string, int> { ["district"] = 60, ["piccadilly"] = 54, ["central"] = 54, ["northern"] = 52, ["docklands"] = 45 }));
