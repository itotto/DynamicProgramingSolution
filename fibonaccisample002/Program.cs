using System;
using System.Collections.Generic;
using System.Linq;

namespace fibonaccisample002 {

    class Program {
        static void Main() {
            var q = Convert.ToInt32(Console.ReadLine());

            var k_n = new List<int>();
            Enumerable.Range(1, q).ToList().ForEach(i => {
                k_n.Add(Convert.ToInt32(Console.ReadLine()));
            });

            foreach (var k in k_n) {
                Console.WriteLine(GetAnswer(k));
            }
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
