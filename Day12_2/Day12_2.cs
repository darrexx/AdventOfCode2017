using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeInputReader;
using Day12_2.Properties;

namespace Day12_2
{
    class Day12_2
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(12).Result;

            var group = new HashSet<int>() { 0 };
            var groups = 0;

            var programs = lines.Select(x =>
                x.Split(new[] { "<->", "," }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray()).Select(x => new Program { Id = x[0], Neighbours = x.Skip(1).ToArray(), Visited = false }).ToList();

            TrackPipes(group, programs.FirstOrDefault(x => x.Id == 0), programs);
            groups++;
            programs.RemoveAll(x => x.Visited);
            while (programs.Count != 0)
            {
                group.Clear();
                TrackPipes(group, programs[0], programs);
                groups++;
                programs.RemoveAll(x => x.Visited);
            }
            Console.WriteLine(groups);
        }

        static void TrackPipes(HashSet<int> inGroup, Program program, List<Program> programs)
        {
            if (program.Visited)
            {
                return;
            }

            program.Visited = true;
            inGroup.Add(program.Id);

            foreach (var programNeighbour in program.Neighbours)
            {
                TrackPipes(inGroup, programs.FirstOrDefault(x => x.Id == programNeighbour), programs);
            }
        }
    }
}
