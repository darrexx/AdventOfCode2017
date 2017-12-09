using System;
using AdventOfCodeInputReader;
using Day09.Properties;

namespace Day09
{
    class Day09
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(9).Result;

            var level = 0;
            var result = 0;
            var isInGarbageBrackets = false;

            var line = lines[0];
            for (var i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {
                    case '<':
                        isInGarbageBrackets = true;
                        break;
                    case '>':
                        isInGarbageBrackets = false;
                        break;
                    case '{' when !isInGarbageBrackets:
                        level++;
                        break;
                    case '}' when !isInGarbageBrackets:
                        result += level;
                        level--;
                        break;
                    case '!':
                        i++;
                        break;
                }
            }
            Console.WriteLine(result);
        }
    }
}
