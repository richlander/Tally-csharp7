using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        // binary literals - take the form `0b` to represent bytes, much like `0x` for hex
        // can have separators (wherever you want) for readability
        int[] numbers = { 0b1, 0b10, 0b100, 0b1000, 0b1_0000, 0b10_0000 };

        // methods can return tuples
        // the tuple can be deconstructed, for natural usability
        var (sum, count) = Tally(numbers);
        WriteLine($"Sum: {sum}; Count:{count}");
    }

    // a method can define a return value as a tuple
    private static (int sum, int count) Tally(Int32[] numbers)
    {
        var t = (s: 0, c: 0);
        foreach (var v in numbers)
        {
            Add(v, 1);
        }
        return t;
        // local function
        // flexibility on where it sits in your code
        // can call itself, unlike lambdas
        void Add(int s, int c) { t = (t.s + s, t.c + c); }
    }
}
