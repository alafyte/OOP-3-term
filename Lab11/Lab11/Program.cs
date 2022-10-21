using System.Collections.Generic;
using System;
using Lab08;
using Lab10;

namespace Lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Продемонстрируйте работу «Рефлектора» для исследования типов на созданных 
            вами классах не менее двух (предыдущие лабораторные работы) и стандартных 
            классах .Net.*/
            Reflector.ClearFile();
            Reflector.WriteAssemblyName("Lab10.Bus, Lab10");
            Reflector.WritePublicConstructors("Lab10.Bus, Lab10");
            Reflector.WritePublicMethods("Lab10.Bus, Lab10");
            Reflector.WriteFieldsAndProperties("Lab10.Bus, Lab10");
            Reflector.WriteMethodsWithUserParametr("Lab10.Bus, Lab10", "transportMileage");

            Reflector.WriteAssemblyName("Lab08.Software, Lab08");
            Reflector.WritePublicConstructors("Lab08.Software, Lab08");
            Reflector.WritePublicMethods("Lab08.Software, Lab08");
            Reflector.WriteFieldsAndProperties("Lab08.Software, Lab08");
            Reflector.WriteMethodsWithUserParametr("Lab08.Software, Lab08", "newVersion");

            Reflector.WriteAssemblyName("System.Object");
            Reflector.WritePublicConstructors("System.Object");
            Reflector.WritePublicMethods("System.Object");
            Reflector.WriteFieldsAndProperties("System.Object");
            Reflector.WriteMethodsWithUserParametr("System.Object", "");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Reflector.Invoke("Lab11.Cat", "FeedCat");

            Console.ForegroundColor = ConsoleColor.Green;
            var bars = Reflector.Create("Lab11.Bars");
            Console.WriteLine(bars is Bars);
        }
    }
}
