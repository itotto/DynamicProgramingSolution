using System;
using System.Collections.Generic;
using System.Linq;

namespace dpsample003 {
    class Program {
        static void Main(string[] args) {
            var inputs = Console.ReadLine().Split(' ');
            var x = Convert.ToInt32(inputs[0]);
            var d_1 = Convert.ToInt32(inputs[1]);
            var d_2 = Convert.ToInt32(inputs[2]);
            var k = Convert.ToInt32(inputs[3]);

            Console.WriteLine(GetAnswer(x, d_1, d_2, k));
        }


        static Dictionary<int, int> _answer = new Dictionary<int, int>();

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
