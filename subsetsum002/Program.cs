using System;
using System.Collections.Generic;

namespace subsetsum002 {
    /// <summary>
    /// 部分和問題 2
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_partial_sums_step1/edit?language_uid=c-sharp</remarks>
    class Program {

        static List<int> _weights = null;

        static int _targetValue = -1;

        /// <summary>
        /// 大きい数値はこのあまりに変換する
        /// </summary>
        const int BASE_NUM = 1000000007;

        /// <summary>
        /// 計算結果を保存しておく
        /// </summary>
        static Dictionary<string, int> _calculated = new Dictionary<string, int>();

        static void Main() {
            var conditions = Console.ReadLine().Split(' ');
            var n = Convert.ToInt32(conditions[0]);
            _targetValue = Convert.ToInt32(conditions[1]);

            _weights = new List<int>(n);
            for (var i = 0; i < n; i++) {
                var w = Convert.ToInt32(Console.ReadLine());
                if (w <= _targetValue) _weights.Add(w); // xより重いものは排除
            }
            n = _weights.Count;

            // 降順で並べ替え
            _weights.Sort((x, y) => x - y);

            var cnt = CountTargetCombination(0, n - 1);

            // 結果の表示
            Console.WriteLine(cnt);
        }


        static int CountTargetCombination(int currentValue, int startPos) {
            var key = $"{currentValue},{startPos}";
            if (_calculated.ContainsKey(key)) return _calculated[key];
            var cnt = 0;
            var need = _targetValue - currentValue;
            for (var i = startPos; i >= 0; i--) {
                var w = _weights[i];
                if (w > need) continue;
                else if (w == need) cnt++;
                else if (w < need) {
                    if (i > 0) {
                        cnt += CountTargetCombination(currentValue + w, i - 1);
                        if (cnt > BASE_NUM) cnt %= BASE_NUM;
                    }
                }
            }
            if (cnt > BASE_NUM) cnt %= BASE_NUM;
            _calculated.Add(key, cnt);
            return cnt;
        }
    }
}
