string[] forbiddenWords = Console.ReadLine().Split(", ");
string text = Console.ReadLine();

foreach (string word in forbiddenWords)
{
    string replacement = new string('*', word.Length);

    text = text.Replace(word, replacement);
}

Console.WriteLine(text);