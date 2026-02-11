int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();


int n = int.Parse(Console.ReadLine());
foreach (int i in numbers)
{
    if (i < n)
    {
        Console.Write(i + " ");
    }
}