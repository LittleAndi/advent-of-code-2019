using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day02
{
    class Program
    {
        static Dictionary<int, int> registers = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt")
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToList();
             var intCodes = lines[0].Split(',').Select(l => int.Parse(l)).ToArray();
            //var intCodes = "1,1,1,4,99,5,6,0,99".Split(',').Select(l => int.Parse(l)).ToArray();

            var part1Codes = new int[intCodes.Length];
            Array.Copy(intCodes, part1Codes, intCodes.Length);
            Part1(part1Codes);

            var part2Codes = new int[intCodes.Length];
            Array.Copy(intCodes, part2Codes, intCodes.Length);

            for (int i = 0; i <= 99; i++)
            {
                for (int j = 0; j <= 99; j++)
                {
                    Array.Copy(intCodes, part2Codes, intCodes.Length);
                    var result = Part2(part2Codes, i, j);

                    if (result == 19690720)
                    {
                        System.Console.WriteLine(100 * i + j);
                        break;
                    }
                }
            }
        }

        static void Part1(int[] intCodes)
        {
            intCodes[1] = 12;
            intCodes[2] = 2;

            var running = true;
            int pos = 0;
            while (running)
            {
                var opcode = intCodes[pos];

                switch (opcode)
                {
                    case 99:
                        running = false;
                        break;
                    case 1: // add
                        {
                            var resultRegister = intCodes[pos + 3];
                            var result = intCodes[intCodes[pos + 1]] + intCodes[intCodes[pos + 2]];
                            intCodes[resultRegister] = result;
                        }
                        break;
                    case 2:
                        {
                            var resultRegister = intCodes[pos + 3];
                            var result = intCodes[intCodes[pos + 1]] * intCodes[intCodes[pos + 2]];
                            intCodes[resultRegister] = result;
                        }
                        break;
                    default:
                        running = false;
                        break;
                }

                pos += 4;
            }

            System.Console.WriteLine(intCodes[0]);
        }

        static int Part2(int[] intCodes, int p1, int p2)
        {
            intCodes[1] = p1;
            intCodes[2] = p2;

            var running = true;
            int pos = 0;
            while (running)
            {
                var opcode = intCodes[pos];

                switch (opcode)
                {
                    case 99:
                        running = false;
                        break;
                    case 1: // add
                        {
                            var resultRegister = intCodes[pos + 3];
                            var result = intCodes[intCodes[pos + 1]] + intCodes[intCodes[pos + 2]];
                            intCodes[resultRegister] = result;
                        }
                        break;
                    case 2:
                        {
                            var resultRegister = intCodes[pos + 3];
                            var result = intCodes[intCodes[pos + 1]] * intCodes[intCodes[pos + 2]];
                            intCodes[resultRegister] = result;
                        }
                        break;
                    default:
                        running = false;
                        break;
                }

                pos += 4;
            }

            return intCodes[0];       
        }
    }
}
