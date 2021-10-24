using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializingObject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Serializing object!");

            // How to serialize object.
            // 1. Create a stream object to hold the serialized output.

            string data = "This must be stored in data file.";

            // 2. Create a BinnaryFormatter object ( located in System.Runtime.Serialization.Formatterers.Binnary).

            FileStream fs = new FileStream("SerializedString.Data", FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();

            // 3. Call BinnaryFormatter.Serialise method to serialise the object and output the result to stream.

            bf.Serialize(fs, data);

            fs.Close();


            // Deserialize Object.

            // 1. Create a stream object to read the serialize output.

            FileStream fs1 = new FileStream("SerializedString.Data", FileMode.Open);

            // 2. Create BinaryFormatter object

            BinaryFormatter bf1 = new BinaryFormatter();

            // 3. Create new object to store the deserialized data.

            string data1 = "";

            // 4. Call BinaryFormatter.Deserialize method to deserialize the object, and cast it to correct type.

            data1 = (string)bf1.Deserialize(fs1);

            Console.WriteLine(data1);


        }
    }


    [Serializable]
    public class ShoppingCartItem : IDeserializationCallback
    {
        public int productId;
        public decimal price;
        public int quantity;

        [NonSerialized]
        public decimal total;

        public ShoppingCartItem(int _productId, decimal _price, int _quantity)
        {
            productId = _productId;
            price = _price;
            quantity = _quantity;
            total = price * quantity;
        }

        public void OnDeserialization(object sender)
        {
            total = price * quantity;
        }
    }

    [Serializable]
    public class ShoppingCartItemV1 : IDeserializationCallback
    {
        public int productId;
        public decimal price;
        public int quantity;

        [NonSerialized]
        public decimal total;

        [OptionalField]
        public int Bribes;

        public ShoppingCartItemV1(int _productId, decimal _price, int _quantity)
        {
            productId = _productId;
            price = _price;
            quantity = _quantity;
            total = price * quantity;
        }

        public void OnDeserialization(object sender)
        {
            total = price * quantity;





        }
    }

}
