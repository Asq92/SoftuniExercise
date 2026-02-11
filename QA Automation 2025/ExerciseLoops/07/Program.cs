int stopNumber = int.Parse(Console.ReadLine());
int previousNumber = 0;
int enteredNumber = int.Parse(Console.ReadLine());

while (enteredNumber != stopNumber)
{
    previousNumber = enteredNumber;
    enteredNumber = int.Parse(Console.ReadLine());

}
Console.WriteLine(previousNumber * 1.20);

