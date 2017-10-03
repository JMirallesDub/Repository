using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepested_pit
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 0, 1, 3, -2, 0, 1, 0, -3, 2, 3 };

            Console.WriteLine(solution(A));
            Console.ReadKey();
        }

        static int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)    
            int P = -1, R = -1, Q = -1, depth = -1;

            for (int i = 0; i < A.Length - 1; i++)
            {
                if (Q < 0)
                {
                    if (A[i] > A[i + 1])
                    {
                        Q = i + 1;
                        P = i;
                    }
                }
                else
                {
                    if (R < 0)
                    {
                        if (A[i] > A[i + 1])
                            Q++;

                        if (A[i] < A[i + 1])
                            R = i + 1;

                        if (A[i] == A[i + 1])
                        {
                            P = Q = R = -1;
                        }
                    }
                    else
                    {
                        if (A[i] < A[i + 1])
                            R++;
                        else
                        {
                            depth = Math.Max(depth, Math.Min(A[P] - A[Q], A[R] - A[Q]));

                            if (A[i] > A[i + 1])
                            {
                                P = i;
                                Q = i + 1;
                                R = -1;
                            }
                            else
                            {
                                P = Q = R = -1;
                            }
                        }
                    }
                }
            }

            if (R > 0)
            {
                depth = Math.Max(depth, Math.Min(A[P] - A[Q], A[R] - A[Q]));
            }

            return depth;
        }
    }
}
