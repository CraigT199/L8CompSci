int IntegerSum(int a, int b)
{
    return a + b;
}

double DoubleSum(double a, double b)
{
    return a + b;
}

int SumDigits(int a)
{
    int total = 0;
    foreach (char c in a.ToString())
    {
        total = total + (int)char.GetNumericValue(c);
    }
    return total;
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

int NumSpaces(string str)
{
    int spaces = 0;
    foreach (char c in str)
    {
        if (c == 0x0020)
        {
            spaces++;
        }
    }
    return spaces;
}

// Stack Overflow
void Swap(ref int x, ref int y)
{
    int temp = y;
    y = x;
    x = temp;
}

string Translate(int num, int baseNum)
{
    string converted = Convert.ToString(num, baseNum);
    if (baseNum == 2)
        converted = "0b" + converted;
    else if (baseNum == 16)
        converted = "0x" + converted;
    return converted;
}

static void MultiTable(int num = 5, int rows = 12)
{
    int maxValue = num * rows;
    int cellWidth = maxValue.ToString().Length;

    for (int i = 1; i <= rows; i++)
    {
        int product = num * i;
        Console.WriteLine($"{num} x {i,2} = {product.ToString().PadLeft(cellWidth)}");
    }
}

MultiTable(rows:10);