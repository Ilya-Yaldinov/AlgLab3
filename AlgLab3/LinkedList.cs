using System.Collections;
using System.Collections.Generic;

namespace AlgLab3
{
    public class LinkedList<T> : IEnumerable<T>
    {
        private Node<T> head;
        private Node<T> tail;
        int count;

        public LinkedList() { }

        public LinkedList(T head)
        {
            Add(head);
        }

        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;

            count++;
        }

        public bool Remove(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int Count { get { return count; } }

        public bool IsEmpty { get { return count == 0; } }
        
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        
        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Reverse()
        {
            Node<T> current = head;
            Node<T> next = null;
            Node<T> previous = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }
            head = previous;
        }

        public void MoveFirstOrLast(int command)
        {
            if (count > 0)
            {
                Node<T> node;
                if (command == 0)
                {
                    Node<T> current = head;
                    Node<T> previous = null;

                    node = new Node<T>(tail.Data);
                    node.Next = head;
                    head = node;
                    if (count == 0)
                        tail = head;

                    while (current != null)
                    {
                        if (current.Data.Equals(tail.Data))
                        {
                            previous.Next = current.Next;
                            if (current.Next == null)
                                tail = previous;
                        }
                        previous = current;
                        current = current.Next;
                    }
                }

                if (command == 1)
                {
                    node = new Node<T>(head.Data);
                    tail.Next = node;
                    tail = node;
                    if (count == 0)
                        head = tail;
                    head = head.Next;
                }
            }  
        }

        public int CountDifferentNumbers()
        {
            Node<T> current = head;
            Dictionary<T,bool> contained = new Dictionary<T,bool>();
            int countNumbers = 0;

            while (current != null)
            {
                if (!contained.ContainsKey(current.Data))
                {
                    contained.Add(current.Data, true);
                    countNumbers++;
                }
                current = current.Next;
            }

            return countNumbers;
        }

        public void DeleteSecondRepeatNumber()
        {
            Node<T> current = head;
            Node<T> previous = null;
            Dictionary<T, bool> contained = new Dictionary<T, bool>();

            while (current != null)
            {
                if (!contained.ContainsKey(current.Data))
                {
                    contained.Add(current.Data, true);
                    previous = current;
                }
                else
                {
                    if (current.Next == null)
                        tail = previous;
                    previous.Next = current.Next;
                    count--;
                }
                current = current.Next;
            }
        }

        public void InsertMyselfAfterNumber(int x)
        {
            Node<T> current = head;
            Node<T> previous = null;
            int countOld = count;
            int countNum = 0;

            while (current != null)
            {
                if (previous != null && previous.Data.Equals(x))
                {
                    Node<T> beforeX = head;
                    int before = countNum;
                    Node<T> newCurrent = new Node<T>(beforeX.Data);
                    for (int i = 0; i < before; i++)
                    {
                        AddAt(beforeX.Data,countNum);
                        countNum++;
                        beforeX = beforeX.Next;
                    }
                    Node<T> afterX = current;
                    newCurrent = new Node<T>(afterX.Data);
                    for (int i = countNum; i < countOld + 3; i++)
                    {
                        AddAt(afterX.Data, i);
                        afterX = afterX.Next;
                    }
                }
                countNum++;
                previous = current;
                current = current.Next;
            }
        }

        public void AddAt(T data, int n)
        {
            Node<T> current = head;
            Node<T> previous = null;
            Node<T> newData = new Node<T>(data);
            int countNum = 0;

            if (head == null)
            {
                head = newData;
                return;
                count++;
            }
            if (n == 0)
            {
                newData.Next = head;
                head = newData;
                count++;
                return;
            }
            if (n == count)
            {
                tail.Next = newData;
                tail = newData;
                count++;
                return;
            }
            while (current != null && countNum < count)
            {
                if (countNum == n)
                {
                    previous.Next = newData;
                    newData.Next = current;
                    count++;
                    return;
                }
                countNum++;
                previous = current;
                current = current.Next;
            }    
        }

        public void AppendList(IEnumerable<T> items)
        {
            if (items.Count() == 0) return;
            foreach (T item in items)
            {
                Add(item);
            }
        }

        public LinkedList<T> DivideListByNumber(T data)
        {
            Node<T> current = head;
            Node<T> item = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return DivideHelper(current);
                }
                    
                current = current.Next;
            }
            return new LinkedList<T>();
        }

        private LinkedList<T> DivideHelper(Node<T> current)
        {
            LinkedList<T> list = new LinkedList<T>();
            Node<T> item = null;
            while (current != null)
            {
                list.Add(current.Data);
                item = current;
                current = current.Next;
                Remove(item.Data);
            }
            return list;
        }

        public void ListAppendOrderBy(IEnumerable<T> items)
        {

        }

        public void InsertFBeforeE(T e,T data)
        {
            Node<T> current = head;
            Node<T> previous = null;
            Node<T> newData = new Node<T>(data);

            while (current != null)
            {
                if (previous != null && current.Data.Equals(e))
                {
                    previous.Next = newData;
                    newData.Next = current;
                    count++;
                    return;
                }
                else if (current.Data.Equals(e))
                {
                    newData.Next = head;
                    head = newData;
                    count++;
                    return;
                }
                previous = current;
                current = current.Next;
            }
        }

        public void DeleteIfEqual(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;

            while (current != null)
            {
                if (previous != null && current.Data.Equals(data))
                {
                    if (current.Next == null)
                        tail = previous;
                    previous.Next = current.Next;
                    count--;
                }
                else if (current.Data.Equals(data))
                {
                    head = current.Next;
                    current = head;
                    count--;
                }
                else
                {
                    previous = current;
                }

                current = current.Next;
            }
        }

        public void InsertInOrder(T data)
        {
            Node<T> current = head;
            Node<T> previous = null;
            Node<T> newData = new Node<T>(data);
            int mData;
            int cNum;
            int pNum = int.MinValue;
            int.TryParse(Convert.ToString(data), out mData);

            while (current != null)
            {
                int.TryParse(Convert.ToString(current.Data), out cNum);
                if (previous != null)
                    int.TryParse(Convert.ToString(previous.Data), out pNum);

                if (previous != null && mData >= pNum && mData <= cNum)
                {
                    previous.Next = newData;
                    newData.Next = current;
                    count++;
                    return;
                }
                else if (mData <= cNum)
                {
                    newData.Next = head;
                    head = newData;
                    count++;
                    return;
                }
                if (previous != null && mData >= pNum && mData >= cNum && current == tail )
                {
                    tail.Next = newData;
                    tail = newData;
                    count++;
                    return;
                }
                previous = current;
                current = current.Next;
            }
        }

        public void DoublingList()
        {
            Node<T> current = head;
            int countOld = count;

            for (int i = 0; i < countOld; i++)
            {
                AddAt(current.Data, i);
                current = current.Next;
            }
        }

        public void ChangeTwoElements(int one, int two)
        {
            Node<T> current = head;
            Node<T> newOne = null;
            Node<T> newTwo = null;
            Node<T> tmp;
            int countOne = 0;
            int countTwo = 0;
            int count = 0;

            while (current != null)
            {
                if (count == one)
                {
                    newOne = current;
                }
                if (count == two)
                {
                    newTwo = current;
                }
                if (newOne != null && newTwo != null)
                {
                    tmp = new Node<T>(newOne.Data);
                    newOne.Data = newTwo.Data;
                    newTwo.Data = tmp.Data;
                    return;
                }
                count++;
                current = current.Next;
            }
        }

        public void Print()
        {
            Node<T> current = head;
            while (current != null)
            {
                Console.Write($"{current.Data} ");
                current = current.Next;
            }
        }
    }
}