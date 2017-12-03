using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    class Day03
    {
        static void Main(string[] args)
        {
            var input = 289326;
            var counter = 0;
            var ebene = 1;

            while (counter <= input)
            {
                counter = (int) Math.Pow(ebene, 2);
                ebene = ebene + 2;
            }
            ebene = ebene / 2;
            var top = 4;
            var bottom = 8;
            var left = 6;
            var right = 2;
            for (int i = 1; i <= ebene-2; i++)
            {
                top += 3 + i * 8;
                bottom += 7 + i * 8;
                left += 5 + i * 8;
                right += 1 + i * 8;
            }
            var arr = new[] {top, bottom, left, right};
            var min = arr.Min(x => Math.Abs(x - input));
            Console.WriteLine(ebene-1 +min);
        }
    }
}
