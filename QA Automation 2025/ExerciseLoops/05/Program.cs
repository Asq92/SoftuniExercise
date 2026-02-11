int countNumber = int.Parse(Console.ReadLine());
int countDivisible2 = 0;
int countDivisible3 = 0;
int countDivisible4 = 0;

for (int number = 1; number <= countNumber; number++)
{
    int count = int.Parse(Console.ReadLine());
    if (count % 2 == 0)
    {
        countDivisible2++;
    }
    if ( count % 3 == 0)
    {
        countDivisible3++;
    }
    if ( count % 4 == 0)
    {
        countDivisible4++; 
    }
}
double percentDivisible2 = countDivisible2 * 1.0 / countNumber * 100;
double percentDivisible3 = countDivisible3 * 1.0 / countNumber * 100;
double percentDivisible4 = countDivisible4 * 1.0 / countNumber * 100;

Console.WriteLine($"{percentDivisible2:F2}%");
Console.WriteLine($"{percentDivisible3:F2}%");
Console.WriteLine($"{percentDivisible4:F2}%");