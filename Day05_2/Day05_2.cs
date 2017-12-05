using System;
using System.Linq;
using AdventOfCodeInputReader;
using Day05_2.Properties;

namespace Day05_2
{
    class Day05_2
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(5).Result;

            var digits = lines.Select(Int32.Parse).ToArray();
            var position = 0;
            var steps = 0;
            while (position < digits.Length || position >= 0)
            {
                if (digits[position] >= 3)
                {
                    digits[position] = digits[position] - 1;
                    position = position + digits[position] + 1;
                }
                else
                {
                    digits[position] = digits[position] + 1;
                    position = position + digits[position] - 1;
                }
                
                steps++;
            }
            Console.WriteLine(steps);
        }
    }
}
