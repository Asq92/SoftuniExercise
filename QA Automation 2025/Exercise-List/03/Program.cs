List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

string[] input = Console.ReadLine().Split(' ');

while (input[0] != "End")
{
    string command = input[0];
    if(command == "Add")
    {
        int numberToAdd = int.Parse(input[1]);
        numbers.Add(numberToAdd);
    }
    else if (command == "Insert")
    {
        int numberToInsert = int.Parse(input[1]);
        int index = int.Parse(input[2]);
        if(index < 0 || index >= numbers.Count)
        {
            Console.WriteLine("Invalid index");
        }
        else
        {
            numbers.Insert(index, numberToInsert);
        }
    }
    else if (command == "Remove")
    {
        int index = int.Parse(input[1]);
        if (index < 0 || index >= numbers.Count)
        {
            Console.WriteLine("Invalid index");
        }
        else
        {
            numbers.RemoveAt(index);
        }

    }
    else if (command == "Shift")
    {
        string direction = input[1];
        int count = int.Parse(input[2]);

        if(direction == "left")
        {
            for (int i = 0; i < count; i++)
            {
            int firstElement = numbers[0];
            numbers.RemoveAt(0);
            numbers.Add(firstElement);
            }
           
        }
        else if (direction == "right")
        {
            for (int i = 0; i < count; i++)
            {
                int lastElement = numbers[numbers.Count -1];
                numbers.RemoveAt(numbers.Count - 1);
                numbers.Insert(0, lastElement);
            }
        }
    }




        input = Console.ReadLine().Split(' ');

}

Console.WriteLine(string.Join(' ', numbers));
