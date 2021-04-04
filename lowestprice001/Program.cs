using System;
using System.Collections.Generic;

namespace lowestprice001 {
    /// <summary>
    /// 最安値を達成するには 1
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_apples_step0/edit?language_uid=c-sharp</remarks>
    class Program {
        static void Main() {
            // 入力
            var inputs = Console.ReadLine().Split(' ');
            var n = Convert.ToInt32(inputs[0]);
            var a = Convert.ToInt32(inputs[1]);
            var b = Convert.ToInt32(inputs[2]);

            // 結果を表示
            Console.WriteLine(CalcPrice(n, a, b));
        }

        /// <summary>
        /// 最安値を計算
        /// </summary>
        /// <param name="n">買う個数</param>
        /// <param name="unitPrice1">1個買ったときの単価</param>
        /// <param name="unitPrice2">2個買ったときの単価</param>
        /// <returns>最安値</returns>
        static int CalcPrice(int n, int unitPrice1, int unitPrice2) {
            const int UNIT1 = 1;
            const int UNIT2 = 2;
            var r = new List<int>() { 0 };

            for (var i = 1; i <= n; i++) {
                var p1 = 0; var p2 = 0;
                if (i >= UNIT1) {
                    p1 = unitPrice1 + r[i - UNIT1];
                }

                if (i >= UNIT2) {
                    p2 = unitPrice2 + r[i - UNIT2];
                }
                if (p1 == 0) {
                    r.Add(p2);
                } else if (p2 == 0) {
                    r.Add(p1);
                } else {
                    r.Add(p1 > p2 ? p2 : p1);
                }
            }
            return r[r.Count - 1];
        }
    }
}
