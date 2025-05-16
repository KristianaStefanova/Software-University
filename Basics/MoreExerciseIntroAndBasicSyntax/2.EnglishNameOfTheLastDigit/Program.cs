namespace _2.EnglishNameOfTheLastDigit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lastDigit = number % 10;
            string strNumber = string.Empty;

            switch (lastDigit)
            {
                case 1:
                    strNumber = "one";
                    break;
                case 2:
                    strNumber = "two";
                    break;
                case 3:
                    strNumber = "three";
                    break;
                case 4:
                    strNumber = "four";
                    break;
                case 5:
                    strNumber = "five";
                    break;
                case 6:
                    strNumber = "six";
                    break;
                case 7:
                    strNumber = "seven";
                    break;
                case 8:
                    strNumber = "eight";
                    break;
                case 9:
                    strNumber = "nine";
                    break;
                case 0:
                    strNumber = "zero";
                    break;
            }
            Console.WriteLine(strNumber);
        }
    }
}
