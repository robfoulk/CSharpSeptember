using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Principal;
using Microsoft.Win32;

namespace Module05
{
    class Program
    {
        static void Main(string[] args)
        {

            var issues = Issue.GetIssues();
            foreach (var issue in issues)
            {
                PrintIssue(issue);
            }



        }

        private static void PrintIssue(Issue issue)
        {
            Console.WriteLine(issue.Summarize());
            Console.WriteLine();
        }
    }

    class Issue
    {



        //prop<tab><tab>
        public int Id { get; set; }
        public string Title { get; set; }
        public int Severity { get; set; }
        public string Status { get; set; }

        public virtual string Summarize() //virtual: Inhertied classes MAY change this behavior
        {
            return $"Issue ID: {Id}\n" +
                $"Title: {Title}\n" +
                $"Severity: {Severity}\n" +
                $"Status: {Status}\n";

        }


        public static IEnumerable<Issue> GetIssues()
        {
            return new List<Issue> {
                new Issue{Id=1, Title="No fake data creation", Severity=3, Status="open"},
                new Issue{Id=2, Title="doughnuts are not free in the breakroom", Severity=1, Status="open"},
                new Issue{Id=3, Title="Other issues", Severity=5, Status="open"},
                new Issue{Id=4, Title="Code doesn't write itself", Severity=2, Status="open"},
                new Issue{Id=5, Title="No fake data creation 2", Severity=4, Status="open"},
                new SoftwareBug{Id=6, Title="Quicken show no money in account", Application="Quicken", Status="Open", ErrorInformation="none", Severity=5},
            };
        }

    }

    class SoftwareBug : Issue
    {



        public string Application { get; set; }
        public string ErrorInformation { get; set; }

        public override string Summarize()
        {
            var initialContent = base.Summarize();
            return initialContent + $"Application: {Application}\n" +
                $"Error: {ErrorInformation}";

        }

    }





    // Custom Lists

    class Game
    {

        public void Play()
        {
            Hand hand1 = new Hand();
            if (hand1.HasPair)
            {

            }
        }

    }

    class Hand : List<Card>
    {
        public bool HasPair
        {
            get
            {
                return true; //Actual code would go here
            }
        }
    }


    class Card
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
    }
}
