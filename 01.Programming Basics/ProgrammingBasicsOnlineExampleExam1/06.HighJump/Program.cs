int highestJump = int.Parse(Console.ReadLine());
int counter = 0;
bool flag = false;

for (int i = highestJump - 30; i <= highestJump; i+=5)
{
    int countFails = 0;
    for (int j = 0; j < 3; j++)
    {
        int jumpInSentimeters = int.Parse(Console.ReadLine());
        counter++;

        if (jumpInSentimeters > i)
        {
            
            break;
        }
        if (jumpInSentimeters <= i)
        {
            countFails++;
            if (countFails < 3)
            {
                continue;
            }
            else if (countFails == 3)
            {
                flag = true;
                break; 
            }
        }
    }
    if (flag)
    {
        
        Console.WriteLine($"Tihomir failed at {i}cm after {counter} jumps.  ");
        break;
    }
}
if (flag != true)
{
    Console.WriteLine($"Tihomir succeeded, he jumped over {highestJump}cm after {counter} jumps.");
}
