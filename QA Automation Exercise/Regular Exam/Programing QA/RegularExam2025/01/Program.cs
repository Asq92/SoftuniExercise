int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    
    int number = int.Parse(Console.ReadLine());

    
    long factorial = 1;
    for (int j = 1; j <= number; j++)
    {
        factorial *= j;
    }

    
    Console.WriteLine(factorial);
}