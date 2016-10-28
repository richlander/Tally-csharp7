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
        // now an oject array to allow for different types of data
        object[] numbers = { 0b1, new object[] { 0b10, 0b100, 0b1000, 0b1_0000 }, null, 0b10_0000 };

        // methods can return tuples
        // the tuple can be deconstructed, for natural usability
        var (sum, count) = Tally(numbers);
        WriteLine($"Sum: {sum}; Count:{count}");
    }

    // a method can define a return value as a tuple
    private static (int sum, int count) Tally(object[] numbers)
    {
        var t = (s: 0, c: 0);
        foreach (var v in numbers)
        {
            // you can now switch on any type
            // cases can be patterns
            switch (v)
            {
                // similar to the if statement we had before
                // `int i` is a pattern
                case int i:
                    Add(i, 1);
                    break;
                // add similar pattern for object[]
                // adds the twist of a condition
                // avoiding need to check on length within the case
                // uses tuples again
                case object[] o when o.Length > 0:
                    var (summy, county) = Tally(o);
                    Add(summy, county); 
                    break;

            }
        }
        return t;
        // local function
        // flexibility on where it sits in your code
        // can call itself, unlike lambdas
        void Add(int s, int c) { t = (t.s + s, t.c + c); }
    }
}
