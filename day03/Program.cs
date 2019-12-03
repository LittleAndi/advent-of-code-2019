using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace day03
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt")
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .ToList();

            var directions1 = lines[0].Split(',');
            var directions2 = lines[0].Split(',');

            int[,] map = new int[20000, 20000];


            for (int j = 0; j < 2; j++)
            {
                int x = map.GetLength(0) / 2;
                int y = map.GetLength(1) / 2;
                var instructions = lines[j].Split(',');

                for (int i = 0; i < instructions.Length; i++)
                {
                    var ins = instructions[i];
                    var d = ins[0];
                    var dist = int.Parse(ins.Remove(0, 1));

                    switch (d)
                    {
                        case 'U':
                            {
                                for (int my = 1; my <= dist; my++)
                                {
                                    y -= 1;
                                    // System.Console.WriteLine($"{x},{y}");
                                    map[x, y] += j + 1;
                                }
                            }
                            break;
                        case 'D':
                            {
                                for (int my = 1; my <= dist; my++)
                                {
                                    y += 1;
                                    // System.Console.WriteLine($"{x},{y}");
                                    map[x, y] += j + 1;
                                }
                            }
                            break;
                        case 'L':
                            {
                                for (int mx = 1; mx <= dist; mx++)
                                {
                                    x -= 1;
                                    // System.Console.WriteLine($"{x},{y}");
                                    map[x, y] += j + 1;
                                }
                            }
                            break;
                        case 'R':
                            {
                                for (int mx = 1; mx <= dist; mx++)
                                {
                                    x += 1;
                                    // System.Console.WriteLine($"{x},{y}");
                                    map[x, y] += j + 1;
                                }
                            }
                            break;
                    }
                }

            }
     
            int closest = map.GetLength(0)+map.GetLength(1);

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y] > 2) 
                    {
                        var dist = Math.Abs(x-map.GetLength(0)/ 2) + Math.Abs(y - map.GetLength(1) / 2);
                        if (dist < closest)
                        {
                            closest = dist;
                            System.Console.WriteLine($"{x},{y}: {closest}");
                            
                        }
                    }
                }
            }

        }
    }
}
