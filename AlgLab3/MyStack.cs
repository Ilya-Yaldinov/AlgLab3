using System.Collections;
using System.Threading;

namespace AlgLab3
{
    public class MyStack<T> : IEnumerable<T>
    {
        private Node<T> top = null;

        public int Count { get; private set; } = 0;

        public bool IsEmpty
        {
            get { return Count == 0; }
        } 

        public T Top()
        {
            if (top == null) return default(T);
            return top.Data;
        } 

        public T Pop()
        {
            if (top == null)
            {
                Console.WriteLine("\nStack Underflow");
                Environment.Exit(0);
            }

            T poppableTop = top.Data;
            Console.WriteLine($"Removing {poppableTop}");
            top = top.Next;
            Count--;
            return poppableTop;
        } 

        public void Print()
        {
            for (Node<T> node = top; node != null; node = node.Next)
                Console.WriteLine(node.Data);
        }

        public void Push(T elem)
        {
            Node<T> node = new Node<T>(elem);
            Console.WriteLine($"Pushing {elem}");
            if (top == null)
            {
                top = node;
            }
            else
            {
                node.Next = top;
                top = node;
            }
            Count++;
        } 

        public IEnumerator<T> GetEnumerator()
        {
            while (!IsEmpty)
            {
                var item = Top();
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ReadFromFile()
        {
            FileWorker file = new FileWorker("stackTest.txt");
            file.WorkForStack();
        }
        public void ReadFromFilePref()
        {
            FileWorker file = new FileWorker("stackPrefTest.txt");
            file.WorkForStackPostfix();
        }
    }
}
