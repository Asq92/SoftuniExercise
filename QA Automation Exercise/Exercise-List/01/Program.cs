List<int> train = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
int maxCapacity = int.Parse(Console.ReadLine());

string[] input = Console.ReadLine().Split(' ');

while (input[0] != "end")
{
    if( input[0] == "Add")
    {
        int newWagon = int.Parse(input[1]);
        train.Add(newWagon);
    }
    else
    {
        int passengersToAdd = int.Parse(input[0]);

        for(int i = 0; i < train.Count; i++)
        {
            if (train[i] +passengersToAdd <= maxCapacity)
            {
                train[i] += passengersToAdd;
                break;
            }
        }
    }




        input = Console.ReadLine().Split(' ');
}

Console.WriteLine(string.Join(' ', train));