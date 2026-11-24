namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            string command;

            while ((command = Console.ReadLine()) != "stop")
            {
                if (!resources.ContainsKey(command))
                {
                    resources.Add(command, 0);
                }

                resources[command] += int.Parse(Console.ReadLine());
            }

            foreach ((string resource, int count) in resources)
            {
                Console.WriteLine($"{resource} -> {count}");
            }
        }
    }
}
