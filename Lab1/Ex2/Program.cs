using System;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 2 - Celsius to fahrenheit converter");

            Console.Write("Enter a temperature in celsius: ");
            string userCelsius = Console.ReadLine();
            double celsius = double.Parse(userCelsius);

            double fahrenheit = celsius * (9.0 / 5.0) + 32;
            Console.WriteLine($"Your celsius of {celsius} converts to a fahrenheit value of {fahrenheit}");
        }
    }
}
