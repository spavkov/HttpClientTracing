using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TimeoutTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var client = new HttpClient() { Timeout = TimeSpan.FromSeconds(3) })
                {
                    var result =
                        client.GetAsync(@"http://localhost:9999/api/values").Result;

                    Console.WriteLine($"{result.StatusCode} {result.Content.ReadAsStringAsync().Result}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }

            Console.ReadLine();
        }
    }
}
