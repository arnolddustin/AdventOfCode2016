using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnet.day8;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
        }

        void Run()
        {
            Console.WriteLine("Advent of Code 2016");
            Console.WriteLine("Enter day number: ");

            try
            {
                var line = Console.ReadLine();

                switch (line)
                {
                    case "8":
                        Day8();
                        break;
                }

             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Done. Press any key to exit.");
            Console.ReadKey();
        }

        void Day8()
        {
            Console.Clear();
            Console.WriteLine("Day 8...");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day8\\input.txt");
            var input = File.ReadAllLines(path);

            var solver = new Solver(50, 6);
            solver.ScreenUpdated += Solver_ScreenUpdated;

            solver.RunInstructions(input, 100);
        }

        private void Solver_ScreenUpdated(object sender, IEnumerable<string> e)
        {
            Console.Clear();
            foreach (var line in e)
            {
                foreach(var c in line)
                {
                    Console.ForegroundColor = (c == '#') ? ConsoleColor.Yellow : ConsoleColor.DarkBlue;
                    Console.Write(c);
                }
                Console.Write('\n');
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
