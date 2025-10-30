using System;
using System.Collections.Generic;

namespace TestApp;

public class EvenNumbers
{
    public static string GetEvenNumbersInRange(int start, int end)
    {
        if (start > end)
        {
            return "Start number should be smaller than end number.";
        }

        if (start < 0)
        {
            return "Start number should be positive number.";
        }

        List<int> evens = new List<int>();

        for (int i = start; i <= end; i++)
        {
            if (i % 2 == 0)
            {
                evens.Add(i);
            }
        }

        if (evens.Count == 0)
        {
            return "Empty result";
        }

        return string.Join(", ", evens);
    }
}
