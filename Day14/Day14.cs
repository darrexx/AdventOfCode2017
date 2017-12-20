using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeInputReader;
using Day14.Properties;

namespace Day14
{
    class Day14
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(14).Result;
            var used = 0;

            for (var row = 0; row < 128; row++)
            {
                var bitArray = KnotHash(lines[0] + "-" + row);
                used += bitArray.OfType<bool>().Count(x => x);
            }
            Console.WriteLine(used);
        }

        public static BitArray KnotHash(string input)
        {
            var skip = 0;
            var numbersList = Enumerable.Range(0, 256).ToList();
            var lengths = input.ToCharArray().Select(x => (int)x).Concat(new[] { 17, 31, 73, 47, 23 }).ToArray();
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
            var denseHashes = numbersList.Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / 16)
                .Select(x => x.Select(y => y.Value).ToList())
                .Select(x => x.Aggregate((y, next) => y ^ next))
                .ToArray();

            return new BitArray(denseHashes);//denseHashes.Select(x => Convert.ToString(x,2)).ToArray();
            //var test = new BitArray(new[]{8});
            //Console.WriteLine(test[0] + " " + test[1] + " " + test[2] + " " + test[3]);
        }
    }
}
