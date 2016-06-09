using System.Collections.Generic;

namespace JsonSerializer
{
    public interface IJsonSerializer<T>
    {
        void AddToSerializedCollection(T productToSerialize);
        List<T> Deserialize();
        void SerializeCollection(List<T> ListOfProductsToSerialize);
    }
}