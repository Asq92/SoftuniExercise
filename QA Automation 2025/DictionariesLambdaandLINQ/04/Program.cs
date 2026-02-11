string[] words = Console.ReadLine().Split(" ").Where(word => word.Length % 2 == 0).ToArray();

foreach(string word in words)
{
    Console.WriteLine(word);
}