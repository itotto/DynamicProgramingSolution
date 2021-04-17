using System;
using System.Collections.Generic;

namespace longestpartlength004 {
    /// <summary>
    /// 【部分列】最長減少部分列
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_lis_boss/edit?language_uid=c-sharp</remarks>
    class Program {
        static void Main() {
            // 情報入力
            var n = Convert.ToInt32(Console.ReadLine());
            var trees = new List<int>(n); // 気の長さ
            var r = new List<int>(n); // 該当の場所までの最長の長さ
            for (var i = 0; i < n; i++) {
                trees.Add(Convert.ToInt32(Console.ReadLine()));
                r.Add(1);
            }

            for (var i = 1; i < n; i++) {
                for (var j = 0; j < i; j++) {
                    if (trees[i] < trees[j]) {
                        if (r[i] < r[j] + 1) r[i] = r[j] + 1;
                    }
                }
            }

            // 結果の表示
            r.Sort((x, y) => y - x);
            Console.WriteLine(r[0]);
        }
    }
}
