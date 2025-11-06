int countWords = int.Parse(Console.ReadLine());

Dictionary<string, List<string>> wordSynonyms = new();

for (int count = 1; count <= countWords; count++)
{
    string word = Console.ReadLine();
    string synonym = Console.ReadLine();

    if (!wordSynonyms.ContainsKey(word))
    {
        wordSynonyms.Add(word, new List<string>() { synonym });
    }
    else
    {
        wordSynonyms[word].Add(synonym);
    }
}

foreach(KeyValuePair<string, List<string>> pair in wordSynonyms)
{
    string word = pair.Key;
    List<string> synonyms = pair.Value;

    Console.WriteLine(word + " - " + string.Join(", ", synonyms));
}