using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MMTCallApi
{
    class Program
    {
        static void Main(string[] args)
        {
            string options = "";
            HttpClient client = new HttpClient();
            Console.WriteLine("Calling Web API for MMT Shop");
            Console.WriteLine("============================");

            Console.WriteLine("Please Enter following for Api Call Options");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("1. Enter 'Category' to Display all Categories for Products.");
            Console.WriteLine("2. Enter 'Featured' to Display all Featured Products.");
            Console.WriteLine("3. Enter 'Category Id (e.g 1, 2, 3, etc )' to Display Products for that Category.");
            Console.WriteLine("");

            Console.Write("Please Enter you choice :");
            options = Console.ReadLine();

            string strUri = "http://localhost:1053/api/";
            string strtitle ="";

            if ((options == "Category") || (options == "FeaturedProducts"))
            {
                strtitle = options;
            }
            else
            {
                strUri = "http://localhost:1053/api/ProductByCategory/";
                strtitle = "Products by Categroy";

            }

            strUri = strUri + options;

            var responseTask = client.GetAsync(strUri);
            responseTask.Wait();
            if (responseTask.IsCompleted)
            {
                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var messageTask = result.Content.ReadAsStringAsync();
                    messageTask.Wait();
                    Console.WriteLine();
                    Console.WriteLine("Result for " + strtitle);
                    Console.WriteLine("==================================");
                    Console.WriteLine(messageTask.Result);
                    Console.ReadLine();
                }
            }

        }
    }
}
