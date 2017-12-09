using System;
using AdventOfCodeInputReader;
using Day09_2.Properties;

namespace Day09_2
{
    class Day09_2
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(9).Result;

            var result = 0;
            var isInGarbageBrackets = false;

            var line = lines[0];
            for (var i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case '<':
                        if (isInGarbageBrackets)
                        {
                            result++;
                        }
                        isInGarbageBrackets = true;
                        break;
                    case '>':
                        isInGarbageBrackets = false;
                        break;
                    case '!':
                        i++;
                        break;
                    default:
                        if (isInGarbageBrackets)
                        {
                            result++;
                        }
                        break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
