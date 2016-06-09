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
    public class JsonSerializer<T>
    {
        #region Properties and Members

        private string _filename = "\\products.json";

        public string Filename
        {
            get { return _filename; }
            set { _filename = "\\" + value; }
        }

        #endregion

        #region Serialize + Overloads

        /// <summary>
        /// Method for serializing objects with json.
        /// </summary>
        /// <param name="ListOfProductsToSerialize">List of objects to be serialized.</param>
        public void SerializeCollection(List<T> ListOfProductsToSerialize)
        {
            string serializedObjects = JsonConvert.SerializeObject(ListOfProductsToSerialize);
                                                 
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + Filename))
            {
                sw.Write(serializedObjects);
                sw.Close();
            }
        }

        /// <summary>
        /// Overload for Serialized method. This one only takes one object and adds it to .json file.
        /// </summary>
        /// <param name="productToSerialize">Single object to be serialized.</param>
        public void AddToSerializedCollection(T productToSerialize)
        {
            List<T> listOfPreviouslySerializedObjects = Deserialize();
            listOfPreviouslySerializedObjects.Add(productToSerialize);

            SerializeCollection(listOfPreviouslySerializedObjects);
        }

        #endregion
                               
        #region Deserialize

        /// <summary>
        /// Returns content of .json file.
        /// </summary>
        /// <returns>List containing all serialized objects.</returns>
        public List<T> Deserialize()
        {
            List<T> listOfDeserializedObjectToBeReturned;

            try
            {
                string AlreadySerializedContentOfJsonFile = File.ReadAllText(Directory.GetCurrentDirectory() + Filename);
                listOfDeserializedObjectToBeReturned = JsonConvert.DeserializeObject<List<T>>(AlreadySerializedContentOfJsonFile);
            }
            catch (Exception e)
            {
                MessageBox.Show("You done fucked up, here is an exception: " + e);
                throw;
            }

            return listOfDeserializedObjectToBeReturned;
        }

        #endregion
    }
}
