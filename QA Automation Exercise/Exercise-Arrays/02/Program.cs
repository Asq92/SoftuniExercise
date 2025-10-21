int[] firstArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int[] secondArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();


for (int i = 0; i < firstArray.Length; i++)
{
    int currentElement = firstArray[i];
    for (int j= 0; j < secondArray.Length; j++)
    {
        int currentElementSecondArray = secondArray[j];

        if (currentElement == currentElementSecondArray)
        {
            Console.Write(currentElement + " ");
        }
    }
}

// Втори вариант

foreach (int element in secondArray)
{
    if (secondArray.Contains(element))
    {
        Console.WriteLine(element + " ");
    }
}