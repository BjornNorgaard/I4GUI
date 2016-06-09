using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace JsonSerializer.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonSerializer<Produkt> js = new JsonSerializer<Produkt>("products");

            //Produkt produkt1 = new Produkt() { Name = "Bjorn", Height = 188, Id = 2, Weight = 89 };
            //Produkt produkt2 = new Produkt() { Name = "Joachim", Height = 1888, Id = 72, Weight = 899 };
            //Produkt produkt3 = new Produkt() { Name = "Someguy", Height = 1888, Id = 26, Weight = 879 };

            //List<Produkt> produkts = new List<Produkt>();
            //produkts.Add(produkt1);
            //produkts.Add(produkt2);
            //produkts.Add(produkt3);

            //js.SerializeCollection(produkts);

            //js.AddToSerializedCollection(new Produkt() { Height = 98, Id = 9, Name = "hans", Weight = 9 });

            js.Deserialize();

            //foreach (Produkt produkt in js.Deserialize())
            //{
            //    Console.WriteLine(produkt.Name);
            //}
        }
    }
}