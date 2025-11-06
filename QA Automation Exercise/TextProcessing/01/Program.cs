string input = Console.ReadLine();

while (input != "end")
{
    string reversedText = "";
    for (int posittion = input.Length-1; posittion >= 0; posittion--)
    {
        char currentSymbol = input[posittion];
        reversedText += currentSymbol;
    }

    Console.WriteLine(input + " = " + reversedText); ;


    input = Console.ReadLine();
}