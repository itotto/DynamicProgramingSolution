using System;
using System.Collections.Generic;

namespace stairsup001 {
    class Program {
        static void Main(string[] args) {
            var input = Convert.ToInt32(Console.ReadLine());

            // 返却値を初期化
            var r = new List<int>(input) { 1 };
            for (var i = 1; i <= input; i++) {
                r.Add(0);
                // 1段上る
                if (i >= 1) r[i] += r[i - 1];

                // 2段上る
                if (i >= 2) r[i] += r[i - 2];
            }

            Console.WriteLine(r[input]);
        }
    }
}
