namespace p1_stemp1 {
    internal class Program {
        /// <summary>
        /// 部分和問題 C#編（paizaランク B 相当）
        /// </summary>
        /// <remarks>https://paiza.jp/works/mondai/seqdp_problems/seqdp__partialsum_step1/edit?language_uid=c-sharp</remarks>
        static void Main() {
            var conditions = Console.ReadLine()?.Split(' ');
            if (conditions == null) return;
            var n = Convert.ToInt32(conditions[0]);
            var k = Convert.ToInt32(conditions[1]);

            // データ入力
            var data_array = Console.ReadLine()?.Split(' ');
            if (data_array == null) return;
            var data = new int[data_array.Length];
            for (var i = 0; i < data.Length; i++) {
                data[i] = Convert.ToInt32(data_array[i]);
            }

            var result = false;

            for (var i = 0; i < (1 << n); ++i) {
                var sum = 0;
                for (var j = n - 1; 0 <= j; --j) {
                    if (((1 << j) & i) == 0) continue;
                    sum += data[j];
                }
                if (sum == k) {
                    result = true;
                    break;
                }
            }
            Console.WriteLine(result ? "Yes" : "No");
        }
    }
}
