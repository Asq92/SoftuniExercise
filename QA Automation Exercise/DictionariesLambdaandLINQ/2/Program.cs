string[] words = Console.ReadLine().Split();

Dictionary<string, int> wordsCount = new();

foreach (string word in words)
{
    string wordWithLowerLetters = word.ToLower();

    if (!wordsCount.ContainsKey(wordWithLowerLetters))
    {
        wordsCount.Add(wordWithLowerLetters, 1);
    }
    else
    {
        wordsCount[wordWithLowerLetters]++;
    }
}

foreach (KeyValuePair<string, int> pair in wordsCount)
{
    string word = pair.Key;
    int count = pair.Value;

   if (pair.Value % 2 != 0)
    {
        Console.Write(pair.Key + " ");
    }
}

