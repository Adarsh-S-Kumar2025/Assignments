using System;
using System.Collections.Generic;
using System.Linq;

public static class ListExtensions
{
    public static double AverageExceptZero(this List<int> numbers)
    {
        if (numbers == null || numbers.Count == 0)
            return 0;

        var nonZeroNumbers = numbers.Where(n => n != 0);

        if (!nonZeroNumbers.Any())
            return 0;

        return nonZeroNumbers.Average();
    }
}

