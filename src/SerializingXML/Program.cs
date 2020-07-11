using System;
using System.IO;
using System.Xml.Serialization;

namespace SerializingXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello XML Serialization!");

            FileStream fs = new FileStream("SerializeDate.xml", FileMode.Create);

            XmlSerializer xs = new XmlSerializer(typeof(DateTime));

            xs.Serialize(fs, DateTime.Now);

            fs.Close();


            // Deserialize data

            FileStream fileStream = new FileStream("SerializeDate.xml", FileMode.Open);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DateTime));

            DateTime dateTime = (DateTime)xmlSerializer.Deserialize(fileStream);

            fileStream.Close();

            Console.WriteLine(dateTime.ToString());

        }
    }
}
