using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Day1_2
{
    class Day1_2
    {
        static void Main(string[] args)
        {
            var reader = new StreamReader("../../input.txt");
            var line = reader.ReadLine().ToCharArray();
            var digits = line.Select(x => (int)Char.GetNumericValue(x)).ToArray();
            var sum = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i] == digits[(i + (digits.Length / 2)) % digits.Length])
                {
                    sum += digits[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
