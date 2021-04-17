using System;
using System.Collections.Generic;

namespace longestpartlength002 {
    /// <summary>
    /// 【連続部分列】最長減少連続部分列
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_lis_continuous_boss/edit?language_uid=c-sharp</remarks>
    class Program {
        static void Main() {
            var input = Convert.ToInt32(Console.ReadLine());
            var inputs = new List<int>();
            for (var i = 0; i < input; i++) {
                inputs.Add(Convert.ToInt32(Console.ReadLine()));
            }
            // その部分までの最長減少長
            var r = new List<int>(input) { 1 };
            for (var i = 1; i < input; i++) {
                r.Add((inputs[i] <= inputs[i - 1]) ? r[i - 1] + 1 : 1);
            }
            // 長さで並び替える
            r.Sort((x, y) => y - x);

            // 結果を出力
            Console.WriteLine(r[0]);
        }
    }
}
