using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Threading;

namespace CustomSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ShoppingCartItem Serialization");



            Console.WriteLine("Hello ShoppingCartItem object!");

            ShoppingCartItem toShoppingCart = new ShoppingCartItem(1, 2.50m, 100);


            //string data = "This must be stored in data file.";

            FileStream fs = new FileStream("SerializedString.Data", FileMode.Create);

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, toShoppingCart);

            fs.Close();

            FileStream fs1 = new FileStream("SerializedString.Data", FileMode.Open);

            BinaryFormatter bf1 = new BinaryFormatter();

            ShoppingCartItem fromShoppingCart;

            fromShoppingCart = (ShoppingCartItem)bf1.Deserialize(fs1);

            Console.WriteLine(fromShoppingCart.ToString());




        }


    }

    // For Custom Binary Serialization.
    [Serializable]
    public class ShoppingCartItem : ISerializable
    {
        public int _productId;
        public decimal _price;
        public int _quantity;

        [NonSerialized]
        public decimal _total;

        // The Standart Non - Serialization constructor.
        public ShoppingCartItem(int productId, decimal price, int quantity)
        {
            _productId = productId;
            _price = price;
            _quantity = quantity;
        }

        // The following constructor is for deserialization.
        protected ShoppingCartItem(SerializationInfo info, StreamingContext context)
        {
            // You must perform data validation in your serialization constructor and throw a SerializationException
            // if invalid data is provided. The risk is that an attacker could use your class but provide fake 
            // serialization information in an attemt to exploit weakness. you should assume that any calls
            // made to your serialization cunstructor are initiated by attacker, and allow the cunstruction only 
            // if all the data provided is valid and realistic.


            _productId = info.GetInt32("Product ID");
            _price = info.GetDecimal("Price");
            _quantity = info.GetInt32("Quantity");

        }

        // The folowing method is called during serialization
        //[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]  // Obsolete, not supported.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Product ID", _productId);
            info.AddValue("Price", _price);
            info.AddValue("Quantity", _quantity);
        }



        public override string ToString()
        {
            return _productId + ": " + _price + " x " + _quantity + " = " + _total;
        }

        [OnSerializing]
        public void MethodOne(StreamingContext sc)
        { }

        [OnSerialized]
        public void MethodTwo(StreamingContext sc)
        { }

        [OnDeserializing]
        public void MethodThree(StreamingContext sc)
        { }

        // Use with this attribute if serialization not binnary 
        [OnDeserialized]
        public void MethodFour(StreamingContext sc)
        { }
    }
}
