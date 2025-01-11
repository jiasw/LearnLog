namespace HelloAlgo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }


        static List<string[]> Alllist(List<string> ints)
        {
           List<string[]> ints1 = new List<string[]>();


            bool[] arrselected = new bool[ints.Count];







            return ints1;
        }


        
        static List<string[]> Backtracking(string[] arrselect, string[] result,int index, List<string[]>)
        {
            if (arrselect.Length==1)
            {
                result[index] = arrselect[0];
                return result;
            }
            for (int i = 0; i < arrselect.Length; i++)
            {
                string curr = arrselect[i];
                result

            }
            

        }


    }
}
