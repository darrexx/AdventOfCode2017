using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeInputReader;
using Day11.Properties;

namespace Day11
{
    class Day11
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(11).Result;

            var path = lines[0].Split(',').Select(GetDirectionFromString);
            var stepsNorth = 0;
            var stepsSouthEast = 0;

            foreach (var step in path)
            {
                switch (step)
                {
                    case Direction.North:
                        stepsNorth++;
                        break;
                    case Direction.NortEast:
                        stepsNorth++;
                        stepsSouthEast++;
                        break;
                    case Direction.NorthWest:
                        stepsSouthEast--;
                        break;
                    case Direction.South:
                        stepsNorth--;
                        break;
                    case Direction.SouthWest:
                        stepsNorth--;
                        stepsSouthEast--;
                        break;
                    case Direction.SouthEast:
                        stepsSouthEast++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            Console.WriteLine(Math.Max(Math.Abs(stepsSouthEast), Math.Abs(stepsNorth)));
        }

        static Direction GetDirectionFromString(string s)
        {
            switch (s)
            {
                case "n":
                    return Direction.North;
                case "ne":
                    return Direction.NortEast;
                case "nw":
                    return Direction.NorthWest;
                case "s":
                    return Direction.South;
                case "sw":
                    return Direction.SouthWest;
                case "se":
                    return Direction.SouthEast;
                default:
                    throw new ArgumentException();
            }
        }
    }

    public enum Direction
    {
        North,
        NortEast,
        NorthWest,
        South,
        SouthWest,
        SouthEast,
    }
}
