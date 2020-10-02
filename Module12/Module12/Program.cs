using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Module12
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = Car.GetCars();

            //PrintCars(cars);


            PrintCollection(cars);

            Console.WriteLine();
            var todoList = Todo.Create();
            PrintCollection(todoList);

        }



        private static void PrintCollection<T>(IEnumerable<T> items)
        {


            var type = typeof(T);
            IEnumerable<PropertyInfo> props = type.GetProperties();

            var printableProps = from p in props
                                where !p.GetCustomAttributes<HideAttribute>().Any()
                                select p;


            //List<PropertyInfo> printableProps = new List<PropertyInfo>();
            //foreach(var prop in props)
            //{
            //    var attribute = prop.GetCustomAttributes<HideAttribute>();
            //    if (!attribute.Any())
            //    {
            //        printableProps.Add(prop);
            //    }
            //}

            PrintHeaders(printableProps);
            PrintContent(items, printableProps);
        }

        private static void PrintContent<T>(IEnumerable<T> items, IEnumerable<PropertyInfo> props)
        {

            foreach(var item in items)
            {
                foreach(var propertyInfo in props)
                {
                    Console.Write(propertyInfo.GetValue(item));
                    Console.Write("\t");
                }
                Console.WriteLine();
            }
        }

        private static void PrintHeaders(IEnumerable<PropertyInfo> props)
        {

            foreach(var propertyInfo in props)
            {
                Console.Write(propertyInfo.Name);
                Console.Write("\t");
            }
            Console.WriteLine();

        }

        [Obsolete("Use the PrintCollection<T> method instead. This is no longer supported", error:true)]
        private static void PrintCars(List<Car> cars)
        {
            Console.WriteLine("Make\tModel\tYear\tColor");
            foreach(var car in cars)
            {
                Console.WriteLine($"{car.Make}\t{car.Model}\t{car.Year}\t{car.Color}");
            }
        }
    }


    class Car
    {

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        [Hide]
        public string Color { get; set; }

        public static List<Car> GetCars()
        {
            return new List<Car> { 
                new Car{Make="Honda", Model="Civic", Year=1978, Color="Beige"},
                new Car{Make="Oldsmobile", Model="Cutlass", Year=1978, Color="Beige"},
                new Car{Make="Mazda", Model="Maita", Year=1978, Color="Saphire"},
            };
        }


    }

   
    public class Todo
    {
        [Hide]
        public int Id { get; set; }
        public string Task { get; set; }
        public bool Completed { get; set; }

        public static IEnumerable<Todo> Create()
        {
            return new List<Todo> {
                new Todo{ Task = "Hire roofers", Completed=true},
                new Todo{ Task = "Buy headphones", Completed=true},
                new Todo{ Task = "Buy better noise cancelling headphones", Completed=false},
            };
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    class HideAttribute : Attribute
    {

    }

}
