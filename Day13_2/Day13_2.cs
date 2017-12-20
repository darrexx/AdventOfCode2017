using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeInputReader;
using Day13_2.Properties;

namespace Day13_2
{
    class Day13_2
    {
        static void Main(string[] args)
        {
            var aocInputReader = new AoCInputReader(Settings.Default.SessionCookie);
            var lines = aocInputReader.GetInputForDay(13).Result;

            var depthOfPacket = 0;
            var severity = 0;

            var layers = lines.Select(x => x.Split(new[] { ":" }, StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToArray())
                .Select(x => new Layer() { LayerDepth = x[0], Range = x[1], Position = 0 }).ToArray();

            var arrayCount = 0;
            while (depthOfPacket <= layers.Select(x => x.LayerDepth).Max())
            {
                if (depthOfPacket == layers[arrayCount].LayerDepth)
                {
                    if (layers[arrayCount].Position == 0)
                    {
                        severity += layers[arrayCount].LayerDepth * layers[arrayCount].Range;
                    }
                    arrayCount++;
                }

                depthOfPacket++;
                foreach (var layer in layers) //Maybe there is a more elegant way?
                {
                    layer.ChangePositionAfterPicosecond();
                }
            }
            Console.WriteLine(severity);
        }
    }
}
