using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module07_Designer
{
    class Program
    {
        static void Main(string[] args)
        {

            var db = new SimpleDb(); //SimpleEntities


            //Lab Rat's real name is Tiberius
            var labRat = db.Pets.Find(4); //Query by Primary Key


            labRat.Name = "Tiberius";


            db.SaveChanges();



            var pets = from p in db.Pets
                       orderby p.Name descending
                       select p;


            foreach(var p in pets)
            {
                Console.WriteLine(p.Name + " - " + p.Id);
            }


        }
    }
}
