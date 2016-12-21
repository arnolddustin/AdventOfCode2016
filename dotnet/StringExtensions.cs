using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet
{
    public static class StringExtensions
    {
        public static void ToConsole(this IEnumerable<string> lines)
        {
            Console.WriteLine("-----------------------------");
            foreach (var line in lines)
                Console.WriteLine(line);
            Console.WriteLine("=============================");
        }
    }
}
