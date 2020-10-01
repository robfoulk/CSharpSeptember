using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security;

namespace Module07_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //InsertData();

            var db = new SimpleDb();


            db.Database.Log = Console.WriteLine;


            //var cats = from p in db.Pets
            //           where p.Animal == "Cat"
            //           select p;


            //var cats = db.Pets.Where(p => p.Animal == "Cat");


            var allPets = from p in db.Pets
                          orderby p.Name
                          select p;

            var cats = from p in allPets
                       where p.Animal == "Cat" && p.Id> 1
                       select p;

            var downloadedCats = cats.ToList();


            foreach (var cat in downloadedCats)
            {
                Console.WriteLine($"{cat.Name}");
            }

            foreach (var cat in downloadedCats)
            {
                Console.WriteLine($"{cat.Name}");
            }

            Console.WriteLine("All done");



            //var moose = db.Pets.Find(1);  //Look up by ID

            var meeses = from p in db.Pets
                         where p.Animal == "Chocolate Lab"
                         select p;

            var moose = meeses.FirstOrDefault(); //null if there is no moose
            //var moose = meeses.First(); //Exception if there is no moose


        }

        private static void InsertData()
        {
            var p1 = new Pet { Name = "Moose", Animal = "Chocolate Lab" };
            var p2 = new Pet { Name = "Yoyo", Animal = "Cat" };
            var p3 = new Pet { Name = "Rosie", Animal = "Dog" };
            var p4 = new Pet { Name = "Lab Rat", Animal = "Cat" };

            var db = new SimpleDb();

            db.Pets.Add(p1);
            db.Pets.Add(p2);
            db.Pets.Add(p3);
            db.Pets.Add(p4);

            db.SaveChanges();  //Adds the data to the database

            Console.WriteLine("Data Added");
        }
    }

    class SimpleDb: DbContext
    {
        public DbSet<Pet> Pets { get; set; }
    }

    class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Animal { get; set; }
    }
}
