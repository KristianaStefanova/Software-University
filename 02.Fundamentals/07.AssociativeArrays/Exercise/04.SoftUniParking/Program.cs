namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, User> licenceMap = new Dictionary<string, User>();

            int countOfVehicles = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfVehicles; i++)
            {
                string[] arguments = Console.ReadLine().Split().ToArray();

                string action = arguments[0];
                string username = arguments[1];

                switch (action)
                {
                    case "register":
                        string licenceNumber = arguments[2];
                        User user = new(username, licenceNumber);

                        if (!licenceMap.ContainsKey(username))
                        {
                            licenceMap.Add(username, user);
                            Console.WriteLine($"{username} registered {licenceNumber} successfully");
                            continue;
                        }
                        Console.WriteLine($"ERROR: already registered with plate number {licenceNumber}");

                        break;
                    case "unregister":
                        if (!licenceMap.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        else
                        {
                            licenceMap.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }

                        break;
                }
            }

            foreach (var pair in licenceMap.Values)
            {
                Console.WriteLine(pair);
            }
        }
    }

    class User
    {
        public User(string username, string licenceNumber)
        {
            Username = username;
            LicenceNumber = licenceNumber;
        }
        public string Username { get; set; }
        public string LicenceNumber { get; set; }

        public override string ToString()
        {
            return $"{Username} => {LicenceNumber}";
        }
    }
}
