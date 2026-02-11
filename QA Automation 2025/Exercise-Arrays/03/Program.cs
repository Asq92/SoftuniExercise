int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

while(numbers.Length > 1)
{
    int[] condensedArray = new int[numbers.Length - 1];

    for(int i = 0; i < numbers.Length - 1; i++)
    {
        int sumElements = numbers[i] + numbers[i + 1];
        condensedArray[i] = sumElements;
    }

    numbers = condensedArray;
}
Console.WriteLine(numbers[0]);