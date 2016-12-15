using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day10
{
    class Bot
    {
        public int Number { get; private set; }
        public int? Low { get { return _chips.Count == 2 ? _chips.Min() : (int?)null; } }
        public int? High { get { return _chips.Count == 2 ? _chips.Max() : (int?)null; } }

        readonly List<int> _chips;

        public Bot(int number)
        {
            Number = number;
            _chips = new List<int>();
        }

        public void GiveChip(int chip)
        {
            if (!_chips.Any(c => c == chip))
                _chips.Add(chip);
        }

        public int ChipCount()
        {
            return _chips.Count;
        }

        public bool HasChips(params int[] chips)
        {
            foreach (var chip in chips)
            {
                if (!_chips.Any(c => c == chip))
                    return false;
            }

            return true;
        }
    }

    class Output
    {
        public int Number { get; private set; }
        public int? ChipNumber { get; private set; }

        public Output(int number)
        {
            Number = number;
        }

        public void GiveChip(int chipNumber)
        {
            if (!ChipNumber.HasValue)
                ChipNumber = chipNumber;
        }
    }

    public class Solver
    {
        readonly List<Bot> _bots;
        readonly List<Output> _outputs;

        public Solver()
        {
            _bots = new List<Bot>();
            _outputs = new List<Output>();
        }

        public int MultiplyOutputNumbers(IEnumerable<string> instructions, params int[] outputNumbers)
        {
            ProcessInstructions(instructions);

            var total = 1;
            foreach (var i in outputNumbers)
                total = total * _outputs.First(o => o.Number == i).ChipNumber.Value;
            return total;
        }

        public int GetBotThatCompares(int chip1, int chip2, IEnumerable<string> instructions)
        {
            ProcessInstructions(instructions);

            var bot = _bots.FirstOrDefault(b => b.HasChips(chip1, chip2));

            return (bot != null) ? bot.Number : -1;
        }

        void ProcessInstructions(IEnumerable<string> instructions)
        {
            var current = 1;

            // repeat instructions until all bots have 2 chips
            while (true)
            {
                if (_bots.Count == 0 || _bots.Any(x => x.ChipCount() < 2))
                {
                    current++;
                    Console.WriteLine("Current run: {0}", current);
                    foreach (var instruction in instructions)
                        ProcessInstruction(instruction);
                }
                else
                {
                    Console.WriteLine("All bots have 2 chips");
                    break;
                }
            }
        }

        void ProcessInstruction(string instruction)
        {
            // EXAMPLE: bot 205 gives low to bot 169 and high to bot 3
            if (instruction.StartsWith("bot"))
            {
                var regex = new Regex(@"bot (?<botnumber>\d+) gives low to (?<lowtype>\w+) (?<lowtarget>\d+) and high to (?<hightype>\w+) (?<hightarget>\d+)");
                var match = regex.Match(instruction);

                if (match.Length == 0)
                    throw new ApplicationException("invalid instruction: " + instruction);

                var botnumber = int.Parse(match.Groups["botnumber"].Value);
                var lowIsBot = match.Groups["lowtype"].Value == "bot";
                var lowTarget = int.Parse(match.Groups["lowtarget"].Value);
                var highIsBot = match.Groups["hightype"].Value == "bot";
                var highTarget = int.Parse(match.Groups["hightarget"].Value);

                // create bots if needed
                if (!_bots.Any(b => b.Number == botnumber))
                    _bots.Add(new Bot(botnumber));
                if (lowIsBot && !_bots.Any(b => b.Number == lowTarget))
                    _bots.Add(new Bot(lowTarget));
                if (highIsBot && !_bots.Any(b => b.Number == highTarget))
                    _bots.Add(new Bot(highTarget));

                // create outputs if needed
                if (!lowIsBot && !_outputs.Any(o => o.Number == lowTarget))
                    _outputs.Add(new Output(lowTarget));
                if (!highIsBot && !_outputs.Any(o => o.Number == highTarget))
                    _outputs.Add(new Output(highTarget));

                // get the bot
                var bot = _bots.Single(b => b.Number == botnumber);

                // bots can move if they have 2 chips
                if (bot.ChipCount() == 2)
                {
                    // process low
                    var low = bot.Low.Value;
                    if (lowIsBot)
                        _bots.Single(b => b.Number == lowTarget).GiveChip(low);
                    else
                        _outputs.Single(o => o.Number == lowTarget).GiveChip(low);

                    // process high
                    var high = bot.High.Value;
                    if (highIsBot)
                        _bots.Single(b => b.Number == highTarget).GiveChip(high);
                    else
                        _outputs.Single(o => o.Number == highTarget).GiveChip(high);
                }
            }

            if (instruction.StartsWith("value"))
            {
                //value 61 goes to bot 144
                var regex = new Regex(@"value (?<chipnumber>\d+) goes to bot (?<botnumber>\d+)");
                var match = regex.Match(instruction);

                if (match.Length == 0)
                    throw new ApplicationException("invalid instruction: " + instruction);

                var botnumber = int.Parse(match.Groups["botnumber"].Value);
                var chipnumber = int.Parse(match.Groups["chipnumber"].Value);

                // create bots if needed
                if (!_bots.Any(b => b.Number == botnumber))
                    _bots.Add(new Bot(botnumber));

                // add to bot
                _bots.FirstOrDefault(b => b.Number == botnumber).GiveChip(chipnumber);
            }
        }
    }
}
