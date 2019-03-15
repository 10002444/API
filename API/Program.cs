using System;
using System.Net;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch st = new Stopwatch();
            st.Start();

            string url = "https://uinames.com/api/?ext&amount=50";
            

            string json = new WebClient().DownloadString(url);

            //Console.WriteLine(json);

            List<Person> data = new JavaScriptSerializer().Deserialize<List<Person>>(json);

            st.Stop();

            foreach (Person x in data)
            {
                Console.WriteLine("Name: {0} {1}\nGender: {2}\nRegion: {3}\n", x.name, x.surname, x.gender, x.region);
            }
            Console.WriteLine("Time to populate the list: {0}ms\n", st.ElapsedMilliseconds);
        }


        public class Person
        {
            public string name { get; set; }

            public string surname { get; set; }

            public string gender { get; set; }

            public string region { get; set; }

            public int age { get; set; }

            public string title { get; set; }

            public string phone { get; set; }

            public Birthday birthday { get; set; }

            public string email { get; set; }

            public string password { get; set; }

            public CreditCart credit_card { get; set; }

            public string photo { get; set; }
        }

        public class Birthday
        {
            public string dmy { get; set; }

            public string mdy { get; set; }

            public int raw { get; set; }
        }

        public class CreditCart
        {
            public string expiration { get; set; }

            public string number { get; set; }

            public int pin { get; set; }

            public int sercurity { get; set; }
        }
    }
}
