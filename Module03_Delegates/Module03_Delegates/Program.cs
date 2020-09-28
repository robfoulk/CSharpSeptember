using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Module03_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {


            var data = new string[] { "Name 1", "Name 2", "Name 3", "nane 4" };


            Console.WriteLine("Version 1 - Manual Delegate");
            PrintItemHandler handler = new PrintItemHandler(PrintToScreen);
            DoWork(data, handler);

            Console.WriteLine();

            Console.WriteLine("Version 2 - Implied Delegate");
            DoWork(data, PrintToScreen);


            Console.WriteLine();
            Console.WriteLine("Version 3 - Multicast Delegate");

            PrintItemHandler handler2 = new PrintItemHandler(PrintToScreen);
            handler2 += PrintToDebugger;
            handler2 += PrintToLogFile;
            DoWork(data, handler2);


            //What if we could build function "on the fly"
            //instead of external ones

            //Anonymous Function (least important, ugliest syntax)
            PrintItemHandler handler3 = delegate (string msg) {
                Console.WriteLine(msg);
            };

            //Labmda Expression
            PrintItemHandler handler4 = msg => Console.WriteLine(msg);


        }

        static string FooFunction()
        {
            return DateTime.UtcNow.ToString();
        }


        //Define a Function's signature - Delegate (strongly typed function pointer)
        delegate void PrintItemHandler(string message); //The kind of function we need



        private static void DoWork(string[] data, PrintItemHandler func = null)
        {
            
            foreach(string item in data)
            {
                if (func == null)
                {
                    //Default behavior
                    Console.WriteLine("Default: " + item);
                }
                else
                {
                    func(item); //Invoking the delegate, just like a function
                }
            }
        }

        private static void PrintToScreen(string message)
        {
            Console.WriteLine(message);
        }

        private static void PrintToDebugger(string message)
        {
            Debug.WriteLine(message);
        }

        private static void PrintToLogFile(string message)
        {
            const string fileName = "c:\\class\\mod03.log.txt";
            System.IO.File.AppendAllText(fileName, message);
        }


    }
}
