using System.Collections;

namespace AlgLab3
{
    public class MyQueue<T> : IEnumerable<T>
    {
        private Node<T> tail = null;
        private Node<T> head = null;
        public int Count { get; private set; } = 0;

        public T First
        {
            get { return head.Data; }
        }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public void Delete()
        {
            if (head == null)
            {
                Console.WriteLine("\nQueue Underflow");
                Environment.Exit(0);
            }
            Console.WriteLine($"Removing {head.Data}");
            head = head.Next;
            if (head == null)
            {
                tail = null;
            }
            Count --;
        }

        public void Add(T item)
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
                var item = First;
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}