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

        public void WorkForQueue()
        {
            MyQueue<string> queue = new MyQueue<string>();
            var commands = FileRead();
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
                        Console.WriteLine(queue.Peek());
                        break;
                    case '4':
                        Console.WriteLine(queue.IsEmpty);
                        break;
                    case '5':
                        queue.Show();
                        break;
                }
            }
        }
    }
}