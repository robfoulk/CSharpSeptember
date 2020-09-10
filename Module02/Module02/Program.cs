using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Module02
{
    class Program
    {
        static void Main(string[] args)
        {

            var userAge = GetInput("Enter your age:");


            int age; //normally you cannot pass an uninitialized varaible to a function
            var hasAge = int.TryParse(userAge, out age);

            if (hasAge)
            {
                Console.WriteLine($"You are {age}");
                //AKA
                var message = String.Format("You are {0} as of {1}", age, DateTime.Today);
            }
            else
            {
                Console.WriteLine("You did not enter a valid age");
            }


            var userYearsOfService = GetInput("In Years, how long have you worked for the company? ");
            if(int.TryParse(userYearsOfService, out int years))
            {
                Console.WriteLine("Years worked: " + years);
            }




            ////Naming parameters allows us to skip or reorder parameters
            ////name:value
            //PrintHeader(applicationTitle:"Module 2 Application", includeLines:false);

            ////Console.Write("Enter your name: ");
            ////string name = Console.ReadLine();

            //string name = GetInput("Enter your name: ");

            //Console.WriteLine($"Welcome {name}");


            //string generalInput = GetInput();

            //string city = GetInput("Current City: ", "n/a");



        } //end Main


        static string GetInput()
        {
            string defaultMessage = "Enter Input: ";
            Console.Write(defaultMessage);
            string userInput = Console.ReadLine();

            return userInput;
        }

        static string GetInput(string message)
        {
            Console.Write(message);
            string userInput = Console.ReadLine();

            return userInput;

        }


        static string GetInput(string message, string defaultValue)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write(message);
                string userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    return userInput;
                }
            }
            return defaultValue;

        }

        //ctrl + r, ctrl + r (rename an Identifier)
        //This function had an optional parameter
        static void PrintHeader(string applicationTitle = "Module02", bool includeLines = true)
        {

            if (includeLines)
                Console.WriteLine("-----------------------------------");
            Console.WriteLine($"**** {applicationTitle} ****");
            if (includeLines)
                Console.WriteLine("-----------------------------------");
        }


        //var sum = Add(1,2)
        static int Add(params int[] numbers)
        {
            var total = 0;
            foreach (var n in numbers)
            {
                total += n;
            }
            return total;

        }

        static int Add(int a, int b, int c)
        {
            return a + b + c;

        }

        static int Add(int a, int b)
        {
            return a + b;
        }


    }// end Program
}// end Namespace
