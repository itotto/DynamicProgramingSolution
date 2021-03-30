using System;
using System.Linq;

namespace dpsample001 {
    /// <summary>
    /// 2項間漸化式 1 
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_recursive_formula_step0/edit?language_uid=c-sharp</remarks>
    class Program {
        static void Main() {
            var inputs = Console.ReadLine().Split(' ');
            var x = Convert.ToInt32(inputs[0]);
            var d = Convert.ToInt32(inputs[1]);
            var k = Convert.ToInt32(inputs[2]);

            var r = x;
            Enumerable.Range(2, k - 1).ToList().ForEach(i => r += d);
            Console.WriteLine(r);
        }
    }
}
