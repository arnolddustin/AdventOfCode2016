using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day19
{
    public class Elf
    {
        public int Number { get; private set; }
        public int Presents { get; set; }

        public Elf(int number, int presents)
        {
            Number = number;
            Presents = presents;
        }
    }

    public class Solver
    {
        readonly int _numberOfElves;

        public Solver(int numberOfElves)
        {
            _numberOfElves = numberOfElves;
        }

        public int WhichElfGetsAllThePresents()
        {
            var q = new Queue<Elf>();

            for (int i = 0; i < _numberOfElves; i++)
                q.Enqueue(new Elf(i + 1, 1));

            while (q.Count() > 1)
            {
                var first = q.Dequeue();
                var second = q.Dequeue();

                first.Presents += second.Presents;
                q.Enqueue(first);
            }

            return q.Single().Number;
        }

        public int WhichElfGetsAllThePresentsPart2()
        {
            int pow = (int)Math.Floor(Math.Log(_numberOfElves) / Math.Log(3));
            int b = (int)Math.Pow(3, pow);

            if (_numberOfElves == b)
                return _numberOfElves;

            if (_numberOfElves - b <= b)
                return _numberOfElves - b;

            return 2 * _numberOfElves - 3 * b;
        }
    }
}
