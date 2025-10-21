int count = int.Parse(Console.ReadLine());

int sum = 0;
for (int number = 1; number <= count; number++)
{
    char symbol = char.Parse(Console.ReadLine());
    if (symbol == 'a')
    {
        sum += 1; //sum++;
    }
    else if (symbol == 'e')
    {
        sum += 2;
    }
    else if (symbol == 'i')
    {
        sum += 3;
    }
    else if (symbol == 'o')
    {
        sum += 4;
    }
    else if (symbol == 'u')
    {
        sum += 5;
    }
}
Console.WriteLine(sum);
