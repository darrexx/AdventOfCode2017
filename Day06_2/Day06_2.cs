using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCodeInputReader;
using Day06_2.Properties;

namespace Day06_2
{
    class Day06_2
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(6).Result;

            var memorybanks = lines.SelectMany(x => x.Split('\t')).Where(x => x != String.Empty).Select(Int32.Parse).ToArray();
            var rememberedStates = new List<int[]>();
            var steps = 0;
            var hasFoundDuplicateState = false;

            do
            {
                rememberedStates.Add((int[])memorybanks.Clone());
                var toDistribute = memorybanks.Max();
                var currentIndex = Array.IndexOf(memorybanks, toDistribute);
                memorybanks[currentIndex] = 0;

                for (var i = 0; i < toDistribute; i++)
                {
                    currentIndex++;
                    if (currentIndex >= memorybanks.Length)
                    {
                        currentIndex = 0;
                    }

                    memorybanks[currentIndex] += 1;
                }
                steps++;

                if (rememberedStates.Any(x => x.SequenceEqual(memorybanks)) && !hasFoundDuplicateState)
                {
                    rememberedStates.Clear();
                    hasFoundDuplicateState = true;
                    steps = 0;
                }

            } while (rememberedStates.All(x => !x.SequenceEqual(memorybanks)));

            Console.WriteLine(steps);
        }
    }
}
