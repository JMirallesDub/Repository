using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
static class Solution
{

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] a = new int[n][];
        for (int a_i = 0; a_i < n; a_i++)
        {
            string[] a_temp = Console.ReadLine().Split(' ');
            a[a_i] = Array.ConvertAll(a_temp, Int32.Parse);
        }

        var primarySum = PrimaryDiagonal(a).Sum();
        var secondarySum = SecondaryDiagonal(a).Sum();

        Console.WriteLine (Math.Abs((primarySum - secondarySum)));
    }


    public static IEnumerable<T> PrimaryDiagonal<T>(this IEnumerable<T[]> values)
    {
        return values.Select((x, i) => x[i]);
    }

    public static IEnumerable<T> SecondaryDiagonal<T>(this IEnumerable<T[]> values)
    {
        return values.Reverse().Select((x, i) => x[i]);
    }

}
