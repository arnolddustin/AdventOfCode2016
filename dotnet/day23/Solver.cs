using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet.day23
{
    static class Extensions
    {
        public static string Display(this Dictionary<char, int> registers)
        {
            var sb = new StringBuilder();

            foreach (var register in registers)
                sb.AppendFormat("[{0}:{1}]", register.Key, register.Value);
            
            return sb.ToString();
        }
    }
    public class Solver
    {
        readonly List<string> _instructions;
        readonly Dictionary<char, int> _registers;

        public Solver(IEnumerable<string> instructions, int initialValueOfA)
        {
            _instructions = new List<string>(instructions);
            _registers = new Dictionary<char, int>();
            foreach (var reg in "abcde".ToArray())
            {
                if (reg == 'a')
                    _registers.Add(reg, initialValueOfA);
                else
                    _registers.Add(reg, 0);
            }
        }

        public int GetValueFromRegister(char register)
        {
            var currentIndex = 0;
            while (true)
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

            if (instruction == "cpy b c" 
                && _instructions[index+1] == "inc a" 
                && _instructions[index+2] == "dec c" 
                && _instructions[index+3] == "jnz c -2" 
                && _instructions[index+4] == "dec d" 
                && _instructions[index+5] == "jnz d -5")
            {
                _registers['a'] = _registers['b'] * _registers['d'];
                return index + 6;
            }

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

                case "tgl":
                    ProcessToggle(instruction, index);
                    return index + 1;

                default:
                    throw new ArgumentException("unknown command: " + instruction);
            }
        }

        void ProcessToggle(string instruction, int currentInstructionIndex)
        {
            var register = instruction[4];
            var regvalue = _registers[register];

            var toggleIndex = currentInstructionIndex + regvalue;
            var toggleInstruction = _instructions.ElementAtOrDefault(toggleIndex);
            if (toggleInstruction == null) return;

            switch (toggleInstruction.Substring(0, 3))
            {
                case "cpy":
                    _instructions[toggleIndex] = toggleInstruction.Replace("cpy", "jnz");
                    break;

                case "jnz":
                    _instructions[toggleIndex] = toggleInstruction.Replace("jnz", "cpy");
                    break;

                case "inc":
                    _instructions[toggleIndex] = toggleInstruction.Replace("inc", "dec");
                    break;

                default:
                    _instructions[toggleIndex] = string.Format("inc{0}", toggleInstruction.Substring(3));
                    break;
            }
        }

        void ProcessCopy(string instruction)
        {
            int fail;
            if (int.TryParse(instruction.Last().ToString(), out fail))
                return; // skip if we're trying to copy to a number

            var toCopy = instruction.Split(' ')[1];
            var target = instruction.Last();

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

        // expects value or register first, then int (distance to jump)
        int? ProcessJump(string instruction, int currentInstructionIndex)
        {
            var middle = instruction.Split(' ')[1];
            var end = instruction.Substring(instruction.LastIndexOf(' ') + 1);

            int middleval;
            if (!int.TryParse(middle, out middleval))
                middleval = _registers[char.Parse(middle)];

            if (middleval == 0)
                return currentInstructionIndex + 1;

            int endval;
            if (!int.TryParse(end, out endval))
                endval = _registers[char.Parse(end)];

            return currentInstructionIndex + endval;
        }
    }
}
