using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeInputReader;
using Day07_2.Properties;

namespace Day07_2
{
    class Day07_2
    {
        static void Main(string[] args)
        {
            var aoc = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aoc.GetInputForDay(7).Result;

            var programs = lines
                .Select(x => x.Split(' ', ',', '(', ')').Where(y => y != String.Empty && y != "->").ToArray()).Select(
                    x => new Program { Name = x[0], Weight = Int32.Parse(x[1]), ProgramsAbove = x.Skip(2).ToArray() }).ToArray();
            var root = programs.FirstOrDefault(x => !programs.SelectMany(y => y.ProgramsAbove).Contains(x.Name));
            var test = GetWeightOfProgram(root, programs);
            Console.WriteLine(root?.Name ?? "NoRootFound");
        }

        private static int GetWeightOfProgram(Program program, Program[] allPrograms)
        {
            if (program.ProgramsAbove.Length == 0)
            {
                return program.Weight;
            }
            var programs = allPrograms.Where(x => program.ProgramsAbove.Contains(x.Name));
            var weight = 0;
            var programWeight = new List<int>();
            foreach (var program1 in programs)
            {
                var tempWeight = GetWeightOfProgram(program1, allPrograms);
                programWeight.Add(tempWeight);
                weight += tempWeight;
            }
            if (programWeight.Max() != programWeight.Min())
            {
                Console.WriteLine(programWeight.Max() - programWeight.Min());
                return 0;
            }
            return program.Weight + weight;
        }
    }
}
