



//прости числа -> се делят на 1 и на себе си => 2 делителя
//съставни числа -> имат повече от 2 делителя
int startNumber = int.Parse(Console.ReadLine());
int endNumber = int.Parse(Console.ReadLine());

//числата в диапазона [startNumber; endNumber]

for (int number = startNumber; number <= endNumber; number++)
{
    //проверка дали е просто число -> отпечатвам

    int countDivisors = 0; //броя на делителите на числото
    for (int i = 1; i <= number; i++)
    {
        //за всяко едно число от 1 до моето
        if (number % i == 0)
        {
            //i е число, което е делител на моето
            countDivisors++;
        }
    }

    //знаем колко е броя на делителите -> проверка дали числото е просто
    if (countDivisors == 2)
    {
        //просто число
        Console.Write(number + " ");
    }
}