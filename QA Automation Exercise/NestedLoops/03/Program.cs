﻿int size = int.Parse(Console.ReadLine());

for (int row = 0; row <= size; row++)
{
    for ( int count = 1; count <= row; count++)
    {
        Console.Write("*");
    }
    Console.WriteLine();
}