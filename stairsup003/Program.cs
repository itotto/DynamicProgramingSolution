using System;
using System.Collections.Generic;

namespace stairsup003 {
    class Program {
        static void Main() {

            var inputs = Console.ReadLine().Split(' ');
            var n = Convert.ToInt32(inputs[0]);

            var upunit = new List<int>();
            for (var i = 1; i < inputs.Length; i++) {
                upunit.Add(Convert.ToInt32(inputs[i]));
            }
            upunit.Sort((x, y) => x - y);

            // 結果
            var r = new List<int> { 1 };
            for (var i = 1; i <= n; i++) {
                r.Add(0);
                foreach (var u in upunit) {
                    if (i >= u) r[i] += r[i - u];
                }
            }

            // 結果表示
            Console.WriteLine(r[r.Count - 1]);
        }
    }
}