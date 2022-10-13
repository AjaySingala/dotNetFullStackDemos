namespace ContentDemos
{
public class Program
{
    static void Main()
    {
        List<string> elements = new List<string>();
        elements.Add("Ten");
        elements.Add("Eight");
        elements.Add("One");
        elements.Add("Five");
        elements.Add("Six");
        elements.Add("Three");
        elements.Add("Seven");
        elements.Add("Two");
        elements.Add("Nine");
        elements.Add("Four");

        var isEmpty = IsFirstElementNullOrEmpty(elements);
        Console.WriteLine($"Is the first element Null or Empty?: {isEmpty}");

        var hasValue = ContainsValue(elements, "Five");
        Console.WriteLine($"Does 'Five' exist?: {hasValue}");

        int[] numbers = new int[10] { 10, 8, 1, 5, 6, 3, 7, 2, 9, 4 };
        var sortedNumbers = BubbleSort(numbers);
        foreach (var number in sortedNumbers)
        {
            Console.WriteLine(number);
        }
    }

    static bool IsFirstElementNullOrEmpty(List<string> elements)
    {
        if (elements == null)
            throw new ArgumentNullException("elements");

        if (elements.Count > 0)
        {
            if (string.IsNullOrEmpty(elements[0]))
            {
                return true;
            }
        }
        return false;
    }

    private static bool ContainsValue(List<string> elements, string elementToBeFound)
    {
        if (elements == null)
            throw new ArgumentNullException("elements");

        if (elements.Count > 0)
        {
            for (int count = 0; count < elements.Count; count++)
            {
                if (elements[count].Equals(elementToBeFound))
                {
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Bubble Sorting
    /// </summary>
    /// <param name="scrambledArray">This Parameter Could be array as well, 
    /// but for simplicity I have just taken list, I am aware that u can peform binary search on list e.g. numberElements.BinarySearch(55);</param>
    /// <returns>Sorted Array of integers</returns>
    private static int[] BubbleSort(int[] scrambledArray)
    {
        for (int count = scrambledArray.Length - 1; count >= 0; count--)
        {
            for (int innercount = 1; innercount <= count; innercount++)
            {
                if (scrambledArray[innercount - 1] > scrambledArray[innercount])
                {
                    int temp = scrambledArray[innercount - 1];
                    scrambledArray[innercount - 1] = scrambledArray[innercount];
                    scrambledArray[innercount] = temp;
                }
            }
        }
        return scrambledArray;
    }
}
}