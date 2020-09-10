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



            try
            {
                //Open DB connection/file/socket
                Console.WriteLine("Fake Connection Open");
                var userInput = GetInput("Gimme a number: ");
                var number = int.Parse(userInput);

                //if (number == 0)
                //{
                //    return; //finally will STILL execute
                //}

                if(number < 0)
                {
                    throw new InvalidOperationException("No negative numbers");
                }


                const int BASE_NUMBER = 100;
                var answer = BASE_NUMBER / number;
                Console.WriteLine($"Your answer is {answer}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("You should not press ctrl+z");
                var n = 0;
                var answer = 1 / n;

            }
            catch (FormatException)
            {
                Console.WriteLine("That is not a whole number");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Whole numbers must be between {int.MinValue} and {int.MaxValue}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("0 is not a valid value");
            }
            catch (Exception ex)
            {
                //Logging and clean up
                Console.WriteLine($"Unknown error: {ex.Message}");

                //Good options for propegating an exception
                //throw new ArgumentException("message", ex);
                //throw;


                //bad option
                //throw ex;
            }
            finally
            {
                Console.WriteLine("Fake Connection closed");
            }



            //Demo2();

            ////Naming parameters allows us to skip or reorder parameters
            ////name:value
            //PrintHeader(applicationTitle:"Module 2 Application", includeLines:false);

            ////Console.Write("Enter your name: ");
            ////string name = Console.ReadLine();

            //string name = GetInput("Enter your name: ");

            //Console.WriteLine($"Welcome {name}");


            //string generalInput = GetInput();

            //string city = GetInput("Current City: ", "n/a");

            //Demo3();
        } //end Main

        private static void Demo3()
        {
            int someNumber = 0;
            SetDefaultInt(ref someNumber);

            Console.WriteLine(someNumber);
        }

        private static void Demo2()
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
            if (int.TryParse(userYearsOfService, out int years))
            {
                Console.WriteLine("Years worked: " + years);
            }
        }

        static bool FakeOut(out int n)
        {
            n = 0;

            return true;
        }

        //Fake Ref parameter for demo
        static void SetDefaultInt(ref int number)
        {
            if (number == 0)
            {
                number = 100;
            }
        }

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



        //var sum = Add(1,2,3)
        static int Add(params int[] numbers)
        {
            var total = 0;
            foreach (var n in numbers)
            {
                total += n;
            }
            return total;

        }


        //var sum = Add(1,2,3)
        static int Add(int a, int b, int c)
        {
            return a + b + c;

        }

        //var sum = Add(1,2)
        static int Add(int a, int b)
        {
            return a + b;
        }


    }// end Program
}// end Namespace
