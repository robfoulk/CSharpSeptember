using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Module10_Delegates
{
    class Program
    {
        static void Main(string[] args)
        {

            Action<string> printer = PrintToConsole;
            Func<string, DateTime> timer = GetTime;

        }

        //Action<T>
        //Action<T1,T2>
        //Action<T1,T2,T3>


        //Action<int,double>
        static void PoundNails(int quantity, double force)
        {

        }
        

        //Func<string,bool>
        static bool IsComplete(string fileName)
        {
            return false;

        }


        //Action<int>
        static void Close(int codeOnError)
        {

        }


        //Func<string,string,decimal>
        static decimal GetBalance(string accountNumber, string companyName)
        {
            return 0;
        }

        //Func<int[], string, DateTime>
        static DateTime GetLastAccess(List<int> ip, string fileName)
        {
            return DateTime.Now;
        }


        static void DoComplicatedWork(string[] data, Action<string> logger = null)
        {
            if (logger == null) logger = m => { return;  }; //Not log to any location


            logger("Starting...");





            logger("Comppleted ...");
        }


        delegate void PrintLineHandler(string message);
        delegate void PrintNumberHandler(int number);
        delegate void PrintFloatNumberHandler(float number);

        //Generics
        //delegate void Action<T>(T item);
        delegate TReturn Func<TInput, TReturn>(TInput p1);


        public static DateTime GetTime(string locale)
        {
            return DateTime.Now;
        }

        public static void PrintToNumber(float number)
        {
            Console.WriteLine(number);
        }

        public static void PrintToNumber(int number)
        {
            Console.WriteLine(number);
        }


        //Action<string>

        //Action<string>
        //delegate void D1(string foo);


        public static void PrintToConsole(string message)
        {
            Console.WriteLine(message);
        }

        public static void PrintToDebug(string message)
        {
            System.Diagnostics.Debug.WriteLine(message);
        }

        public static void PrintToFile(string message)
        {
            System.IO.File.WriteAllText(@"C:\class\silly.txt", message);
        }
    }
}
