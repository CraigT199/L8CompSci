void Countdown(int n)
{
    for (int i = n; i > 0; --i)
    {
        Console.WriteLine(i);
    }
    Console.WriteLine("Blast-off");
}

void StarTriangle(int n)
{
    for (int i = 1; i <= n; i++)
    {
        // Stack Overflow
        Console.WriteLine(String.Concat(Enumerable.Repeat("*", i)));
    }
}

void Grid(int y, int x)
{
    for (int i = 1; i <= y; i++)
    {
        Console.WriteLine(String.Concat(Enumerable.Repeat("+---", x)) + "+");
        Console.WriteLine(String.Concat(Enumerable.Repeat("|   ", x)) + "|");
    }
    Console.WriteLine(String.Concat(Enumerable.Repeat("+---", x)) + "+");
}

void GridV2(int y, int x)
{
    for (int i = 1; i <= y; i++)
    {
        Console.WriteLine(String.Concat(Enumerable.Repeat("┼───", x)) + "┼");
        Console.WriteLine(String.Concat(Enumerable.Repeat("│   ", x)) + "│");
    }
    Console.WriteLine(String.Concat(Enumerable.Repeat("┼───", x)) + "┼");
}

void Menu()
{
    Console.WriteLine("Question Number:");
    string question = Console.ReadLine();

    switch (question)
    {
        case "1":
            Countdown(5);
            break;
        case "2":
            StarTriangle(5);
            break;
        case "3":
            Grid(5, 5);
            break;
        case "4":
            GridV2(5, 5);
            break;
        default:
            Console.WriteLine("Invalid Input");
            Menu();
            break;
    }
}

void Ask(int n)
{
    int total = 0;
    for (int i = 0; i < n; i++)
    {
        Console.Write($"Num {i + 1}: ");
        string input = Console.ReadLine();

        int num = 0;
        try
        {
            num = Int32.Parse(input);
            total += num;
        }
        catch (FormatException)
        {
            Console.WriteLine("Input is not integer");
            i--;
        }
    }
    Console.WriteLine($"Total: {total}");
    Console.WriteLine($"Mean: {total / n}");
}

bool IsPrime(int a)
{
    int numFactors = 0;
    for (int i = 1; i <= a; i++)
    {
        if (a % i == 0)
        {
            numFactors++;
        }
    }
    if (numFactors == 2)
        return true;
    return false;
}

bool IsPerfect(int a)
{
    int sumFactors = 0;
    for (int i = 1; i < a; i++)
    {
        if (a % i == 0)
        {
            sumFactors += i;
        }
    }
    if (sumFactors == a)
        return true;
    return false;
}

bool isAbundant(int a)
{
    int total = 0;
    for (int i = 1; i <= a; i++)
    {
        if (a % i == 0)
        {
            total += a;
        }
    }
    return total > a;
}

bool IsFriendly(int a, int b)
{
    int totalA = 0;
    int totalB = 0;
    for (int i = 1; i <= a; i++)
    {
        if (a % i == 0)
        {
            totalA += a;
        }
    }
    for (int i = 1; i <= b; i++)
    {
        if (b % i == 0)
        {
            totalB += b;
        }
    }
    return totalA / a == totalB / b;
}