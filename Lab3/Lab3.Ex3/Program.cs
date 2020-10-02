using Lab3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Ex3
{
    class Program
    {
        private const string basePath = @"c:\class\todos.json";

        static void Main(string[] args)
        {
            var todos = Todo.Create();
            var payload = JsonConvert.SerializeObject(todos);
            File.WriteAllText(basePath, payload);


            var content = File.ReadAllText(basePath);
            var readTodos = JsonConvert.DeserializeObject<List<Todo>>(content);

            foreach (var todo in readTodos)
            {
                Console.WriteLine($"{todo.Task} - {(todo.Completed ? "yup": "nope")}");
            }
        }
    }
}
