using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using xl = Microsoft.Office.Interop.Excel;

namespace Module11
{
    class Program
    {
        static void Main(string[] args)
        {

            var app = new xl.Application();                     
            var book = app.Workbooks.Add();                     
                                                                
            var sheet = book.Worksheets.Add();                  
            sheet.Range("A1").Value = "Title";                  
            sheet.Range("B1").Value = "Count";                  
                                                                
            sheet.Range("A2").Value = "Lord of the Flies";      
            sheet.Range("B2").Value = 12;                       
                                                                
            sheet.Range("A3").Value = "Lord of the Flies";      
            sheet.Range("B3").Value = 12;


            book.SaveAs(@"c:\class\books.xlsx", AddToMru: false);
            book.Close();
            app.Quit();
            Console.WriteLine("Excel doc written");
        }


        static void Demo1()
        {

            dynamic something;
            if (DateTime.Now.Millisecond % 2 == 0)
            {
                something = "A string of characters";
            }
            else
            {
                something = new string[] { "Happy", "Sleepy", "Bashful", "Sneezy", "Doc", "Snobby", "Grumpy" };
            }



            Console.WriteLine(something.Length);


            //if(something is string mystring)
            //{
            //    //var mystring = (string)something;
            //    Console.WriteLine(mystring.Length);
            //}else if(something is string[] myArray)
            //{
            //    //string[] myArray = (string[])something;
            //    Console.WriteLine(myArray.Length);
            //}
        }



        void Demo3()
        {

            

            using (System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection())
            {



            }

        }



    }

    //Disposal Pattern
    //You should NOT need this a lot

    class CoolWrapper : IDisposable
    {
        //Creating a Managed Disposable Field
        //or
        //Create an Unmanaged Disposable field (SUPER Rare)
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CoolWrapper()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }



}
