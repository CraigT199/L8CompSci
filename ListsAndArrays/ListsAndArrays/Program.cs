using System.Diagnostics;
using System.Globalization;
using System.Net;
using System.Numerics;

List<int> listOfIntegers = new List<int> { 1, 5, -2, -4, 3, 2 };

int SumList(List<int> listOfIntegers)
{
    int total = 0;
    foreach (int i in listOfIntegers)
    {
        total += i;
    }
    return total;
}

int MaxValList(List<int> listOfIntegers)
{
    int max = 0;
    foreach (int i in listOfIntegers)
    {
        if (i > max)
            max = i;
    }
    return max;
}

int MinValList(List<int> listOfIntegers)
{
    int min = listOfIntegers[0];
    foreach (int i in listOfIntegers)
    {
        if (i < min)
            min = i;
    }
    return min;
}

List<int> NegativeValList(List<int> listOfIntegers)
{
    return listOfIntegers.Where(i => i < 0).ToList();
}

void PrintList(List<int> list)
{
    String str = "{";
    foreach (var item in list)
    {
        str += " ${item},";
    }
    str += "}";
    Console.WriteLine(str);
}

bool SameItems(List<int> list1, List<int> list2)
{
    bool same = true;
    foreach (int i in list1)
    {
        if (!list2.Contains(i))
            same = false;
    }
    foreach (int i in list2)
    {
        if (!list1.Contains(i))
            same = false;
    }
    return same;
}

bool NaiveSearch(List<int> list, int target)
{
    foreach (int i in list)
    {
        if (i == target)
            return true;
    }
    return false;
}

bool BinarySearch(List<int> list, int target, int lbound, int ubound)
{
    if (lbound > ubound)
        return false;
    if (target < list[(ubound + lbound) / 2])
    {
        ubound = (ubound + lbound) / 2 - 1;
        return BinarySearch(list, target, lbound, ubound);
    }
    else if (target > list[(ubound + lbound) / 2])
    {
        lbound = (ubound + lbound) / 2 + 1;
        return BinarySearch(list, target, lbound, ubound);
    }
    else
        return true;
}

List<int> GetDuplicates(List<int> list)
{
    List<int> uniqueItems = new List<int> { };
    List<int> duplicates = new List<int> { };
    foreach (int item in list)
    {
        if (uniqueItems.Contains(item) && !duplicates.Contains(item))
            duplicates.Add(item);
        else
            uniqueItems.Add(item);
    }
    return duplicates;
}

bool IsSubset(List<int> a, List<int> b)
{
    foreach (int i in b)
    {
        bool found = false;
        foreach (int j in a)
        {
            if (i == j)
            {
                found = true;
                break;
            }
        }
        if (!found) return false;
    }
    return true;
}

void Reverse(List<int> list)
{
    int left = 0;
    int right = list.Count - 1;
    while (left < right)
    {
        int temp = list[left];
        list[left] = list[right];
        list[right] = temp;
        left++;
        right--;
    }
}

void BubbleSort(List<int> list)
{
    int length = list.Count;
    for (int i = 0; i < length - 1; i++)
    {
        for (int j = 0; j < length - i - 1; j++)
        {
            if (list[j] > list[i])
            {
                int temp = list[j];
                list[j] = list[j + 1];
                list[j + 1] = temp;
            }
        }
    }
}

// Debug.Assert(SumList(listOfIntegers)==listOfIntegers.Sum());
// Debug.Assert(MaxValList(listOfIntegers)==listOfIntegers.Max());
// Debug.Assert(MinValList(listOfIntegers)==listOfIntegers.Min());

// List<int> correctNegList = new List<int> { -2, -4 };
// Debug.Assert(NegativeValList(listOfIntegers).SequenceEqual(correctNegList));

// List<int> secondListOfIntegers = new List<int> { 1, 5, -2, -4, 3, 2, 2, 7 };
// List<int> correctSharedVals = new List<int> { 1, 5, -2, -4, 3, 2 };
// Debug.Assert(!SameItems(listOfIntegers, secondListOfIntegers));

// List<int> sortedList = new List<int> { 1, 2, 4, 6, 11, 20, 25 };
// int lbound = 0;
// int ubound = sortedList.Count()-1;
// int target = 6;
// Debug.Assert(BinarySearch(sortedList,target,lbound,ubound));

// List<int> listWithDuplicates = new List<int> { 1, 5, -2, -4, 3, 2, 1, -2, 7, 9, -2, -2 };
// List<int> correctDups = new List<int> { 1, -2 };
// Debug.Assert(GetDuplicates(listWithDuplicates).SequenceEqual(correctDups));

// List<int> subsetOfIntegers = new List<int> { 1, 5, -2 };
// Debug.Assert(IsSubset(listOfIntegers,subsetOfIntegers));