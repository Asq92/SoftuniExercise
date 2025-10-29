int number = int.Parse(Console.ReadLine());

int sum = 0;

while (number > 0)
{
    int lastDigit = number % 10;
    if (lastDigit % 2 == 0)
    {
        int fact = 1;
        for (int i = 1; i<= lastDigit; i++)
        {
            fact *= i;
        }
        sum += fact;
    }
    number /= 10;
}

Console.WriteLine(sum);