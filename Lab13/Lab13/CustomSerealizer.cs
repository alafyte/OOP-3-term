using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace Lab13
{
    /*1) Создайте класс CustomSerializer, который обеспечивает сериализацию/десериализацию объекта используя форматы: 
        a. Binary, 
        b. SOAP, 
        c. JSON, 
        d. XML.*/
    public static class CustomSerializer
    {
        public static void Serialize<T>(T obj, string option, string path) where T : class
        {
            switch(option.ToUpper())
            {
                case "BIN":
                    {
                        var binaryFormatter = new BinaryFormatter();
                        using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            binaryFormatter.Serialize(fileStream, obj);
                            Console.WriteLine("Объект сериализован");
                        }
                        break;
                    }
                case "SOAP":
                    {
                        var soapFormatter = new SoapFormatter();
                        using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            soapFormatter.Serialize(fileStream, obj);
                            Console.WriteLine("Объект сериализован");
                        }
                        break;
                    }
                case "XML":
                    {
                        var xmlSerializer = new XmlSerializer(typeof(T));
                        using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            xmlSerializer.Serialize(fileStream, obj);
                            Console.WriteLine("Объект сериализован");
                        }
                        break;
                    }
                case "JSON":
                    {
                        var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

                        string serialized = JsonConvert.SerializeObject(obj, settings);
                        using (var fileStream = new StreamWriter(path))
                        {
                            fileStream.Write(serialized);
                            Console.WriteLine("Объект сериализован");
                        }
                        break;
                    }
            }
        }

        public static void Deserialize<T>(ref T container, string option, string path) where T : class
        {
            switch(option.ToUpper())
            {
                case "BIN":
                    {
                        var binaryFormatter = new BinaryFormatter();
                        using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            container = binaryFormatter.Deserialize(fileStream) as T;
                        }
                        break;
                    }
                case "SOAP":
                    {
                        var soapFormatter = new SoapFormatter();
                        using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            container = soapFormatter.Deserialize(fileStream) as T;
                        }
                        break;
                    }
                case "XML":
                    {
                        var xmlSerializer = new XmlSerializer(typeof(T));
                        using (var fileStream = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            container = xmlSerializer.Deserialize(fileStream) as T;
                        }
                        break;
                    }
                case "JSON":
                    {
                        var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                        using (var fileStream = new StreamReader(path))
                        {
                            string json = fileStream.ReadToEnd();
                            container = JsonConvert.DeserializeObject<T>(json, settings);
                        }
                        break;
                    }
            }
        }
    }
}
