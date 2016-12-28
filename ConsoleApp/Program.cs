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
            Console.WriteLine("Enter day number (or press Q or X to exit): ");

            try
            {
                var line = Console.ReadLine();

                switch (line.ToUpper())
                {
                    case "8":
                        Day8();
                        break;

                    case "11":
                        new Day11().Run();
                        break;

                    case "19":
                        Day19();
                        break;

                    case "Q":
                    case "X":
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Unknown day: {0}", line);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Done. Press any key to continue.");
            Run();
        }

        void Day19()
        {
            Console.Clear();
            Console.WriteLine("Day 19...");

            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day19\\input.txt");
            var input = File.ReadAllLines(path);

            var s = new dotnet.day19.Solver(int.Parse(input.First()));
            var elf = s.WhichElfGetsAllThePresents();

            Console.WriteLine("Elf {0} gets all the presents", elf);

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
