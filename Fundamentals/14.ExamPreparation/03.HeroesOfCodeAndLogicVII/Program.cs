using System.Xml.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, List<int>> heroesMap = new Dictionary<string, List<int>>();
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            string[] arguments = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = arguments[0];
            int hitPoints = int.Parse(arguments[1]);
            int manaPoints = int.Parse(arguments[2]);

            heroesMap.Add(name, new List<int> { hitPoints, manaPoints });
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] tokens = command.Split(" - ");
            string action = tokens[0];

            switch (action)
            {
                case "CastSpell":
                    CastSpell(tokens[1], int.Parse(tokens[2]), tokens[3], heroesMap);

                    break;
                case "TakeDamage":
                    TakeDamage(tokens[1], int.Parse(tokens[2]), tokens[3], heroesMap);

                    break;
                case "Recharge":
                    Recharge(tokens[1], int.Parse(tokens[2]), heroesMap);

                    break;
                case "Heal":
                    Heal(tokens[1], int.Parse(tokens[2]), heroesMap);

                    break;
            }
        }

        foreach (KeyValuePair<string, List<int>> hero in heroesMap)
        {
            Console.WriteLine($"{hero.Key}");
            Console.WriteLine($"  HP: {hero.Value[0]}");
            Console.WriteLine($"  MP: {hero.Value[1]}");
        }
    }
    static void Heal(string name, int amount, Dictionary<string, List<int>> heroesMap)
    {
        int originalHitPoints = heroesMap[name][0];

        heroesMap[name][0] += amount;

        if (heroesMap[name][0] > 100)
        {
            heroesMap[name][0] = 100;
        }

        Console.WriteLine($"{name} healed for {heroesMap[name][0] - originalHitPoints} HP!");
    }
    static void Recharge(string name, int amount, Dictionary<string, List<int>> heroesMap)
    {
        int originalHitPoints = heroesMap[name][1];

        heroesMap[name][1] += amount;

        if (heroesMap[name][1] > 200)
        {
            heroesMap[name][1] = 200;
        }

        Console.WriteLine($"{name} recharged for {heroesMap[name][1] - originalHitPoints} MP!");
    }
    static void TakeDamage(string name, int damage, string attacker, Dictionary<string, List<int>> heroesMap)
    {
        heroesMap[name][0] -= damage;

        if (heroesMap[name][0] <= 0)
        {
            heroesMap.Remove(name);
            Console.WriteLine($"{name} has been killed by {attacker}!");
        }
        else
        {
            Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroesMap[name][0]} HP left!");
        }
    }
    static void CastSpell(string name, int neededMana, string spellName, Dictionary<string, List<int>> heroesMap)
    {
        if (heroesMap[name][1] >= neededMana)
        {
            heroesMap[name][1] -= neededMana;
            Console.WriteLine($"{name} has successfully cast {spellName} and now has {heroesMap[name][1]} MP!");
        }
        else
        {
            Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
        }
    }
}

