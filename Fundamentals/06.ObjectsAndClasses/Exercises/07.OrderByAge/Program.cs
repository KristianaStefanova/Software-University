namespace _07.OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<People> people = new List<People>();

            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split();
                string name = arguments[0];
                string id = arguments[1];
                int age = int.Parse(arguments[2]);

                People person = new People(name, id, age);

                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Id == id)
                    {
                        people[i].Name = name;
                        people[i].Age = age;
                    }
                }

                people.Add(person);
            }

            List<People> orderedPeople = people
                .OrderBy(person => person.Age)
                .ToList();

            foreach (People person in orderedPeople)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }

    class People
    {
        public People(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;

        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
}
