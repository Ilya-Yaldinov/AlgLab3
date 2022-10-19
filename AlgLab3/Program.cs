using System.Linq;

namespace AlgLab3
{
    public class Program
    {
        public static void Main()
        {
            FileWorker fileWorker = new FileWorker("testStack4.txt");
            fileWorker.TimeCheck("testStack4(memory)");
        }
    }
}