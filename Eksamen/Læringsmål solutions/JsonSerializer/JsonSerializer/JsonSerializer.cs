using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
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
    public class JsonSerializer<T>
    {
        #region Properties and Members

        private string _filename = "\\unnamed.json";

        public string Filename
        {
            get { return _filename; }
            set { _filename = "\\" + value + ".json"; }
        }

        #endregion

        public JsonSerializer(string filename)
        {
            Filename = filename;
        }

        public bool FolderExists()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + Filename) == false)
            {
                return false;
            }

            return true;
        }

        public async void Serialize(T item)
        {
            string jsonOutput = JsonConvert.SerializeObject(item);

            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + Filename))
            {
                await sw.WriteLineAsync(jsonOutput);
                sw.Close();
            }
        }

        public T Deserialize()
        {
            string currentContent = null;

            if (File.Exists(Directory.GetCurrentDirectory() + Filename) == false)
            {
                throw new Exception("Derp: File was not found!");
            }

            try
            {
                currentContent = File.ReadAllText(Directory.GetCurrentDirectory() + Filename);
            }
            catch (Exception e)
            {
                MessageBox.Show("Derp, Error while reading file: " + e);
            }

            T deserializedStuff = JsonConvert.DeserializeObject<T>(currentContent);

            return deserializedStuff;
        }
    }
}
