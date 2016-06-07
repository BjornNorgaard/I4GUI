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
            JsonSerializer js = new JsonSerializer();

            //Produkt produkt1 = new Produkt() {Name = "Somename", Height = 188, Id = 2, Weight = 89};
            //Produkt produkt2 = new Produkt() {Name = "kuygkuyg", Height = 1888, Id = 72, Weight = 899};
            //Produkt produkt3 = new Produkt() {Name = "Somekuygkuygname", Height = 1888, Id = 26, Weight = 879};

            //List<Produkt> produkts = new List<Produkt>();
            //produkts.Add(produkt1);
            //produkts.Add(produkt2);
            //produkts.Add(produkt3);

            //js.Serialize(produkts);

            foreach (Produkt produkt in js.Deserialize())
            {
                Console.WriteLine(produkt.Name);
            }
        }
    }
}
