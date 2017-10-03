using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPoints = 0;
            int[] A = new int[] {1, -2, 0, 9, -1, -2};
            bool[] M = new bool[] { false, false, false, false, false, false };
            int squares = A.Length - 1;
            

            //for (int i = 0; i < squares; i++)
            //{
            //    A[i] = GetRandomNumber(-10000, 10000);
            //}

     
            int currentPosition = 0;
            totalPoints = totalPoints + A[currentPosition];

            do
            {
                currentPosition = GetNextSquare(squares, currentPosition);
                if (M[currentPosition] == false)
                {
                    totalPoints = totalPoints + A[currentPosition];
                    M[currentPosition] = true;
                }

            } while (currentPosition != squares);


            Console.WriteLine(totalPoints);

            Console.ReadKey();
        }

        static int solution(int[] A)
        {
            GetRandomNumber(1, 6);
            return 1;
        }

        static int GetNextSquare(int totalSquares, int currentPostion)
        {
            int diceValue = GetRandomNumber(1, 6);

            if ((currentPostion + diceValue) > totalSquares)
            {
                return GetNextSquare(totalSquares, currentPostion);
            }
            return currentPostion + diceValue;
        }

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return getrandom.Next(min, max);
            }
        }
    }
    
}
