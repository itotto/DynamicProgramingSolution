using System;
using System.Collections.Generic;

namespace subsetsum003 {
    /// <summary>
    /// 部分和問題 3
    /// </summary>
    /// <remarks>https://paiza.jp/works/mondai/dp_primer/dp_primer_partial_sums_step2/edit?language_uid=c-sharp</remarks>
    class Program {
        /// <summary>
        /// 見つからない場合の値
        /// </summary>
        const int NOT_FOUND = -1;

        /// <summary>
        /// 重り
        /// </summary>
        static List<int> _weights = null;

        static void Main() {
            // 件数と目標値を入力
            var conditions = Console.ReadLine().Split(' ');
            var n = Convert.ToInt32(conditions[0]);
            var targetValue = Convert.ToInt32(conditions[1]);

            var depth = NOT_FOUND;

            _weights = new List<int>(n);
            for (var i = 0; i < n; i++) {
                var w = Convert.ToInt32(Console.ReadLine());
                if (w == targetValue) {
                    depth = 1;
                    break;
                }
                if (w < targetValue) _weights.Add(w); // xより重いものは排除
            }

            // 見つかってなかった場合のみ
            if (depth == NOT_FOUND) {
                n = _weights.Count;

                // 降順で並べ替え
                _weights.Sort((x, y) => x - y);

                // 深さを計算
                depth = FindTargetCombination(targetValue, 0, n - 1);
            }

            // 結果の表示
            Console.WriteLine(depth <= 0 ? NOT_FOUND : depth);
        }

        /// <summary>
        /// 計算結果を保存しておく(キャッシュ)
        /// </summary>
        static Dictionary<string, int> _calculated = new Dictionary<string, int>();

        /// <summary>
        /// 組み合わせを見つける
        /// </summary>
        /// <param name="targetValue">最終的に欲しい値</param>
        /// <param name="currentValue">いまの値</param>
        /// <param name="startPos">確認する場所</param>
        /// <returns></returns>
        static int FindTargetCombination(int targetValue, int currentValue, int startPos) {
            var key = $"{currentValue}-{startPos}";
            if (_calculated.ContainsKey(key)) return _calculated[key];

            var depth = NOT_FOUND;
            var need = targetValue - currentValue;
            for (var i = startPos; i >= 0; i--) {
                var w = _weights[i];
                if (w > need) {
                    continue;
                } else if (w == need) {
                    depth = 1;
                    break;
                } else if (w < need) {
                    if (i > 0) {
                        var d = FindTargetCombination(targetValue, currentValue + w, i - 1);
                        if (d != NOT_FOUND) {
                            if (depth == NOT_FOUND || d < depth) depth = d + 1;
                        }
                    }
                }
            }
            _calculated.Add(key, depth);
            return depth;
        }
    }
}
