using System;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

namespace I4GUI_eksamen_2015_sommer_2
{
    public class JsonDude<T>
    {
        private string _filename = "\\unanmed.json";

        public string Filename
        {
            get { return _filename; }
            set { _filename = "\\" + value + ".json"; }
        }

        public JsonDude(string filename)
        {
            Filename = filename;

            if (File.Exists(Directory.GetCurrentDirectory() + Filename) == false)
            {
                using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + Filename))
                {
                    sw.Write("");
                    sw.Close();
                }
            }
        }

        public void Save(T objectToBeSaved)
        {
            string jsonOutput = JsonConvert.SerializeObject(objectToBeSaved);

            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + Filename))
            {
                sw.Write(jsonOutput);
                sw.Close();
            }
        }

        public T Load()
        {
            string currentContent = null;

            try
            {
                currentContent = File.ReadAllText(Directory.GetCurrentDirectory() + Filename);
            }
            catch (Exception e)
            {
                MessageBox.Show("Derp: Found error while reading file: " + e);
            }

            T deserializedObject = JsonConvert.DeserializeObject<T>(currentContent);
            return deserializedObject;
        }
    }
}