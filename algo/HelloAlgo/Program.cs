namespace HelloAlgo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6 };
            List<List<int>> alllist = PermutationsI(nums);
            foreach (List<int> item in alllist)
            {
                Console.WriteLine(string.Join("-", item));
            }
            Console.WriteLine("全排列结束");
            Console.ReadKey();

        }


        static List<List<int>> PermutationsI(int[] nums)
        {
            List<List<int>> res = [];
            Backtracking([], nums, new bool[nums.Length], res);
            return res;
        }



        static void Backtracking(List<int> state, int[] choices, bool[] selected,List<List<int>> res )
        {
            if (state.Count==choices.Length)
            {
                res.Add(new List<int>(state));
                return;
            }

            for (int i = 0; i < choices.Length; i++)
            {
                int choice = choices[i];

                if (!selected[i])
                {
                    selected[i] = true;
                    state.Add(choice);
                    Backtracking(state, choices, selected, res);
                    selected[i] = false;
                    state.RemoveAt(state.Count - 1);
                }
            }

        }


    }
}
