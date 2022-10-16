using System.Linq;

namespace AlgLab3
{
    public class Program
    {
        public static void Main()
        {
            MyQueue<int> ints = new MyQueue<int>();
            ints.Add(100);
            for(int i = 0; i < 2; i++) ints.Add(i);
            ints.Delete();
            Console.WriteLine(ints.First);
            Console.WriteLine(ints.Count);
        }
    }
}