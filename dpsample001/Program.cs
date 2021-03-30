using System;
using System.Linq;

namespace dpsample001 {
    class Program {
        static void Main(string[] args) {
            var inputs = Console.ReadLine().Split(' ');
            var x = Convert.ToInt32(inputs[0]);
            var d = Convert.ToInt32(inputs[1]);
            var k = Convert.ToInt32(inputs[2]);

            var r = x;
            Enumerable.Range(2, k - 1).ToList().ForEach(i => {
                r += d;
            });
            Console.WriteLine(r);
        }
    }
}
