using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 4, 3, 2, };
            Reverse(arr);
        }

        static int Reverse(int[] arr)
        {
            //int n = Convert.ToInt32(Console.ReadLine());
            //string[] arr_temp = Console.ReadLine().Split(' ');
            //int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

            for (int i = arr.Length; i > 0; i--)
            {
                Console.Write(arr[i-1] + " ");
            }
            Console.ReadKey();
            return 0;
        }
    }
}
