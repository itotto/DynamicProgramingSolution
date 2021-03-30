using System;
using System.Collections.Generic;
using System.Linq;

namespace dpsample002 {
    /// <summary>
    /// 2項間漸化式
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_recursive_formula_step1?language_uid=c-sharp</remarks>
    class Program {
        static void Main(string[] args) {
            var inputs = Console.ReadLine().Split(' ');
            var x = Convert.ToInt32(inputs[0]);
            var d = Convert.ToInt32(inputs[1]);

            var q = Convert.ToInt32(Console.ReadLine());

            var k_n = new List<int>();
            Enumerable.Range(1, q).ToList().ForEach(i => {
                k_n.Add(Convert.ToInt32(Console.ReadLine()));
            });

            foreach (var k in k_n) {
                Console.WriteLine(GetAnswer(x, d, k));
            }
        }


        static Dictionary<int, int> _answer = new Dictionary<int, int>();

        static int GetAnswer(int x, int d, int target) {
            if (!_answer.ContainsKey(target)) {
                _answer[1] = x;
                if (target >= 2) {
                    Enumerable.Range(2, target - 1).ToList().ForEach(i => {
                        _answer[i] = _answer[i - 1] + d;
                    });
                }
            }
            return _answer[target];
        }
    }
}
