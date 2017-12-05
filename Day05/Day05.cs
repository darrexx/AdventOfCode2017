using System;
using System.Linq;
using AdventOfCodeInputReader;
using Day05.Properties;

namespace Day05
{
    class Day05
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(5).Result;

            var digits = lines.Select(Int32.Parse).ToArray();
            var position = 0;
            var isEnded = false;
            var steps = 0;
            while (!isEnded)
            {
                digits[position] = digits[position] + 1;
                position = position + digits[position] - 1;
                steps++;
                if (position >= digits.Length || position < 0)
                {
                    isEnded = true;
                }
            }
            Console.WriteLine(steps);
        }
    }
}
