internal class Program
{
    static void Main(string[] args)
    {
        List<string> phones = Console.ReadLine()
            .Split(", ")
            .ToList();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] arguments = command.Split(" - ");

            switch (arguments[0])
            {
                case "Add":
                    Add(phones, arguments[1]);
                    break;

                case "Remove":
                    Remove(phones, arguments[1]);
                    break;

                case "Bonus phone":
                    BonusPhone(phones, arguments[1]);
                    break;

                case "Last":
                    Last(phones, arguments[1]);
                    break;
            }
        }

        Console.WriteLine(string.Join(", ", phones));
    }

    static void Last(List<string> phones, string phone)
    {
        if (phones.Contains(phone))
        {
            string copyPhone = phone;
            phones.Remove(phone);
            phones.Add(phone);
        }
    }

    static void BonusPhone(List<string> phones, string elements)
    {
        List<string> oldAndNewPhone = elements.Split(":").ToList();

        if (phones.Contains(oldAndNewPhone[0]))
        {
            int index = phones.IndexOf(oldAndNewPhone[0]);
            phones.Insert(index + 1, oldAndNewPhone[1]);
        }
    }

    static void Remove(List<string> phones, string phone)
    {
        if (phones.Contains(phone))
        {
            phones.Remove(phone);
        }
    }
    static void Add(List<string> phones, string phone)
    {
        if (phones.Contains(phone))
        {
            return;
        }

        phones.Add(phone);
    }
}

