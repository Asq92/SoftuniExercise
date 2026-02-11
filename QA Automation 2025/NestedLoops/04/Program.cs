int floorsCount = int.Parse(Console.ReadLine());
int estatesCount = int.Parse(Console.ReadLine());

for (int floor = floorsCount; floor >= 1; floor--)
{
    for (int estate = 0; estate < estatesCount; estate++)
    {
        if ( floor == floorsCount)
        {
            Console.Write($"L{floor}{estate} ");
        }
        else if ( floor % 2 == 0)
        {
            Console.Write($"O{floor}{estate} ");
        }
        else
        {
            Console.Write($"A{floor}{estate} ");
        }
    }
    Console.WriteLine();
}
