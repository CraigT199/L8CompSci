const int BLOCKSIZE = 512;

Console.Write("Num 1: ");
string input1 = Console.ReadLine();
Console.Write("Num 2: ");
string input2 = Console.ReadLine();

int num1 = 0;
int num2 = 0;

try
{
    num1 = Int32.Parse(input1);
    num2 = Int32.Parse(input2);
}
catch (FormatException)
{
    Console.WriteLine("Inputs are not integers");
}

static void IsEqual(int num1, int num2)
{
    if (num1 == num2)
    {
        Console.WriteLine("Num 1 is equal to Num 2");
    }
}

static void IsEven(int num)
{
    if (num % 2 == 0)
    {
        Console.WriteLine("Even");
    }
    else
    {
       Console.WriteLine("Odd"); 
    }
}

static void IsLeapYear(int year)
{
    if (year % 4 == 0)
    {
        Console.WriteLine($"{year} is a leap year");
    }
    else
    {
        Console.WriteLine($"{year} is not a leap year");
    }
}

static string FizzBuzz(int num)
{
    string fb = "";
    if (num % 3 == 0)
    {
        fb += "Fizz";
    }
    if (num % 5 == 0)
    {
        fb += "Buzz";
    }
    else if (!(num % 3 == 0 || num % 5 == 0))
    {
        fb = num.ToString();
    }
    return fb;
}

static int Factors(int num)
{
    int numFactors = 0;
    for (int i = 1; i <= num; i++)
    {
        if (num % i == 0)
        {
            numFactors++;
        }
    }
    return numFactors;
}

static bool IsVowel(String input)
{
    switch (input)
    {
        case "a":
        case "e":
        case "i":
        case "o":
        case "u":
        case "A":
        case "E":
        case "I":
        case "O":
        case "U":
            return true;
    }
    return false;
}

static int NumBlocks(float filesize)
{
    return (int)Math.Ceiling(filesize / BLOCKSIZE);
}

static void Savings()
{
    Console.Write("Weekly Earnings: ");
    string input1 = Console.ReadLine();
    Console.Write("Percentage to Save: ");
    string input2 = Console.ReadLine();

    float weeklyEarnings = 0;
    float percentage = 0;

    try
    {
        weeklyEarnings = float.Parse(input1);
        percentage = float.Parse(input2);
    }
    catch (FormatException)
    {
        Console.WriteLine("Inputs are not integers");
    }

    float week = percentage / 100 * weeklyEarnings;
    float year = week * 52;

    Console.WriteLine($"Weekly Savings: £{week:F2}");
    Console.WriteLine($"Annual Savings: £{year:F2}");
}

