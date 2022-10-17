using System.Collections;
using System.Threading;

namespace AlgLab3
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private Node<T> tail = null;
        private Node<T> head = null;

        public int Count { get; private set; } = 0;

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public T Peek()
        {
            if (head == null) return default(T);
            return head.Data; 
        }

        public void Dequeue()
        {
            if (head == null)
            {
                Console.WriteLine("\nQueue Underflow");
                Environment.Exit(0);
            }
            Console.WriteLine($"Removing {head.Data}");
            head = head.Next;
            if (head == null) tail = null;
            Count --;
        }

        public void Show()
        {
            for (Node<T> node = head; node != null; node = node.Next)
                Console.WriteLine(node.Data);
        }

        public void Enqueue(T item)
        {
            Node<T> node = new Node<T>(item);
            Console.WriteLine($"Adding {item}");
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
            Count ++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (!IsEmpty)
            {
                var item = Peek();
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ReadFromFile()
        {
            FileWorker file = new FileWorker("test.txt");
            file.WorkForQueue();
        }
    }
}