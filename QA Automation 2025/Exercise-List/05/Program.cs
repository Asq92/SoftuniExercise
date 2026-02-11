List<int> filed = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
int[] bombInfo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

int bombNumber = bombInfo[0];
int power = bombInfo[1];

while (filed.Contains(bombNumber))
{
    int bombIndex = filed.IndexOf(bombNumber);

    int startIndex = bombIndex - power;
    int endIndex = bombIndex + power;

    if(startIndex < 0)
    {
        startIndex = 0;
    }

    if(endIndex >= filed.Count)
    {
        endIndex = filed.Count - 1;
    }

    for (int i = startIndex; i <= endIndex; i++)
    {
        filed[i] = 0;
    }
}
int sum = 0;

foreach (var item in filed)
{
    sum += item;
}

Console.WriteLine(sum);


    