
void PrintVowelsCount(string text)
{
    int counter = 0;
    for ( int i = 0; i < text.Length; i++)
    {
        char letter = text[i];
        switch(letter)
        {
            case 'a' or 'o' or 'i' or 'u' or 'e':
                    counter++;
                break;
            case 'A' or 'O' or 'I' or 'U' or 'E':
                counter++;
                break;
        }
    }
    Console.WriteLine(counter);
}
string input = Console.ReadLine();
PrintVowelsCount(input);