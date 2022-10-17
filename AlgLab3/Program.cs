using System.Linq;

namespace AlgLab3
{
    public class Program
    {
        public static void Main()
        {
            LinkedList<int> list1 = new LinkedList<int>();
            LinkedList<int> list2 = new LinkedList<int>();
            for(int i = 0; i < 10; i++)
            {
                list1.Add(i);
            }
            for (int i = 10; i < 20; i++)
            {
                list2.Add(i);
            }
            var l = list1.DivideListByNumber(3);
            Console.WriteLine(list1.Count);
            Console.WriteLine(l.Count);
        }
    }
}