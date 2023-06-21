using System;
using System.Linq;

namespace _01._Trains
{
    public class Program
    {
        static void Main(string[] args)
        {
           var arrivals = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .OrderBy(n => n)
                .ToArray();

            var departures = Console.ReadLine()
               .Split()
               .Select(double.Parse)
               .OrderBy(n => n)
               .ToArray();

            Console.WriteLine(CountOfPlatforms(arrivals, departures));
        }

        private static int CountOfPlatforms(double[] arrivals, double[] departures)
        {
            var totalPlatforms = 0;
            var takenPlatforms = 0;

            var arrIndex = 0;
            var depIndex = 0;

            while (arrIndex < arrivals.Length)
            {
                var arrTime = arrivals[arrIndex];
                var depTime = departures[depIndex];

                if (arrTime < depTime)
                {
                    takenPlatforms += 1;
                    arrIndex += 1;
                    totalPlatforms = Math.Max(totalPlatforms, takenPlatforms);
                }
                else
                {
                    depIndex += 1;
                    takenPlatforms -= 1;
                }
            }

            return totalPlatforms;
        }
    }
}
