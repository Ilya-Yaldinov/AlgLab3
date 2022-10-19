using System.Collections.Generic;
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

        public void TimeCheck(string fileName)
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
                WorkForStack(new ArraySegment<string>(file, 1, i));
                sb.Append($"{i};{sw.Elapsed.TotalMilliseconds}");
                sw.Stop();
                list.Add(sb.ToString());
                sb.Clear();
            }*/
            File.WriteAllLines($"{fileName}.csv", list);
        }

        public void WorkForStack()
        {
            MyStack<string> stack = new MyStack<string>();
            var commands = FileRead();
            foreach (string command in commands)
            {
                switch (command[0])
                {
                    case '1':
                        string[] items = command.Split(",");
                        stack.Push(items[1]);
                        break;
                    case '2':
                        stack.Pop();
                        break;
                    case '3':
                        var top = stack.Top();
                        Console.WriteLine(top);
                        break;
                    case '4':
                        bool isEmpty = stack.IsEmpty;
                        Console.WriteLine(isEmpty);
                        break;
                    case '5':
                        stack.Print();
                        break;
                }
            }
        }

        public void WorkForStackPostfix()
        {
            MyStack<string> stack = new MyStack<string>();
            var commands = FileRead();
            double x;
            double y;
            double result;
            foreach (string command in commands)
            {
                switch (command)
                {
                    case "+":
                        x = double.Parse(stack.Pop());
                        y = double.Parse(stack.Pop());
                        result = x + y;
                        Console.WriteLine($"{x} + {y} = {result}");
                        stack.Push(result.ToString());
                        break;
                    case "-":
                        x = double.Parse(stack.Pop());
                        y = double.Parse(stack.Pop());
                        result = x - y;
                        Console.WriteLine($"{x} - {y} = {result}");
                        stack.Push(result.ToString());
                        break;
                    case "*":
                        x = double.Parse(stack.Pop());
                        y = double.Parse(stack.Pop());
                        result = x * y;
                        Console.WriteLine($"{x} * {y} = {result}");
                        stack.Push(result.ToString());
                        break;
                    case "/":
                        x = double.Parse(stack.Pop());
                        y = double.Parse(stack.Pop());
                        result = x / y;
                        Console.WriteLine($"{x} / {y} = {result}");
                        stack.Push(result.ToString());
                        break;
                    case "^":
                        x = double.Parse(stack.Pop());
                        y = double.Parse(stack.Pop());
                        result = Math.Pow(x, y);
                        Console.WriteLine($"{x} ^ {y} = {result}");
                        stack.Push(result.ToString());
                        break;
                    case "ln":
                        x = double.Parse(stack.Pop());
                        result = Math.Log(x);
                        Console.WriteLine($"ln({x}) = {result}");
                        stack.Push(result.ToString());
                        break;
                    case "cos":
                        x = double.Parse(stack.Pop());
                        result = Math.Cos(x);
                        Console.WriteLine($"cos({x}) = {result}");
                        stack.Push(result.ToString());
                        break;
                    case "sin":
                        x = double.Parse(stack.Pop());
                        result = Math.Sin(x);
                        Console.WriteLine($"sin({x}) = {result}");
                        stack.Push(result.ToString());
                        break;
                    case "sqrt":
                        x = double.Parse(stack.Pop());
                        result = Math.Sqrt(x);
                        Console.WriteLine($"sqrt({x}) = {result}");
                        stack.Push(result.ToString());
                        break;
                    default:
                        stack.Push(command);
                        break;
                }
            }
            Console.WriteLine($"Result is {stack.Pop()}");
        }
    }
}