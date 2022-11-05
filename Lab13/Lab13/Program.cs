using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            var ball = new Ball("Мяч №1", 6);

            //Binary
            string path = @"C:\University\3_cем\ОOП\Lab13\Lab13\Binary.bin";
            Ball containerForBinary = new Ball();
            CustomSerializer.Serialize(ball, "bin", path);
            CustomSerializer.Deserialize(ref containerForBinary, "bin", path);
            Console.WriteLine($"---- Десериализация из .bin ----\n {containerForBinary.ToString()}\n");

            //SOAP
            path = @"C:\University\3_cем\ОOП\Lab13\Lab13\SoapFile.soap";
            Ball containerForSOAP = new Ball();
            CustomSerializer.Serialize(ball, "SOAP", path);
            CustomSerializer.Deserialize(ref containerForSOAP, "soap", path);
            Console.WriteLine($"---- Десериализация из .soap ----\n {containerForSOAP.ToString()}\n");

            //XML
            path = @"C:\University\3_cем\ОOП\Lab13\Lab13\Xml.xml";
            Ball containerForXML = new Ball();
            CustomSerializer.Serialize(ball, "XML", path);
            CustomSerializer.Deserialize(ref containerForXML, "XML", path);
            Console.WriteLine($"---- Десериализация из .xml ----\n {containerForXML.ToString()}\n");

            //JSON
            path = @"C:\University\3_cем\ОOП\Lab13\Lab13\json.json";
            Ball containerForJSON = new Ball();
            CustomSerializer.Serialize(ball, "JSON", path);
            CustomSerializer.Deserialize(ref containerForJSON, "JSON", path);
            Console.WriteLine($"---- Десериализация из .json -----\n {containerForJSON.ToString()}\n");

            /*2) Создайте коллекцию (массив) объектов и выполните сериализацию/десериализацию – возможность сохранения 
            и загрузки спиcка объектов в/из файла.*/
            Console.ForegroundColor = ConsoleColor.Blue;
            var items = new List<Inventory>();
            var itemsFromFile = new List<Inventory>();

            var firstitem = new Bench("Скамья");
            var seconditem = new BasketballBall("Баскетбольный мяч", 8);
            var thirditem = new Ball("Мяч", 7);

            items.Add(firstitem);
            items.Add(seconditem);
            items.Add(thirditem);

            path = @"C:\University\3_cем\ОOП\Lab13\Lab13\JsonTask2.json";
            CustomSerializer.Serialize(items, "JSON", path);
            Console.WriteLine($"---- Десериализация из .json -----");
            CustomSerializer.Deserialize(ref itemsFromFile, "JSON", path);

            foreach (var inventory in itemsFromFile)
            {
                Console.WriteLine(inventory.ToString());
            }

            /*3) Используя XPath напишите два селектора для вашего XML документа.*/
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(@"C:\University\3_cем\ОOП\Lab13\Lab13\Xml.xml");
            var xRoot = xmlDocument.DocumentElement;

            var selectNodes = xRoot.SelectNodes("*");
            foreach (object node in selectNodes) 
                Console.WriteLine((node as XmlNode).Name);

            Console.WriteLine();
            var nameNodes = xRoot.SelectNodes("Name");
            foreach (object nameNode in nameNodes) 
                Console.WriteLine((nameNode as XmlNode).InnerText);
            Console.WriteLine();


            /*4) Используя Linq to XML (или Linq to JSON) создайте новый xml (json) -
            документ и напишите несколько запросов.*/
            Console.ForegroundColor = ConsoleColor.Cyan;
            XDocument CatsXML = new XDocument();
            XElement root = new XElement("Cats");

            XElement cat;
            XElement name;
            XAttribute breed;

            cat = new XElement("cat");
            name = new XElement("name");
            name.Value = "Барсик";
            breed = new XAttribute("breed", "siamese");
            cat.Add(name);
            cat.Add(breed);
            root.Add(cat);

            cat = new XElement("cat");
            name = new XElement("name");
            name.Value = "Кьяра";
            breed = new XAttribute("breed", "striped");
            cat.Add(name);
            cat.Add(breed);
            root.Add(cat);

            cat = new XElement("cat");
            name = new XElement("name");
            name.Value = "Муся";
            breed = new XAttribute("breed", "persian");
            cat.Add(name);
            cat.Add(breed);
            root.Add(cat);

            CatsXML.Add(root);
            CatsXML.Save(@"C:\University\3_cем\ОOП\Lab13\Lab13\CatsXML.xml");

            Console.WriteLine("Введите породу: ");
            string breedXML = Console.ReadLine();
            var elements = root.Elements("cat");


            foreach (var item in elements)
            {
                if (item.Attribute("breed").Value == breedXML)
                {
                    Console.WriteLine(item.Value);
                }
            }
        }
    }
}
