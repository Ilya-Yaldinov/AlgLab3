using System.Linq;

namespace AlgLab3
{
    public class Program
    {
        public static void Main()
        {
            FileWorker fileWorker = new FileWorker("test4.txt");
            fileWorker.TimeCheckForMyQueue("test4");
        }
    }
}