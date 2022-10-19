using System.Collections;

namespace AlgLab3
{
    public class Person 
    {
        public string FirstName { get; private set; }
        public string SecondName { get; private set; }
        public string Patronymic { get; private set; }
        public string Sex { get; private set; }
        public int Age { get; private set; }
        public int Salary { get; private set; }

        public Person(string[] arr) 
        {
            this.FirstName = arr[0];
            this.SecondName = arr[1];
            this.Patronymic = arr[2];
            this.Sex = arr[3];
            this.Age = int.Parse(arr[4]);
            this.Salary = int.Parse(arr[5]);
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.SecondName} {this.Patronymic} {this.Sex} {this.Age} {this.Salary}";
        }
    }
    public class Tasks
    {
       private class BinaryNode
       {
            public BinaryNode Right;
            public BinaryNode Left;

            public KeyValuePair<BinaryNode, int> FindDeepestChild()
            {
                var left = new KeyValuePair<BinaryNode, int>(this, 0);
                var right = new KeyValuePair<BinaryNode, int>(this, 0);

                if (Left != null)
                    left = Left.FindDeepestChild();

                if (Right != null)
                    right = Right.FindDeepestChild();

                if (left.Value > right.Value)
                    return new KeyValuePair<BinaryNode, int>(left.Key, left.Value + 1);
                else
                    return new KeyValuePair<BinaryNode, int>(right.Key, right.Value + 1);
            }
       }

        public void QueueTask()
        {
            try
            {
                MyQueue<Person> more = new MyQueue<Person>();
                MyQueue<Person> less = new MyQueue<Person>();
                StreamReader inp = new StreamReader("members.txt"); 
                while (!inp.EndOfStream)
                {
                    Person person = new Person(inp.ReadLine().Split(", "));  
                    if (person.Salary >= 10000) more.Enqueue(person); 
                    else less.Enqueue(person);
                }
                less.Show();
                more.Show();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        public static void ListTask()
        {
            int max = int.MinValue;
            string s = "";
            LinkedList<string> list = new LinkedList<string>() { "cat", "dog", "rat", "parrot", "hamster" };
            LinkedList<string> result = new LinkedList<string>();

            foreach (var i in list)
                max = i.Length > max ? i.Length : max;

            foreach (var i in list)
            {
                s = i;
                if (i.Length < max)
                    for (int j = 0; j < max - i.Length; j++)
                        s = s.Insert(0, "_");
                result.Add(s);
            }
            foreach (var i in result)
                Console.Write($"{i} ");
        }

        public static void StackWork()
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            MyStack<string> passengers = new MyStack<string>();
            MyStack<KeyValuePair<int, int>> seatsIntra = new MyStack<KeyValuePair<int, int>>();
            MyStack<KeyValuePair<int, int>> seatsExtra = new MyStack<KeyValuePair<int, int>>();
            FileWorker file = new FileWorker("stackWork.txt");
            var input = file.FileRead();
            int n = int.Parse(input[0]);
            for (int i = 1; i < n + 1; i++) dictionary.Add(i, int.Parse(input[i]));
            dictionary = dictionary.OrderBy(pair => pair.Value).Reverse().ToDictionary(pair => pair.Key, pair => pair.Value);
            foreach (var pair in dictionary) seatsIntra.Push(pair);
            for (int i = input.Length - 1; i > n; i--) passengers.Push(input[i]);
            Console.WriteLine("HELP ");
            while (!passengers.IsEmpty)
            {
                string passenger = passengers.Pop();
                if (passenger == "0")
                {
                    Console.WriteLine($"Introvert take seat on {seatsIntra.Top().Key} row ");
                    seatsExtra.Push(seatsIntra.Pop());
                }
                if (passenger == "1")
                    Console.WriteLine($"Extravert take seat on {seatsExtra.Pop().Key} row with introvert");
            }
        }
    }
}