using System;
using System.Collections.Generic;
using System.Linq;

namespace fibonaccisample001 {
    /// <summary>
    /// 漸化式】 3項間漸化式 2
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_recursive_formula_boss/edit?language_uid=c-sharp</remarks>
    class Program {
        static void Main() {
            var input = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(GetAnswer(input));
        }

#pragma warning disable IDE0044 // 読み取り専用修飾子を追加します
        static Dictionary<int, int> _answer = new();
#pragma warning restore IDE0044 // 読み取り専用修飾子を追加します

        static int GetAnswer(int target) {
            if (!_answer.ContainsKey(target)) {
                _answer[1] = 1;
                _answer[2] = 1;
                if (target >= 3) {
                    Enumerable.Range(3, target - 1).ToList().ForEach(i => {
                        _answer[i] = _answer[i - 2] + _answer[i - 1];
                    });
                }
            }
            return _answer[target];
        }
    }
}
