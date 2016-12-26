using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day15
{
    public class Disc
    {
        public int Size { get; private set; }
        public int InitialPosition { get; private set; }

        public Disc(int size, int initialPosition)
        {
            Size = size;
            InitialPosition = initialPosition;
        }
    }

    public class Solver
    {
        const int MAX = 1000000000;
        readonly Disc[] _discs;

        public Solver(params Disc[] discs)
        {
            _discs = discs;
        }

        public int Example()
        {
            for (var t = 0; t < MAX; t++)
                if ((4 + (t + 1)) % 5 == 0)
                    if ((1 + (t + 2)) % 2 == 0)
                        return t;

            return 0;
        }
        public int Part1()
        {
            for (var t = 0; t < MAX; t++)
                if ((11 + (t + 1)) % 13 == 0)
                    if ((0 + (t + 2)) % 5 == 0)
                        if ((11 + (t + 3)) % 17 == 0)
                            if ((0 + (t + 4)) % 3 == 0)
                                if ((2 + (t + 5)) % 7 == 0)
                                    if ((17 + t + 6) % 19 == 0)
                                        return t;
            return 0;
        }

        public int Part2()
        {
            for (var t = 0; t < MAX; t++)
                if ((11 + (t + 1)) % 13 == 0)
                    if ((0 + (t + 2)) % 5 == 0)
                        if ((11 + (t + 3)) % 17 == 0)
                            if ((0 + (t + 4)) % 3 == 0)
                                if ((2 + (t + 5)) % 7 == 0)
                                    if ((17 + t + 6) % 19 == 0)
                                        if ((0 + t + 7) % 11 == 0)
                                            return t;
            return 0;
        }
    }
}
