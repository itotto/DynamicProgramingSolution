using System;
using System.Collections.Generic;

namespace lowestprice003 {
    /// <summary>
    /// 最安値を達成するには 3
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_apples_step2/edit?language_uid=c-sharp</remarks>
    class Program {
        static void Main() {
            // 入力
            var inputs = Console.ReadLine().Split(' ');
            var n = Convert.ToInt32(inputs[0]);
            var x = Convert.ToInt32(inputs[1]);
            var a = Convert.ToInt32(inputs[2]);
            var y = Convert.ToInt32(inputs[3]);
            var b = Convert.ToInt32(inputs[4]);

            // 結果を表示
            Console.WriteLine(CalcPrice(n, x, a, y, b));
        }

        /// <summary>
        /// 最安値を計算
        /// </summary>
        /// <param name="n">買う個数</param>
        /// <param name="unit1">販売単位(1つ目)</param>
        /// <param name="unitPrice1">[unit1]個買ったときの単価</param>
        /// <param name="unit2">販売単位(2つ目)</param>
        /// <param name="unitPrice2">[unit2]個買ったときの単価</param>
        /// <returns>最安値</returns>
        static int CalcPrice(int n, int unit1, int unitPrice1, int unit2, int unitPrice2) {
            var r = new List<int>() { 0 };
            var overcount = unit1 > unit2 ? unit1 : unit2;

            for (var i = 1; i <= n + overcount - 1; i++) {
                var p1 = -1; var p2 = -1;
                if (i >= unit1) {
                    if (r[i - unit1] != -1) {
                        p1 = unitPrice1 + r[i - unit1];
                    }
                }

                if (i >= unit2) {
                    if (r[i - unit2] != -1) {
                        p2 = unitPrice2 + r[i - unit2];
                    }
                }

                if (p1 == -1 && p2 == -1) {
                    r.Add(-1);
                } else if (p1 == -1) {
                    r.Add(p2); // p2 != -1
                } else if (p2 == -1) {
                    r.Add(p1); // p1 != -1
                } else {
                    r.Add(p1 > p2 ? p2 : p1);
                }
            }

            var lowest = r[n];
            for (var i = n + 1; i <= n + overcount - 1; i++) {
                if (r[i] != -1 ) {
                    if (lowest == -1 || lowest > r[i]) lowest = r[i];
                }
            }
            return lowest == -1 ? 0 : lowest;
        }
    }
}
