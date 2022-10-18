using System.Diagnostics;
using System.Text;

namespace AlgLab3
{
    public class FileWorker
    {
        private string path;
        public FileWorker(string path)
        {
            this.path = path;
        }

        public string[] FileRead()
        {
            return File.ReadAllText(path).Split(" ");
        }

        public void WorkForQueue(ArraySegment<string> commands)
        {
            MyQueue<string> queue = new MyQueue<string>();
            foreach (string command in commands)
            {
                switch (command[0])
                {
                    case '1':
                        string[] items = command.Split(",");
                        queue.Enqueue(items[1]);
                        break;
                    case '2':
                        queue.Dequeue();
                        break;
                    case '3':
                        var peek = queue.Peek();
                        Console.WriteLine(peek);
                        break;
                    case '4':
                        bool isEmpty = queue.IsEmpty;
                        Console.WriteLine(isEmpty);
                        break;
                    case '5':
                        queue.Show();
                        break;
                }
            }
        }

        public void TimeCheckForMyQueue()
        {
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();
            Stopwatch sw = Stopwatch.StartNew();
            string[] file = FileRead();
            for (int i = 0; i < file.Length; i += 10)
            {
                WorkForQueue(new ArraySegment<string>(file, 1, i));
                sb.Append($"{i};{(Process.GetCurrentProcess().WorkingSet64)}");
                list.Add(sb.ToString());
                sb.Clear();
            }
            /*for (int i = 0; i < file.Length; i += 10)
            {
                sw.Start();
                WorkForQueue(new ArraySegment<string>(file, 1, i));
                sb.Append($"{i};{sw.Elapsed.TotalMilliseconds}");
                sw.Stop();
                list.Add(sb.ToString());
                sb.Clear();
            }*/
            File.WriteAllLines("test4(memory).csv", list);
        }
    }
}