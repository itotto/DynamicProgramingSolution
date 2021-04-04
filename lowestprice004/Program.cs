using System;
using System.Collections.Generic;

namespace lowestprice004 {
    /// <summary>
    /// 最安値を達成するには 4
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_apples_boss/edit?language_uid=c-sharp</remarks>
    class Program {
        static void Main() {
            // 入力
            var inputs = Console.ReadLine().Split(' ');
            var n = Convert.ToInt32(inputs[0]);
            var unitprices = new List<KeyValuePair<int, int>>();

            var max = 0;
            for (var i = 1; i < inputs.Length; i += 2) {
                var key = Convert.ToInt32(inputs[i]);
                var value = Convert.ToInt32(inputs[i + 1]);
                if (key > max) max = key; // 最大値を持っておく
                unitprices.Add(new KeyValuePair<int, int>(key, value));
            }

            // 結果を表示
            Console.WriteLine(CalcPrice(n, unitprices, max));
        }

        /// <summary>
        /// 最安値を計算
        /// </summary>
        /// <param name="n">買う個数</param>
        /// <param name="unitPrices">key:単位個数, value:単価</param>
        /// <param name="overCount">超過して計算する数</param>
        /// <returns>最安値</returns>
        static int CalcPrice(int n, List<KeyValuePair<int, int>> unitPrices, int overCount) {
            var r = new List<int>() { 0 };

            for (var i = 1; i <= n + overCount - 1; i++) {
                var pn = new List<int>(n);
                unitPrices.ForEach(x => pn.Add(-1)); // -1で初期化

                // 全部のパターンを検証
                for (var j = 0; j < unitPrices.Count; j++) {
                    var unitCount = unitPrices[j].Key;
                    if (i >= unitCount && r[i - unitCount] != -1) {
                        pn[j] = unitPrices[j].Value + r[i - unitCount];
                    }
                }

                r.Add(-1);
                for (var k = 0; k < unitPrices.Count; k++) {
                    if (pn[k] != -1) {
                        if (r[i] == -1 || r[i] > pn[k]) r[i] = pn[k];
                    }
                }
            }

            var lowest = r[n];
            for (var i = n + 1; i <= n + overCount - 1; i++) {
                if (r[i] != -1) {
                    if (lowest == -1 || lowest > r[i]) lowest = r[i];
                }
            }
            return lowest == -1 ? 0 : lowest;
        }
    }
}
