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

            Produkt produkt1 = new Produkt() { Name = "Bjorn", Height = 188, Id = 2, Weight = 89 };
            Produkt produkt2 = new Produkt() { Name = "Joachim", Height = 45, Id = 72, Weight = 987 };
            Produkt produkt3 = new Produkt() { Name = "Someguy", Height = 7654, Id = 66, Weight = 879 };

            List<Produkt> produkts = new List<Produkt>();
            produkts.Add(produkt1);
            produkts.Add(produkt2);
            produkts.Add(produkt3);

            js.SerializeCollection(produkts);

            Produkt produkt4 = new Produkt() { Name = "Dennis", Height = 188, Id = 2, Weight = 89 };
            Produkt produkt5 = new Produkt() { Name = "Signe", Height = 9876, Id = 72, Weight = 7 };
            Produkt produkt6 = new Produkt() { Name = "Depro", Height = 687, Id = 5, Weight = 87 };

            List<Produkt> produkts2 = new List<Produkt>();
            produkts2.Add(produkt4);
            produkts2.Add(produkt5);
            produkts2.Add(produkt6);

            js.OverwriteSerializeCollectionWithOtherCollection(produkts2);

            js.SerializeObject(new Produkt() { Height = 98, Id = 9, Name = "hans", Weight = 9 });

            js.OverwriteSerializedCollectionWithObject(new Produkt() { Height = 88, Id = 77, Name = "New Guy", Weight = 66 });

            //js.Deserialize();

            foreach (Produkt produkt in js.DeserializeCollection())
            {
                Console.WriteLine(produkt.Name);
            }
        }
    }
}