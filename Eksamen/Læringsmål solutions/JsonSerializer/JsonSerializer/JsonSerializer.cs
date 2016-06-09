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
    public class JsonSerializer<T> : IJsonSerializer<T>
    {
        #region Properties and Members

        private string _filename = "\\unnamed.json";

        private string Filename
        {
            get { return _filename; }
            set { _filename = "\\" + value + ".json"; }
        }

        #endregion

        /// <summary>
        /// Constructor for class, takes one argument.
        /// </summary>
        /// <param name="nameOfJsonFileToCreate">Name of file to create, without fileextension.</param>
        public JsonSerializer(string nameOfJsonFileToCreate)
        {
            Filename = nameOfJsonFileToCreate;

            StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + Filename);
        }

        #region Serialize + Overloads

        /// <summary>
        /// Method for serializing objects with json. 
        /// Will overwrite current context of .json file. Use 'AddToSerializedCollection' to add single item.
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
        /// <param name="productToSerialize">Single object to be serialized and added til file.</param>
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
            List<T> listOfDeserializedObjectToBeReturned = null;
            string alreadySerializedContentOfJsonFile = null;

            try
            {
                alreadySerializedContentOfJsonFile = File.ReadAllText(Directory.GetCurrentDirectory() + Filename);
            }
            catch (Exception e)
            {
                MessageBox.Show("While reading the file, i found an exception. It most likely means that the file " + Filename + " wasen't found\n\n " + e);
                throw;
            }

            listOfDeserializedObjectToBeReturned = JsonConvert.DeserializeObject<List<T>>(alreadySerializedContentOfJsonFile);

            return listOfDeserializedObjectToBeReturned;
        }

        #endregion
    }
}
