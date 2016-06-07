using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;
using System.Windows.Forms;

namespace JsonSerializer
{
    public class JsonSerializer
    {
        public string Filename { get; set; } = "\\products.json";

        public void Serialize(List<Produkt> productToSerialize)
        {
            string jsonOutput = JsonConvert.SerializeObject(productToSerialize);

            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + Filename))
            {
                sw.Write(jsonOutput);
                sw.Close();
            }
        }

        public List<Produkt> Deserialize()
        {
            List<Produkt> products = new List<Produkt>();

            try
            {
                string json = File.ReadAllText(Directory.GetCurrentDirectory() + Filename);
                products = JsonConvert.DeserializeObject<List<Produkt>>(json);
            }
            catch (Exception e)
            {
                MessageBox.Show("You done fucked up, because of: " + e);
                throw;
            }

            return products;
        }
    }
}
