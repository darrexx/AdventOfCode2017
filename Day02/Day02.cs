using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeInputReader;
using Day02.Properties;

namespace Day02
{
    class Day02
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(2).Result;

            var checksum = 0;
            foreach (var line in lines)
            {
                var values = line.Split('\t').Where(x => x != String.Empty).Select(Int32.Parse).ToArray();
                checksum += values.Max() - values.Min();
            }
            Console.WriteLine(checksum);
        }
    }
}
