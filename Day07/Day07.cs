using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeInputReader;
using Day07.Properties;

namespace Day07
{
    class Day07
    {   
        static void Main(string[] args)
        {
            var aoc = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aoc.GetInputForDay(7).Result;

            var programs = lines
                .Select(x => x.Split(' ', ',', '(', ')').Where(y => y != String.Empty && y != "->").ToArray()).Select(
                    x => new Program {Name = x[0], Weight = Int32.Parse(x[1]), ProgramsAbove = x.Skip(2).ToArray()}).ToArray();
            var root = programs.FirstOrDefault(x => !programs.SelectMany(y => y.ProgramsAbove).Contains(x.Name));
            Console.WriteLine(root?.Name ?? "NoRootFound");
        }
    }
}
