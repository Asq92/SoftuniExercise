List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
SortedDictionary<int, int> countOccurrences = new SortedDictionary<int, int>();

foreach(int number in numbers)
{
    if (countOccurrences.ContainsKey(number))
    {
        countOccurrences[number]++;
    }
    else
    {
        countOccurrences.Add(number, 1);
    }
}

foreach(KeyValuePair<int, int> pair in countOccurrences)
{
    Console.WriteLine(pair.Key + " -> " + pair.Value);
}
