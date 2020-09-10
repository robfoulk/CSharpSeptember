using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 2 - Celsius to Farenheit converter");

            Console.Write("Enter a temperature in celsius: ");
            string userCelsius = Console.ReadLine();
            double celsius = double.Parse(userCelsius);

            double farenheit = celsius * (9.0 / 5.0) + 32;
            Console.WriteLine($"Your celsius of {celsius} converts to a farenhiet value of {farenheit}");

        }
    }
}
