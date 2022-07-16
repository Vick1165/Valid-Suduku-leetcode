namespace Merge_Two_Sorted_Lists
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var nums = new char[][]
            {
                new [] {'5','3','5','.','7','.','.','.','.'},
new [] {'6','.','.','1','9','5','.','.','.'},
new [] {'.','9','8','.','.','.','.','6','.'},
new [] {'8','.','.','.','6','.','.','.','3'},
new [] {'4','.','.','8','.','3','.','.','1'},
new [] {'7','.','.','.','2','.','.','.','6'},
new [] {'.','6','.','.','.','.','2','8','.'},
new [] {'.','.','.','4','1','9','.','.','5'},
new [] {'.','.','.','.','8','.','.','7','9'},
            };
            int k = 2;
            var op = IsValidSudoku(nums);
            Console.WriteLine(op);
        }

        public static bool IsValidSudoku(char[][] board)
        {
            if (board == null || board.Length > 9)
            {
                return false;
            }

            for (int i = 0; i < board.Length; i++)
            {
                var charT = new char[9];
                for (int j = 0; j < board.Length; j++)
                {
                    if (board[i][j] != '.')
                    {
                        charT[board[i][j] - '0']++;
                    }

                }



                if (charT.All(a => a.Equals('1') || a.Equals('0')))
                {
                    return false;
                }
            }

            return false;
        }

        public static int[] ProductExceptSelf(int[] nums)
        {
            var size = nums.Length;
            if (nums == null || size < 2)
            {
                return new int[0];
            }

            var lp = new int[size];
            var rp = new int[size];
            var op = new int[size];
            var p = 1;

            for (int i = 0; i < size; i++)
            {
                lp[i] = p;
                p = p * nums[i];
            }

            p = 1;
            for (int i = size - 1; i >= 0; i--)
            {
                rp[i] = p;
                p = p * nums[i];
            }

            for (int i = 0; i < size; i++)
            {
                op[i] = lp[i] * rp[i];
            }
            return op;
        }

        public static int[] TopKFrequent(int[] nums, int k)
        {
            var dict = new Dictionary<int, int>();

            foreach (var item in nums)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }
            return dict.OrderByDescending(kvp => kvp.Value).Select(kvp => kvp.Key).Take(k).ToArray();

            //2. build priority queue based on highest to lowest frequency
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            foreach (var key in dict.Keys)
            {
                pq.Enqueue(key, dict[key]);
            }

            var result = new int[k];
            for (var i = 0; i < k; i++)
            {
                result[i] = pq.Dequeue();
            }
            return result;
        }
    }
}