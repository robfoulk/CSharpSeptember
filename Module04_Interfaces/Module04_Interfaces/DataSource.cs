using System;
using System.Collections.Generic;

namespace Module04_Interfaces
{


    //Step 3
    internal class DataSource : IOrderDataSource
    {
        public List<Order> GetOrders()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Talking to a database!!!!");
            System.Diagnostics.Debug.WriteLine("Talking to database");
            Console.ResetColor();



            return new List<Order> {
                new Order{Total=100},
                new Order{Total=100},
                new Order{Total=100},
                new Order{Total=100},
                new Order{Total=100},
                new Order{Total=100},
            };
        }
    }
}