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
       }
    }
}
