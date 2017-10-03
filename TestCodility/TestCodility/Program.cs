using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCodility
{
    class Program
    {
        static void Main(string[] args)
        {

            int max = solution("PRPRRPP");
        }
        public static int solution(string G)
        {
            int RPoints = 0;
            int PPoints = 0;
            int SPoints = 0;
            int maxPoints = 0;

            int handPoints = 0;
            foreach (char c in G)
            {
               handPoints = CalculatePoints('R', c);
                RPoints = RPoints + handPoints;

                handPoints = CalculatePoints('S', c);
                SPoints = SPoints + handPoints;

                handPoints = CalculatePoints('P', c);
                PPoints = PPoints + handPoints;
            }

            if (RPoints >= SPoints && RPoints >= PPoints)
                maxPoints = RPoints;

            if (SPoints >= RPoints && SPoints >= PPoints)
                maxPoints = SPoints;

            if (PPoints >= RPoints && PPoints >= SPoints)
                maxPoints = PPoints;

            return maxPoints;

        }

        public static int CalculatePoints(char fhand, char ghand)
        {
            int points  =0;
            if (fhand == ghand)
            {
                points= 1;
                return points;
            }

            if (fhand == 'R')
            {
                if (ghand == 'S')
                {
                    points = 2;
                }
                else
                {
                    points = 0;
                }
            }
            if (fhand == 'P')
            {
                if (ghand == 'R')
                {
                    points = 2;
                }
                else
                {
                    points = 0;
                }
            }
            if (fhand == 'S')
            {
                if (ghand == 'R')
                {
                    points = 0;
                }
                else
                {
                    points = 2;
                }
            }
            return points;
        }
    }
}
