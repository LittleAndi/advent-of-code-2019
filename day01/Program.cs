using System;
using System.IO;
using System.Linq;

namespace day01
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt")
                .Where(l => !string.IsNullOrWhiteSpace(l))
                .Select(l => Math.Floor(decimal.Parse(l)/3)-2)
                .ToList();
            System.Console.WriteLine($"Part 1: {lines.Sum()}");

            var tot = 0m;
            foreach (var item in lines)
            {
                var reqFuel = item;
                tot+=item;
                while ((reqFuel = Math.Floor(reqFuel/3)-2) > 0)
                {
                    tot+=reqFuel;
                }
            }

            System.Console.WriteLine($"Part 2: {tot}");
        }
    }
}
