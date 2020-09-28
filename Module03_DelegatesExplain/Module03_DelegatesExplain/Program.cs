using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Module03_DelegatesExplain
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo1();
            Demo2();

        }

        private static void Demo2()
        {
            //Linq Example
            //Language Integrated Query
            //IEnumerable<Process> - a "bunch" of Processes that we can loop thru
            IEnumerable<Process> procs = Process.GetProcesses();

            //procs = procs.Where(OnlyBigProcesses);
            procs = procs.Where(p => p.WorkingSet64 > 100_000_000);
            procs = procs.OrderBy(p => p.ProcessName);


            foreach(var proc in procs)
            {
                Console.WriteLine($"{proc.ProcessName} - {proc.WorkingSet64}");
            }


        }

        //private static bool OnlyBigProcesses(Process proc)
        //{
        //    return proc.WorkingSet64 >= 100_000_000;
        //}

        private static void Demo1()
        {
            //Watch a folder for changes
            const string folder = @"c:\class\watched\";
            var watcher = new System.IO.FileSystemWatcher();
            watcher.Path = folder;
            watcher.EnableRaisingEvents = true;

            watcher.Created += (sender, args) => Console.WriteLine(args.FullPath + " was was created.");
            watcher.Deleted += (sender, args) => Console.WriteLine(args.FullPath + " was was deleted.");


            Console.ReadLine();
        }
    }
}
