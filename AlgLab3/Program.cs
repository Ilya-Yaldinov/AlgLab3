using System.Linq;

namespace AlgLab3
{
    public class Program
    {
        public static void Main()
        {
            MyQueue<string> queue = new MyQueue<string>();
            queue.ReadFromFile();
        }
    }
}