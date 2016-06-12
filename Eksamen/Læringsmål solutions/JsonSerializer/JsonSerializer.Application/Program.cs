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
            JsonSerializer<Produkt> js = new JsonSerializer<Produkt>("NewFile");

            Produkt produkt = new Produkt() { Height = 98, Id = 8, Name = "ugyuyg", Weight = 98 };

            js.Serialize(produkt);

            Console.WriteLine(js.Deserialize());
        }
    }
}