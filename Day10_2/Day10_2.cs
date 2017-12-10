using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCodeInputReader;
using Day10_2.Properties;

namespace Day10_2
{
    class Day10_2
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(10).Result;

            var skip = 0;
            var numbersList = Enumerable.Range(0, 256).ToList();
            var lengths = lines[0].ToCharArray().Select(x => (int) x).Concat(new []{17, 31, 73, 47, 23 }).ToArray();
            var currentPos = 0;

            for (var k = 0; k < 64; k++)
            {
                foreach (var length in lengths)
                {
                    var tempList = new List<int>();
                    for (var i = 0; i < length; i++)
                    {
                        tempList.Add(numbersList[(i + currentPos) % numbersList.Count]);
                    }
                    tempList.Reverse();
                    for (var i = 0; i < tempList.Count; i++)
                    {
                        numbersList[(i + currentPos) % numbersList.Count] = tempList[i];
                    }
                    currentPos += length + skip;
                    skip++;
                }
            }
            var denseHashes = numbersList.Select((x, i) => new {Index = i, Value = x})
                .GroupBy(x => x.Index % 16)
                .Select(x => x.Select(y => y.Value).ToList())
                .Select(x => x.Aggregate((y, next) => y ^ next))
                .ToArray();

            var hexString = denseHashes.Select(x => x.ToString("X2")).ToArray();

            var builder = new StringBuilder();
            foreach (var s in hexString)
            {
                builder.Append(s);
            }
            Console.WriteLine(builder.ToString());
        }
    }
}
