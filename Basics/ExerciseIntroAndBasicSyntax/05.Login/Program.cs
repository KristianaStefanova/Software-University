/*
Acer
login
go
let me in
recA
*/
class Program
{
    static void Main()
    {
        string username = Console.ReadLine();
        
        string reversed = "";
        

        //char[] charArray = username.ToCharArray();
        //Array.Reverse(charArray);
        //var stringReverse = new string(charArray);

        for (int i = username.Length - 1; i >= 0; i--)
        {
            reversed += username[i];
        }

        int attempt = 4;

        while (attempt > 0)
        {
            string password = Console.ReadLine();
            attempt--;
            if (reversed != password)
            {
                if (attempt == 0)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
            }
            else
            {
                Console.WriteLine($"User {username} logged in.");
                break;
            }

            
        }

   
    }
}


