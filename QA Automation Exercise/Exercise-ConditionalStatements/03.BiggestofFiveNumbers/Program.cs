// Input //
int firstNumber = int.Parse(Console.ReadLine());
int secondNumber = int.Parse(Console.ReadLine());
int thirdNumber = int.Parse(Console.ReadLine());
int fourNumber = int.Parse(Console.ReadLine());
int fiveNumber = int.Parse(Console.ReadLine());

// Output //

if (firstNumber > secondNumber && firstNumber > thirdNumber && firstNumber > fourNumber && firstNumber > fiveNumber)
{
    Console.WriteLine(firstNumber);
}
else if (secondNumber > firstNumber && secondNumber > thirdNumber && secondNumber > fourNumber && secondNumber > fiveNumber)
{
    Console.WriteLine( secondNumber);
}
else if (thirdNumber > firstNumber && thirdNumber > secondNumber && thirdNumber > fourNumber && thirdNumber > fiveNumber)
{
    Console.WriteLine( thirdNumber);
}
else if (fourNumber > firstNumber && fourNumber > secondNumber && fourNumber > thirdNumber && fourNumber > fiveNumber)
{
    Console.WriteLine( fourNumber);

}
else
{
    Console.WriteLine( fiveNumber);
}

