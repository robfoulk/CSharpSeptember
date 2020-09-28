using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Module04_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {

            //Running in "production"
            var bc = new BusinessClass();
            var total = bc.ProcessOrders();
            Console.WriteLine($"Current Order Total: {total:c}");

        }

    }


    //step 2
    interface IOrderDataSource
    {
        List<Order> GetOrders();
    }

    class BusinessClass
    {
        //1) Determine the dependencies
        //2) Describe the dependency in an Interface
        //3) implement the interface on the dependencies
        //4) Move the dependency out of the method
        //5) Instantiate a 'default' type in a default constructor
        //6) add a constructor that accepts a different dependency
        //7) Create fakes for testing
        //8) Inject those fakes in tests

        //Step 5
        public BusinessClass()
        {
            ds = new DataSource();
        }

        //Step 6
        public BusinessClass(IOrderDataSource injectedDataSource)
        {
            ds = injectedDataSource;
        }

        //step 4 - part 2
        private IOrderDataSource ds;


        public Decimal ProcessOrders()
        {

            //step 4 part 1 (commenting)
            //DataSource ds = new DataSource();
            List<Order> orders = ds.GetOrders();
            decimal total = 0;

            foreach (var order in orders)
            {
                total += order.Total;
            }
            return total;
        }



    }


    [TestClass]
    class TestBusinessClass
    {

        [TestMethod]
        public void TestProcessing()
        {
            //Step 8
            var dataSource = new FakeOrderDataSource();

            var bc = new BusinessClass(dataSource);

            var total = bc.ProcessOrders();

            Assert.AreEqual(total, 600);


        }
    }

    //Step 7
    class FakeOrderDataSource : IOrderDataSource
    {


        public List<Order> GetOrders()
        {
            Console.WriteLine("using fake data");
            return new List<Order>
            {
                new Order{Total = 1},
                new Order{Total = 1},
                new Order{Total = 1},
                new Order{Total = 1},
            };
        }

    }



}
