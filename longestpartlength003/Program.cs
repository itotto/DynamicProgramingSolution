using System;
using System.Collections.Generic;
using System.Linq;

namespace longestpartlength003 {
    /// <summary>
    /// 最長部分増加列 
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_lis_step0/edit?language_uid=c-sharp</remarks>
    class Program {
        static void Main() {
            var n = Convert.ToInt32(Console.ReadLine());

            // データの読み取り + 結果の初期化
            var trees = new List<int>(n);
            var r = new List<int>(n);
            Enumerable.Range(1, n).ToList().ForEach(x => {
                trees.Add(Convert.ToInt32(Console.ReadLine()));
                r.Add(1);
            });

            // 1 ～ n - 1まで移動
            for (var i = 1; i < n; i++) {
                for (var j = 0; j < i; j++) {
                    if (trees[j] < trees[i]) {
                        if (r[j] + 1 > r[i]) r[i] = r[j] + 1;
                    }
                }
            }

            // 並べ替える
            r.Sort((x, y) => y - x);

            // 結果を表示
            Console.WriteLine(r[0]);
        }
    }
}
