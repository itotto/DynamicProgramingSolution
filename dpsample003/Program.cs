using System;
using System.Collections.Generic;
using System.Linq;

namespace dpsample003 {
    /// <summary>
    /// 特殊な2項間漸化式 1
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_recursive_formula_step2/edit?language_uid=c-sharp</remarks>
    class Program {
        static void Main() {
            var inputs = Console.ReadLine().Split(' ');
            var x = Convert.ToInt32(inputs[0]);
            var d_1 = Convert.ToInt32(inputs[1]);
            var d_2 = Convert.ToInt32(inputs[2]);
            var k = Convert.ToInt32(inputs[3]);

            Console.WriteLine(GetAnswer(x, d_1, d_2, k));
        }

#pragma warning disable IDE0044 // 読み取り専用修飾子を追加します
        static Dictionary<int, int> _answer = new();
#pragma warning restore IDE0044 // 読み取り専用修飾子を追加します

        static int GetAnswer(int x, int d_1, int d_2, int target) {
            if (!_answer.ContainsKey(target)) {
                _answer[1] = x;
                if (target >= 2) {
                    Enumerable.Range(2, target - 1).ToList().ForEach(i => {
                        if (i % 2 == 1) {
                            _answer[i] = _answer[i - 1] + d_1;
                        } else {
                            _answer[i] = _answer[i - 1] + d_2;
                        }
                    });
                }
            }
            return _answer[target];
        }
    }
}
