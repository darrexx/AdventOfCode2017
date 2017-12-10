using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeInputReader;
using Day10.Properties;

namespace Day10
{
    class Day10
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(10).Result;

            var skip = 0;
            var numbersList = Enumerable.Range(0, 256).ToList();
            var lengths = lines[0].Split(',').Select(Int32.Parse).ToArray();
            var currentPos = 0;

            foreach (var length in lengths)
            {
                var tempList = new List<int>();
                for (var i = 0; i < length; i++)
                {
                    tempList.Add(numbersList[(i+ currentPos) % numbersList.Count]);
                }
                tempList.Reverse();
                for (var i = 0; i < tempList.Count; i++)
                {
                    numbersList[(i + currentPos) % numbersList.Count] = tempList[i];
                }
                currentPos += length + skip;
                skip++;
            }
            Console.WriteLine(numbersList[0] * numbersList[1]);
        }
    }
}
