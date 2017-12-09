using System;
using System.Linq;
using AdventOfCodeInputReader;
using Day08.Properties;

namespace Day08
{
    class Day08
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(8).Result;

            var instructions = lines.Select(x => x.Split(' ')).Select(x => new Instruction
            {
                RegisterName = x[0],
                Increase = x[1] == "inc",
                Argument = Int32.Parse(x[2]),
                LeftSide = x[4],
                Operation = Instruction.GetOperationFromString(x[5]),
                RightSide = Int32.Parse(x[6])
            });
            var registers = instructions.Distinct().Select(x => new Register{Name = x.RegisterName, Value = 0}).ToArray();

            foreach (var instruction in instructions)
            {
                instruction.Perform(registers);
            }

            Console.WriteLine(registers.Select(x => x.Value).Max());
        }
    }
}
