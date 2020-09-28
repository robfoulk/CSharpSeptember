using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module04_Class
{
    class Program
    {
        static void Main(string[] args)
        {

            var myHouse = new Mansion();
            myHouse.KitchenLights = true;


            var kidsHouse = new Mansion();

            kidsHouse = null;


            //Static Members
            Console.WriteLine("Hey!");
            int bigNumber = int.MaxValue;
            int number = int.Parse("120");


        }
    }

    enum IssueStatus
    {
        Open,
        Closed,
        Pending,
        Resolved
    }

    class Mansion
    {
        ///members here
        public bool KitchenLights { get; internal set; }
    }


    //Blueprint for creating a 'thing'
    public class Issue
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
}
