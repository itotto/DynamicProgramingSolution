using System;
using System.Collections.Generic;

namespace subsetsum001 {
    /// <summary>
    /// 部分和問題
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_partial_sums_step0/edit?language_uid=c-sharp</remarks>
    class Program {
        static void Main() {
            // 入力を受け付け
            var conditions = Console.ReadLine().Split(' ');
            var n = Convert.ToInt32(conditions[0]); // 錘の数
            var x = Convert.ToInt32(conditions[1]); // 生成したい重さの和

            var weights = new List<int>();
            for (var i = 0; i < n; i++) {
                weights.Add(Convert.ToInt32(Console.ReadLine()));
            }

            // 結果を初期化
            var r = new List<bool>(x + 1);
            for (var i = 0; i <= x; i++) {
                r.Add(false);
            }

            r[0] = true; // 0は未選択で達成できる
            // 1 → n-1までの錘を使う
            for (var i = 0; i < n; i++) {
                // x → weights[i]まで重さを変えてその重さの和を作れるか調べる
                for (var j = x; j >= weights[i]; j--) {
                    if (r[j - weights[i]]) r[j] = true;
                }
            }

            // 結果を表示
            Console.WriteLine(r[x] ? "yes" : "no");
        }
    }
}
