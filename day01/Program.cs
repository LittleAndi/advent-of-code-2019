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
            System.Console.WriteLine(lines.Sum());
        }
    }
}
