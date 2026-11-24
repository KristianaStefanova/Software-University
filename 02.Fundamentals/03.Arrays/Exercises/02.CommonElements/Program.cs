using System.Threading.Channels;

namespace _02.CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split();
            string[] secondArray = Console.ReadLine().Split();

            for (int j = 0; j < secondArray.Length; j++)
            {
                for (int i = 0; i < firstArray.Length; i++)
                {
                    if (firstArray[i] == secondArray[j])
                    {
                        Console.Write($"{firstArray[i]} ");
                        break;
                    }
                }
            }
        }
    }
}
