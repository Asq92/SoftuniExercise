using System.Text;

string text = Console.ReadLine();

StringBuilder sbDigits = new StringBuilder();
StringBuilder sbLetters = new StringBuilder();
StringBuilder sbOthersSymbols = new StringBuilder();

foreach (char symbol in text)
{
    if (char.IsDigit(symbol))
    {
        sbDigits.Append(symbol);
    }
    else if (char.IsLetter(symbol))
    {
        sbLetters.Append(symbol);
    }
    else
    {
        sbOthersSymbols.Append(symbol);
    }
    
        
    
}
Console.WriteLine(sbDigits.ToString());
Console.WriteLine(sbLetters.ToString());
Console.WriteLine(sbOthersSymbols.ToString());
