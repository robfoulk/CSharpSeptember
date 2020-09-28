using System;
using System.Collections.Generic;
using System.Collections;  //Original Collections in the .NET framework
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module04_Generics
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
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Randomize(numbers);

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }


            string[] names = { "albert", "barry", "carl", "david", "edward", "francine" };
            Randomize(names);
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        private static void Randomize<T>(T[] numbers)
        {
            Random rnd = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                var slot = rnd.Next(numbers.Length);
                Swap<T>(ref numbers[i], ref numbers[slot]);

            }
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }

        static TReturn DoWork<TInput, TReturn>(TInput input)
        {
            return default(TReturn);
        }

        private static void Demo1()
        {
            //string[] names = new string[3];
            //ArrayList al = new ArrayList(); //.NET Junk drawer
            //al.Add("Alex");
            //al.Add("Brian");
            //al.Add("Edgar");
            //al.Add(2.2); //accident
            //al.Add(al); //accident

            //foreach(var item in al)
            //{

            //}

            List<string> names = new List<string>();
            names.Add("Fransesco");
            names.Add("Francisco");
            names.Add("Imtiyaz");

            var x = names[1];


            List<int> ages = new List<int>();
            ages.Add(30);
            ages.Add(31);
            ages.Add(23);
            ages.Add(59);
            


        }
    }
}
