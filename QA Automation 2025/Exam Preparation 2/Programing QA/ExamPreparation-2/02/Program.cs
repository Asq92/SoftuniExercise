int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int n = int.Parse(Console.ReadLine());

int maxNumber = int.MinValue;
int minNumber = int.MaxValue;

for (int i = 0; i < n; i++)
{
    int currentNumber = numbers[i];

    if(currentNumber > maxNumber)
    {
        maxNumber = currentNumber;
    }

    if(currentNumber < minNumber)
    {
        minNumber = currentNumber;
    }
}

Console.WriteLine(maxNumber);
Console.WriteLine(minNumber);