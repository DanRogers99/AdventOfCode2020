using AoCHelper;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day_08 : BaseDay
    {
        private readonly List<GameConsoleCode> _code;

        public Day_08() => _code = File.ReadAllLines(InputFilePath).Select(line =>
                         {
                             string[] instructionSet = line.Split(" ");
                             return new GameConsoleCode
                             {
                                 Instruction = instructionSet[0],
                                 Operation = int.Parse(instructionSet[1])
                             };
                         }).ToList();

        public override string Solve_1()
        {
            ExecuteProgram(_code, out int accumulator);
            return accumulator.ToString();
        }

        public override string Solve_2()
        {
            for (int i = 0; i < _code.Count; i++)
            {
                List<GameConsoleCode> consoleCode = _code.Select(x => x with { Executed = false }).ToList();

                switch (consoleCode[i].Instruction)
                {
                    case "jmp":
                        consoleCode[i].Instruction = "nop";
                        break;
                    case "nop":
                        consoleCode[i].Instruction = "jmp";
                        break;
                    default:
                        continue;
                }

                if (ExecuteProgram(consoleCode, out int accumulator))
                {
                    return accumulator.ToString();
                }
            }
            throw new SolvingException();
        }

        private static bool ExecuteProgram(IList<GameConsoleCode> code, out int accumulator)
        {
            accumulator = 0;
            int exectution = 0;

            while (exectution != code.Count)
            {
                if (code[exectution].Executed == true)
                {
                    return false;
                }

                code[exectution].Executed = true;

                switch (code[exectution].Instruction)
                {
                    case "jmp":
                        exectution += code[exectution].Operation;
                        break;
                    case "acc":
                        accumulator += code[exectution].Operation;
                        exectution++;
                        break;
                    default:
                        exectution++;
                        break;
                }
            }
            return true;
        }

        record GameConsoleCode
        {
            public string Instruction { get; set; }
            public int Operation { get; set; }
            public bool Executed { get; set; }
        }
    }
}

