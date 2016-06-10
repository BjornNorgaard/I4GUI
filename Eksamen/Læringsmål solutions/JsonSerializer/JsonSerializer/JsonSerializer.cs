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

            // creating empty file to prevent crash when trying to read before creating file
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + Filename))
            {
                sw.Write("");
                sw.Close();
            }
        }

        #region Serialization methods

        /// <summary>
        /// Method for serializing objects with json. 
        /// Will overwrite current context of .json file. Use 'SerializeObject' to add single item.
        /// </summary>
        /// <param name="listOfProductsToSerialize">List of objects to be serialized.</param>
        public void OverwriteSerializeCollectionWithOtherCollection(List<T> listOfProductsToSerialize)
        {
            string serializedObjects = JsonConvert.SerializeObject(listOfProductsToSerialize);

            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + Filename))
            {
                sw.Write(serializedObjects);
                sw.Close();
            }
        }

        /// <summary>
        /// Overwrites file with single serialized object.
        /// </summary>
        /// <param name="productToSerialize">Object to overwrite file with.</param>
        public void OverwriteSerializedCollectionWithObject(T productToSerialize)
        {
            List<T> listOfSingleObjectToBeSerialized = new List<T>();
            listOfSingleObjectToBeSerialized.Add(productToSerialize);

            string serializedObjects = JsonConvert.SerializeObject(listOfSingleObjectToBeSerialized);

            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + Filename))
            {
                sw.Write(serializedObjects);
                sw.Close();
            }
        }

        /// <summary>
        /// Adds collection to the already serialized file.
        /// </summary>
        /// <param name="collectionOfObjects">List of objects to be serialized in file.</param>
        public void SerializeCollection(List<T> collectionOfObjects)
        {
            List<T> listOfPreviouslySerializedObjects = Deserialize();

            foreach (T item in collectionOfObjects)
            {
                listOfPreviouslySerializedObjects.Add(item);
            }

            OverwriteSerializeCollectionWithOtherCollection(listOfPreviouslySerializedObjects);
        }

        /// <summary>
        /// Overload for Serialized method. This one only takes one object and adds it to .json file.
        /// </summary>
        /// <param name="productToSerialize">Single object to be serialized and added til file.</param>
        public void SerializeObject(T productToSerialize)
        {
            List<T> listOfPreviouslySerializedObjects = Deserialize();
            listOfPreviouslySerializedObjects.Add(productToSerialize);

            OverwriteSerializeCollectionWithOtherCollection(listOfPreviouslySerializedObjects);
        }

        #endregion

        #region Deserialize

        /// <summary>
        /// Returns content of .json file.
        /// </summary>
        /// <returns>List containing all serialized objects.</returns>
        public List<T> Deserialize()
        {
            string alreadySerializedContentOfJsonFile;

            try
            {
                alreadySerializedContentOfJsonFile = File.ReadAllText(Directory.GetCurrentDirectory() + Filename);
            }
            catch (Exception e)
            {
                MessageBox.Show("While trying to read the file, i found an exception:\n\n " + e);
                throw;
            }

            //if (alreadySerializedContentOfJsonFile == "")
            //{
            //    return new List<T>();
            //}

            List<T> listOfDeserializedObjectToBeReturned = JsonConvert.DeserializeObject<List<T>>(alreadySerializedContentOfJsonFile);

            return listOfDeserializedObjectToBeReturned;
        }

        #endregion
    }
}
