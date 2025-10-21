int FindFactorial(int x)
{
    int factorial = 1;
    for (int i = 1; i <= x; i++)
    {
        factorial *= i;
    }
    return factorial;
}

int firstNumber = int.Parse(Console.ReadLine());
int secondNumber = int.Parse(Console.ReadLine());

int firstFactorial = FindFactorial(firstNumber);
int secondFactorial = FindFactorial(secondNumber);

int result = firstFactorial / secondFactorial;


Console.WriteLine(result);