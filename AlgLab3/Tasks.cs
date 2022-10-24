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

    public class Song
    {
        public string Name { get; private set; }
        public string Album { get; private set; }
        public string Genre { get; private set; }
        public string Author { get; private set; }

        public Song(string[] arr)
        {
            this.Name   = arr[0];
            this.Author = arr[1];
            this.Album  = arr[2];
            this.Genre  = arr[3];
        }

        public override string ToString()
        {
            return $"Название:{this.Name.PadRight(25)} Исполнитель:{this.Author.PadRight(25)} Альбом:{this.Album.PadRight(35)} Жанр:{this.Genre}";
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

        public static void ListTask(string genre)
        {
            LinkedList<Song> playlist = FileWorker.FileRead("Playlist.txt");
            LinkedList<Song> sortedPlaylist = new LinkedList<Song>();

            foreach (var i in playlist)
                Console.WriteLine($"{i}");

            foreach (var i in playlist)
                if (i.Genre == genre)
                    sortedPlaylist.Add(i);

            for (int j = 0; j < sortedPlaylist.Count; j++)
            {
                for (int song = 0; song < sortedPlaylist.Count - 1; song++)
                {
                    bool nameHigher = true;
                    int minLength = Math.Min(sortedPlaylist.ElementAt(song).Name.Length, sortedPlaylist.ElementAt(song + 1).Name.Length);
                    int i = 0;
                    while (nameHigher)
                    {
                        if (sortedPlaylist.ElementAt(song).Name[i] > sortedPlaylist.ElementAt(song + 1).Name[i])
                        {
                            sortedPlaylist.ChangeTwoElements(song, song + 1);
                            nameHigher = false;
                            i = 0;
                        }
                        if (sortedPlaylist.ElementAt(song).Name[i] < sortedPlaylist.ElementAt(song + 1).Name[i])
                        {
                            nameHigher = false;
                            i = 0;
                        }
                        i++;
                    }
                }
            }

            Console.WriteLine($"\nРезультат поиска с фильтром '{genre}'");
            foreach (var i in sortedPlaylist)
                Console.WriteLine($"{i}");
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