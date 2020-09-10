using System;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 26;
            int min = 0;
            int tries = 0;

            while (true)
            {
                int guess = (max + min) / 2;
                Console.Write($"Is {guess} your number? (y,h,l): ");
                string answer = Console.ReadLine();

                if (answer == "h")
                {
                    max = guess;
                    tries++;
                }
                else if (answer == "l")
                {
                    min = guess;
                    tries++;
                }
                else if (answer == "y")
                {
                    Console.WriteLine($"I got it in {tries} tries!");
                    break; //exit the loop
                }
                else
                {
                    Console.WriteLine($"Please enter y, h or l");
                }
            }
        }
    }
}
