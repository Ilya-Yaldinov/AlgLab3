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
    }
}