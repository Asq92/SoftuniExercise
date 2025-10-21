
int[] numbers = Console.ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();


for (int i = 0; i < numbers.Length; i++)
{
    
    int currentElement = numbers[i];

    
    bool isBigger = true;

    
    for (int j = i + 1; j < numbers.Length; j++)
    {
        int nextRigthElement = numbers[j];

        if (currentElement <= nextRigthElement) 
        {
            isBigger = false; 
            break;
        }
    }

   
    if (isBigger)
    {
        Console.Write(currentElement + " ");
    }
}
