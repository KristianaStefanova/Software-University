using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToList();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] arguments = command.Split().ToArray();
            int number;
            int index;
            bool isValid = false;

            switch (arguments[0])
            {
                case "Add":
                    number = int.Parse(arguments[1]);
                    numbers.Add(number);
                    break;
                case "Insert":
                    number = int.Parse(arguments[1]);
                    index = int.Parse(arguments[2]);
                    isValid = CheckIndex(index, numbers);

                    if (isValid)
                    {
                        numbers.Insert(index, number);
                    }

                    break;
                case "Remove":
                    index = int.Parse(arguments[1]);
                    isValid = CheckIndex(index, numbers);

                    if (isValid)
                    {
                        numbers.RemoveAt(index);
                    }

                    break;
                case "Shift":
                    if (arguments[1] == "left")
                    {
                        /*
                         count %= numbers.Count;

                           if (direction == "left")
                           {
                               List<int> shiftedPart = numbers.GetRange(0, count);
                               numbers.RemoveRange(0, count);
                               numbers.InsertRange(numbers.Count, shiftedPart);
                         
                         */

                        int countLeft = int.Parse(arguments[2]);

                        for (int i = 0; i < countLeft; i++)
                        {
                            int indexShift = 0;
                            int copyLastIndex = numbers[numbers.Count - 1];
                            numbers[numbers.Count - 1] = numbers[indexShift];


                            for (int j = 1; j < numbers.Count; j++)
                            {
                                numbers[indexShift] = numbers[j];
                                indexShift++;
                            }

                            numbers[numbers.Count - 2] = copyLastIndex;

                        }
                    }
                    else if (arguments[1] == "right")
                    {
                        int countRight = int.Parse(arguments[2]);
                        countRight %= numbers.Count;

                        List<int> shiftedPart = numbers.GetRange(numbers.Count - countRight, countRight);
                        numbers.RemoveRange(numbers.Count - countRight, countRight);
                        numbers.InsertRange(0, shiftedPart);

                    }
            break;
            }

        }
        
        Console.WriteLine(string.Join(" ", numbers));
        static bool CheckIndex(int index, List<int> numbersStr)
        {
            if (index < 0 || index > numbersStr.Count - 1)
            {
                Console.WriteLine("Invalid index");
                return false;
            }
            return true;
        }

    }

}



