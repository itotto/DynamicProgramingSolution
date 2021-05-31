using System;
using System.Collections.Generic;

namespace subsetsum004 {
    /// <summary>
    /// 部分和問題 4 
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_partial_sums_boss/edit?language_uid=c-sharp</remarks>
    class Program {

        // 重りの値を保持
        static List<int> _weights = null;

        static void Main() {
            // 初期条件入力
            var conditions = Console.ReadLine().Split(' ');
            var n = Convert.ToInt32(conditions[0]); // 重りの種類数
            var targetWeight = Convert.ToInt32(conditions[1]); // 目標となる重さ

            // 重りの値を入力
            _weights = new List<int>(n);
            for (var i = 0; i < n; i++) {
                _weights.Add(Convert.ToInt32(Console.ReadLine()));
            }

            // 重い順に並べる
            _weights.Sort((x, y) => y - x);

            // 結果を取得
            var r = FindCombination(targetWeight, 0);

            // 結果の表示
            Console.WriteLine(r ? "yes" : "no");
        }

        // メモ
        static Dictionary<string, bool> _result = new Dictionary<string, bool>();

        /// <summary>
        /// 組み合わせを検索
        /// </summary>
        /// <param name="targetValue"></param>
        /// <param name="currentValue"></param>
        /// <returns></returns>
        static bool FindCombination(int targetValue, int currentValue) {
            var key = $"{targetValue}--{currentValue}";
            if (_result.ContainsKey(key)) return _result[key];

            var found = false;
            var need = targetValue - currentValue;
            foreach (var w in _weights) {
                if (w > need) continue;
                else if (w == need) found = true;
                else if (w < need) {
                    if (FindCombination(targetValue, currentValue + w)) found = true;
                }
                if (found) break;
            }
            _result.Add(key, found);
            return found;
        }
    }
}
