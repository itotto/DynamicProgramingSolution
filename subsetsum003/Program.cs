using System;
using System.Collections.Generic;

namespace subsetsum003 {
    class Program {

        const int NOT_FOUND = -1;

        /// <summary>
        /// 重り
        /// </summary>
        static List<int> _weights = null;

        /// <summary>
        /// 求めたい値(和)
        /// </summary>
        static int _targetValue = -1;

        static void Main(string[] args) {
            // 件数と目標値を入力
            var conditions = Console.ReadLine().Split(' ');
            var n = Convert.ToInt32(conditions[0]);
            _targetValue = Convert.ToInt32(conditions[1]);

            var depth = NOT_FOUND;

            _weights = new List<int>(n);
            for (var i = 0; i < n; i++) {
                var w = Convert.ToInt32(Console.ReadLine());
                if (w == _targetValue) {
                    depth = 1;
                    break;
                }
                if (w < _targetValue) _weights.Add(w); // xより重いものは排除
            }

            // 見つかってなかった場合のみ
            if (depth == NOT_FOUND) {
                n = _weights.Count;

                // 降順で並べ替え
                _weights.Sort((x, y) => x - y);

                for (var i = n - 1; i >= 0; i--) {
                    var f = FindTargetCombination(_weights[i], i - 1);
                    if (f != NOT_FOUND) {
                        if (depth == NOT_FOUND || f < depth) depth = f + 1;
                    }
                    if (depth == 2) break;
                }
            }

            // 結果の表示
            Console.WriteLine(depth <= 0 ? NOT_FOUND : depth);
        }

        /// <summary>
        /// 計算結果を保存しておく
        /// </summary>
        static Dictionary<string, int> _calculated = new Dictionary<string, int>();

        static int FindTargetCombination(int currentValue, int startPos) {
            var key = $"{currentValue}-{startPos}";
            if (_calculated.ContainsKey(key)) return _calculated[key];

            var depth = NOT_FOUND;
            var need = _targetValue - currentValue;
            for (var i = startPos; i >= 0; i--) {
                var w = _weights[i];
                if (w > need) {
                    continue;
                } else if (w == need) {
                    depth = 1;
                    break;
                } else if (w < need) {
                    if (i > 0) {
                        var d = FindTargetCombination(currentValue + w, i - 1);
                        if (d != NOT_FOUND) {
                            depth = d + 1;
                        }
                    }
                }
            }
            _calculated.Add(key, depth);
            return depth;
        }
    }
}
