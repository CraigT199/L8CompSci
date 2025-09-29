const double mphConversion = 2.23694;

static double ConvertMPS(int m, int s)
{
    return 10000 / (m * 60 + s);
}

static double ConvertMPH(double mps)
{
    return mps * mphConversion;
}

static void RaceConversions()
{
    Console.Write("Minutes: ");
    string input1 = Console.ReadLine();
    Console.Write("Seconds: ");
    string input2 = Console.ReadLine();

    int m = 0;
    int s = 0;

    try
    {
        m = Int32.Parse(input1);
        s = Int32.Parse(input2);
    }
    catch (FormatException)
    {
        Console.WriteLine("Inputs are not integers");
    }

    double mps = ConvertMPS(m, s);
    Console.WriteLine(mps);
    Console.WriteLine(ConvertMPH(mps));
}

static void MultiTable(int num, int rows)
{
    int maxValue = num * rows;
    int cellWidth = maxValue.ToString().Length;

    for (int i = 1; i <= rows; i++)
    {
        int product = num * i;
        Console.WriteLine($"{num} x {i,2} = {product.ToString().PadLeft(cellWidth)}");
    }
}

static void Circle(char choice, double input, int numPoints)
{
    double radius = 0.0;
    switch (choice)
    {
        case 'r':
            radius = input;
            break;
        case 'a':
            radius = Math.Sqrt(input / Math.PI);
            break;
        case 'c':
            radius = input / (2 * Math.PI);
            break;
    }

    double area = Math.PI * radius * radius;
    double circumference = 2 * Math.PI * radius;

    Console.WriteLine($"Radius: {radius:F2}");
    Console.WriteLine($"Area: {area:F2}");
    Console.WriteLine($"Circumference: {circumference:F2}");

    Random rnd = new Random();
    int inside = 0;

    for (int i = 1; i <= numPoints; i++)
    {
        double x = rnd.NextDouble();
        double y = rnd.NextDouble();

        if (x * x + y * y <= 1.0)
        {
            inside++;
        }
    }

    double piEstimate = 4.0 * inside / numPoints;
    Console.WriteLine($"Estimated Value of Pi = {piEstimate}");
}

Circle('r', 1, 1000000);