using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Module08
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter a URL to lookup: ");
            var userUrl = Console.ReadLine();

            userUrl = CleanUpUrl(userUrl);
            try
            {

                var request = (HttpWebRequest)WebRequest.Create(userUrl);
                var response = (HttpWebResponse)request.GetResponse();

                var reader = new StreamReader(response.GetResponseStream());
                var content = reader.ReadToEnd();
                Console.WriteLine("Humans Found!");
                Console.WriteLine();
                Console.WriteLine(content);
            }
            catch(WebException ex)
            {
                var response = ex?.Response as HttpWebResponse;
                if(response == null)
                {
                    Console.WriteLine(ex.Message + " - " + ex.GetType().FullName);
                }
                else if(response.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine("There are no humans there");
                }
            }

        }

        private static string CleanUpUrl(string userUrl)
        {
            if (!userUrl.StartsWith("https://"))
            {
                userUrl = "https://" + userUrl;
            }


            if (!userUrl.EndsWith("/"))
            {
                userUrl += "/";
            }

            userUrl += "humans.txt";
            return userUrl;
        }
    }
}
