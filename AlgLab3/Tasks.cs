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
        public void QueueTask()
        {
            try
            {
                Queue more = new Queue();
                Queue less = new Queue();
                StreamReader inp = new StreamReader("members.txt"); 
                while (!inp.EndOfStream)
                {
                    Person person = new Person(inp.ReadLine().Split(", "));  
                    if (person.Salary >= 10000) more.Enqueue(person); 
                    else less.Enqueue(person);
                }

                foreach (var i in less)
                {
                    Console.WriteLine(i);
                }

                foreach (var i in more)
                {
                    Console.WriteLine(i);
                }

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
    }
}