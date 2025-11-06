string[] words = Console.ReadLine().Split(" ");

foreach (string word in words)
{
    int Length = word.Length;
    for (int count = 0; count < Length; count++)
    {
        Console.Write(word);
    }
}


