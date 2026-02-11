string text = Console.ReadLine();

Dictionary<char, int> symbolsCount = new();

foreach(char symbol in text)
{
    if(symbol == ' ')
    {
        continue;
    }
    if (!symbolsCount.ContainsKey(symbol))
    {
        symbolsCount.Add(symbol, 1);
    }
    else
    {
        symbolsCount[symbol]++;
    }
}

foreach (KeyValuePair<char, int> pair in symbolsCount)
{
    Console.WriteLine(pair.Key + " -> " + pair.Value);
}
