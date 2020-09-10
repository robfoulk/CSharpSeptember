using System;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 1 - Welcome");

            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            Console.WriteLine($"Welcome to class {userName}. Great to have you here.");
        }
    }
}
