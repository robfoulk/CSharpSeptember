using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Module03
{

    //Issue Tracking Application

    enum IssueStatus
    {
        Open,
        Closed,
        Pending,
        Resolved
    }


    //Records
    struct Currency
    {

        //public Currency()
        //{
        //    this.Amount = default(decimal);
        //    this.Denomination = default(string);

        //}


        public Currency(decimal amount)
        {
            this.Amount = amount;
            this.Denomination = "USD";

        }

        public Currency(string denom = "USD", decimal amount = 10)
        {
            this.Amount = amount;
            this.Denomination = denom;
        }


        public decimal Amount;
        public string Denomination;

        public override string ToString()
        {
            return $"{Amount:00.00} {Denomination}";
        }

    }

    struct ReadOnlyCurrency
    {

        //public ReadOnlyCurrency()
        //{
        //    this.Amount = default(decimal);
        //    this.Denomination = default(string);

        //}


        public ReadOnlyCurrency(decimal amount)
        {
            this.amount = amount;
            this.denomination = "USD";

        }

        public ReadOnlyCurrency(string denom = "USD", decimal amount = 10)
        {
            this.amount = amount;
            this.denomination = denom;
        }


        private decimal amount; // raw storage
        private string denomination;

        //Readonly Property
        public decimal Amount
        {
            get { return amount; }  //data going out
                                    //set { amount = value;  } //data coming in

        }
        public string Denomination
        {
            get { return denomination; }
            //set { denomination = value; }

        }

        public override string ToString()
        {
            return $"{Amount:00.00} {Denomination}";
        }

    }


    public struct Issue
    {


        private string title;
        public string Title
        {
            get
            {
                //
                if (string.IsNullOrEmpty(title))
                {
                    return "Not yet set";
                }
                return title;
            }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("title");
                if (value.Length < 5) throw new ArgumentException("Title must be at least 5 characters");
                this.title = value;

            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {

            var roc = new ReadOnlyCurrency(100);


            Console.WriteLine(roc.Amount);



            //Demo1();
            var c1 = new Currency();
            c1.Amount = 10;

            c1.Denomination = "USD";
            Console.WriteLine(c1);



            var c2 = new Currency { Amount = 12, Denomination = "CAN" };
            Console.WriteLine(c2);

        }

        private static void Demo1()
        {
            //but, let's say you have a string
            string someStatus = "Open";

            IssueStatus newStatus;
            if (Enum.TryParse(someStatus, out newStatus))
            {
                Console.WriteLine(newStatus);
            }



            var status = IssueStatus.Open;

            // a little bit later

            if (status == IssueStatus.Open)
            {
                Console.WriteLine("Status is open");
            }
            else
            {
                Console.WriteLine("Status is not open");
            }
        }
    }
}
