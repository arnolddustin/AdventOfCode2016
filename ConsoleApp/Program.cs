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

                    case "20":
                        Day20();
                        break;

                    case "23":
                        Day23();
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

        void Day23()
        {
            Console.Clear();
            Console.WriteLine("Day 23...");

            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day23\\input.txt");
            var input = File.ReadAllLines(path);

            var s = new dotnet.day23.Solver(input, 7);
            var result = s.GetValueFromRegister('a');

            Console.WriteLine("After instructions, the value of register a is: {0}", result);

        }

        void Day20()
        {
            Console.Clear();
            Console.WriteLine("Day 20...");

            var path = string.Format("\\\\Mac\\Home\\Documents\\Projects\\Sandbox\\AdventOfCode2016\\dotnet\\day20\\input.txt");
            var input = File.ReadAllLines(path);

            var s = new dotnet.day20.Solver(input);
            var result = s.GetLowestUnblockedIP();

            Console.WriteLine("IP {0} is the lowest unblocked IP.", result);

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
