﻿using System.Net.WebSockets;

int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

int controlNumber = int.Parse(Console.ReadLine());

for (int i = 0; i < numbers.Length - 1; i++)
{
    int currentNumber = numbers[i];

    for (int j = i +1; j < numbers.Length; j++)
    {
        int nextRightElement = numbers[j];

        if(currentNumber + nextRightElement == controlNumber)
        {
            Console.WriteLine($"{currentNumber} {nextRightElement}");
            break;
        }
    }
}