int[] firstArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int[] secondArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
bool isIdentical = true;

for (int i = 0; i < firstArray.Length; i++)
{
    int currentElementFirstArray = firstArray[i];

    int currentElementSecondArray = secondArray[i];

    if (currentElementFirstArray != currentElementSecondArray)
    {
        isIdentical = false;
        break;
    }
}

if (isIdentical)
{
    Console.WriteLine("Arrays are identical.");
}
else
{
    Console.WriteLine("Arrays are not identical.");
}