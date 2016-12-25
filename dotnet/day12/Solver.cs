using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day12
{
    public class Solver
    {
        readonly List<string> _instructions;
        readonly Dictionary<char, int> _registers;

        public Solver(IEnumerable<string> instructions, bool part2)
        {
            if (instructions.Count() < 1)
                throw new ArgumentOutOfRangeException("instructions", "at least one instruction is required");

            _instructions = new List<string>(instructions);
            _registers = new Dictionary<char, int>();
            foreach (var reg in "abcde".ToArray())
            {
                if (part2 && reg == 'c')
                    _registers.Add(reg, 1);
                else
                _registers.Add(reg, 0);
            }
        }

        public int GetValueFromRegister(char register)
        {
            var currentIndex = 0;
            while(true)
            {
                var nextInstruction = ProcessInstructionAt(currentIndex);

                if (!nextInstruction.HasValue)
                    break;

                currentIndex = nextInstruction.Value;
            }

            return _registers[register];
        }

        int? ProcessInstructionAt(int index)
        {
            if (_instructions.Count < index + 1) return null;

            var instruction = _instructions[index];
            var command = instruction.Substring(0, 3);

            switch (command)
            {
                case "cpy":
                    ProcessCopy(instruction);
                    return index + 1;

                case "inc":
                    ProcessIncrement(instruction);
                    return index + 1;

                case "dec":
                    ProcessDecrement(instruction);
                    return index + 1;

                case "jnz":
                    return ProcessJump(instruction, index);

                default:
                    throw new ArgumentException("unknown command: " + instruction);
            }
        }

        void ProcessCopy(string instruction)
        {
            var spaceIndex = instruction.IndexOf(' ', 4);
            var toCopy = instruction.Substring(4, spaceIndex - 4);
            var target = char.Parse(instruction.TrimEnd(' ').Substring(spaceIndex + 1));

            int val;
            if (!int.TryParse(toCopy, out val))
                val = _registers[char.Parse(toCopy)];

            _registers[target] = val;
        }

        void ProcessIncrement(string instruction)
        {
            var target = char.Parse(instruction.TrimEnd().Substring(4));

            int val = _registers[target];
            _registers[target] = val + 1;
        }

        void ProcessDecrement(string instruction)
        {
            var target = char.Parse(instruction.TrimEnd().Substring(4));

            int val = _registers[target];
            _registers[target] = val - 1;
        }

        int? ProcessJump(string instruction, int currentInstructionIndex)
        {
            var middlechar = instruction[4];
            var offset = int.Parse(instruction.Substring(6));

            if (!_registers.ContainsKey(middlechar))
            {
                if (int.Parse(middlechar.ToString()) == 0)
                    return currentInstructionIndex + 1;
            }
            else
            {
                var regvalue = _registers[middlechar];
                if (regvalue == 0)
                    return currentInstructionIndex + 1;
            }

            return currentInstructionIndex + offset;
        }
    }
}
