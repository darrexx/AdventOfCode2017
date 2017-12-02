using System;
using System.Linq;
using AdventOfCodeInputReader;
using Day1_2.Properties;

namespace Day1_2
{
    class Day1_2
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(1).Result;

            var line = lines[0];
            var digits = line.Select(x => (int)Char.GetNumericValue(x)).ToArray();
            var sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] == digits[(i + (digits.Length / 2)) % digits.Length])
                {
                    sum += digits[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
