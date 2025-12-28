using System;
using System.Reflection;
using System.Threading.Channels;


namespace _11.ArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] arguments = command.Split().ToArray();

                switch (arguments[0])
                {
                    case "exchange":
                        {
                            int index = int.Parse(arguments[1]);
                            numbers = ExchangeNumbers(numbers, index);
                            break;
                        }
                    case "max":
                        {
                            string type = arguments[1];
                            PrintMaxIndex(numbers, type);
                            break;
                        }
                    case "min":
                        {
                            string type = arguments[1];
                            PrintMinIndex(numbers, type);
                            break;
                        }
                    case "first":
                        {
                            int firstCount = int.Parse(arguments[1]);
                            string firstType = arguments[2];
                            PrintFirstTypeNumbers(numbers, firstCount, firstType);
                            break;
                        }
                    case "last":
                        {
                            int lastCount = int.Parse(arguments[1]);
                            string lastType = arguments[2];
                            PrintLastTypeNumbers(numbers,lastCount, lastType);
                            break;
                        }
                }
            }

            Console.WriteLine($"[{string.Join(", ",numbers)}]");
        }

        static void PrintLastTypeNumbers(int[] array, int count, string type)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            string lastElement = "";

            for (int i = array.Length - 1; i >= 0 ; i--)
            {
                int number = array[i];

                if (IsValidType(type, number))
                {
                    lastElement = $"{number}, " + lastElement;

                    count--;

                    if (count == 0)
                    {
                        break;
                    }
                }
            }

            lastElement = lastElement.Trim(' ', ',');
            Console.WriteLine($"[{lastElement}]");
        }

        static void PrintFirstTypeNumbers(int[] array, int count, string type)
        {
            if (count > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            string firstElement = "";

            for (int i = 0; i < array.Length; i++)
            {
                int number = array[i];

                if (IsValidType(type, number))
                {
                    firstElement += $"{number}, ";
                    count--;

                    if (count == 0)
                    {
                        break;
                    }
                }
            }

            firstElement = firstElement.Trim(' ', ',');
            Console.WriteLine($"[{firstElement}]");
        }


        static void PrintMinIndex(int[] array, string type)
        {
            int minIndex = -1;
            int minNumber = int.MaxValue;

            for (int i = 0; i < array.Length; i++)
            {
                int number = array[i];

                if (IsValidType(type, number))
                {
                    if (number <= minNumber)
                    {
                        minNumber = number;
                        minIndex = i;
                    }
                }
            }

            if (minIndex == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(minIndex);
            }
        }

        static void PrintMaxIndex(int[] array, string type)
        {
            int maxIndex = -1;
            int maxNumber = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                int number = array[i];

                if (IsValidType(type, number))
                {
                    if (number >= maxNumber)
                    {
                        maxNumber = number;
                        maxIndex = i;
                    }
                }
            }

            if (maxIndex == -1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(maxIndex);
            }
        }

        static bool IsValidType(string type, int number)
        {
            return (type == "even" && number % 2 == 0) ||
                   (type == "odd" && number % 2 != 0);
        }

        static int[] ExchangeNumbers(int[] array, int index)
        {
            int[] reversedArray = new int[array.Length];
            int indexReversed = 0;

            if (!IsValidIndex(array, index))
            {
                Console.WriteLine("Invalid index");
                return array;
            }

            for (int i = index + 1; i < array.Length; i++)
            {
                reversedArray[indexReversed] = array[i];
                indexReversed++;
            }

            for (int i = 0; i <= index; i++)
            {
                reversedArray[indexReversed] = array[i];
                indexReversed++;
            }

            return reversedArray;
        }
        static bool IsValidIndex(int[] array, int index)
        {
            return index >= 0 && index <= array.Length - 1;
        }
    }
}
