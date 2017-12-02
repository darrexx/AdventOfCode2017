using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeInputReader;
using Day02_2.Properties;

namespace Day02_2
{
    class Day02_2
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(2).Result;

            var checksum = 0;
            foreach (var line in lines)
            {
                var values = line.Split('\t').Where(x => x != String.Empty).Select(Int32.Parse).ToArray();
                for (var i = 0; i < values.Length; i++)
                {
                    for (var j = i+1 ; j < values.Length; j++)
                    {
                        if (values[i] % values[j] == 0)
                        {
                            checksum += values[i] / values[j];
                        }
                        if (values[j] % values[i] == 0)
                        {
                            checksum += values[j] / values[i];
                        }
                    }
                }
            }
            Console.WriteLine(checksum);
        }
    }
}
