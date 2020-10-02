using Lab3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Ex4
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new TodoDb();
            var data = Todo.Create().ToList();

            //db.Todos.AddRange(data);
            //foreach(var td in data)
            //{
            //    db.Todos.Add(td);
            //}


            //db.SaveChanges();


            var todos = from t in db.Todos
                        orderby t.Completed
                        select t;


            foreach(var t in todos)
            {
                Console.WriteLine( t.Task + " | Completed: " + t.Completed);
            }
        }
    }

    class TodoDb : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
    }
}
