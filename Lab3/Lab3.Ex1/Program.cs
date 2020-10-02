using Lab3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Ex1
{
    class Program
    {
        private const string BaseFile = @"c:\class\todo.txt";

        static void Main(string[] args)
        {

            var data = Todo.Create()
                .Select(t => t.Task)
                .ToArray();


            File.WriteAllLines(BaseFile, data);
            //or

            //using (var fs = new FileStream(BaseFile, FileMode.Create))
            //using (var writer = new StreamWriter(fs))
            //{
            //    foreach (var line in data)
            //    {
            //        writer.WriteLine(line);
            //    }
            //}


            using (var fs = new FileStream(BaseFile, FileMode.Open))
            using (var writer = new StreamReader(fs))
            {
                while (!writer.EndOfStream)
                {
                    Console.WriteLine(writer.ReadLine());
                }
            }

        }
    }
}
