int n = int.Parse(Console.ReadLine());
List<string> housePartyList = new List<string>();


for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split(' ');
    string name = input[0];
    string goingOrNot = input[2];

    if (goingOrNot == "going!")
    {
        if (housePartyList.Contains(name))
        {
            Console.WriteLine($"{name} is already in the list!");
        }
        else
        {
            housePartyList.Add(name);
        }
    }
    else if (goingOrNot == "not")
    {
        if (housePartyList.Contains(name))
        {
            housePartyList.Remove(name);
        }
        else
        {
            Console.WriteLine($"{name} is not in the list!");
        }
    }
}

Console.WriteLine(string.Join(Environment.NewLine, housePartyList));