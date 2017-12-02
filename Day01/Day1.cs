using System;
using System.Linq;
using AdventOfCodeInputReader;
using Day1.Properties;

namespace Day1
{
    class Day1
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(1).Result;

            var line = lines[0];
            var digits = line.Select(x => (int) Char.GetNumericValue(x)).ToArray();
            var sum = digits.Where((t, i) => t == digits[(i + 1) % digits.Length]).Sum();
            Console.WriteLine(sum);
        }
    }
}
