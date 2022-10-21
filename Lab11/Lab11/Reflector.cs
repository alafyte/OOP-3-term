using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using Lab08;
using Lab10;

namespace Lab11
{
    /* Для изучения .NET Reflection API напишите статический класс Reflector, 
    который собирает информацию и будет содержать методы выполняющие 
    исследования класса (принимают в качестве параметра имя класса) и 
    записывающие информацию в файл (формат тестовый, json или xml):*/
    public static class Reflector
    {
        private static StreamWriter sw = null;

        //a. Определение имени сборки, в которой определен класс
        public static void WriteAssemblyName(string currentClassName)
        {
            sw = new StreamWriter(@"C:\University\3_cем\ОOП\Lab11\Lab11\ClassInfo.txt", true);
            Type currentClass = Type.GetType(currentClassName, true, true);
            string assemblyName = currentClass.Assembly.ToString();
            sw.WriteLine("*********************************************************************************");
            sw.WriteLine("*********************************************************************************");
            sw.WriteLine($"Имя класса: {currentClassName}. Имя сборки: {assemblyName}");
            sw.WriteLine("-------------------------------------------------");
            sw?.Close();
        }

        //b. есть ли публичные конструкторы;
        public static void WritePublicConstructors(string currentClassName)
        {
            sw = new StreamWriter(@"C:\University\3_cем\ОOП\Lab11\Lab11\ClassInfo.txt", true);
            Type currentClass = Type.GetType(currentClassName, true, true);

            foreach (var item in currentClass.GetConstructors(BindingFlags.Public | BindingFlags.Instance))
            {
                if (item.IsPublic)
                    sw.WriteLine($"Содержит общедоступный конструктор: {item.ToString()}");
                else
                    sw.WriteLine($"Не содержит публичных конструкторов");
            }
            sw.WriteLine("-------------------------------------------------");
            sw?.Close();
        }

        public static void WritePublicMethods(string currentClassName)
        {
            sw = new StreamWriter(@"C:\University\3_cем\ОOП\Lab11\Lab11\ClassInfo.txt", true);
            Type currentClass = Type.GetType(currentClassName, true, true);

            IEnumerable<string> publicMethod = new List<string>(GetPublicMethods(currentClass));
            sw.WriteLine("Список общедоступных методов: ");
            foreach (string item in publicMethod)
                sw.WriteLine(item);
            sw.WriteLine("-------------------------------------------------");
            sw?.Close();
        }
        public static void WriteFieldsAndProperties(string currentClassName)
        {
            sw = new StreamWriter(@"C:\University\3_cем\ОOП\Lab11\Lab11\ClassInfo.txt", true);
            Type currentClass = Type.GetType(currentClassName, true, true);

            IEnumerable<MemberInfo[]> FieldsAndProperties = new List<MemberInfo[]>(GetFieldsAndProperties(currentClass));
            sw.WriteLine("Список полей и свойств");
            foreach (var item in FieldsAndProperties)
                foreach(var i in item)
                    sw.WriteLine(i.ToString());

            sw.WriteLine("-------------------------------------------------");
            sw?.Close();
        }

        public static void WriteInterfaces(string currentClassName)
        {
            sw = new StreamWriter(@"C:\University\3_cем\ОOП\Lab11\Lab11\ClassInfo.txt", true);
            Type currentClass = Type.GetType(currentClassName, true, true);
            IEnumerable<string> interfaces = new List<string>(GetInterfaces(currentClass));
            sw.WriteLine("Список методов интерфейсов: ");
            foreach (string item in interfaces)
                sw.WriteLine(item);
            sw.WriteLine("-------------------------------------------------");
            sw?.Close();
        }
        public static void WriteMethodsWithUserParametr(string currentClassName, string parametr)
        {
            sw = new StreamWriter(@"C:\University\3_cем\ОOП\Lab11\Lab11\ClassInfo.txt", true);
            Type currentClass = Type.GetType(currentClassName, true, true);
            IEnumerable<string> methodsWithUserParametr =
                new List<string>(GetMethodsWithUserParametr(currentClass, parametr));
            sw.WriteLine($"Методы с заданным параметром ({parametr}):");
            if (methodsWithUserParametr.Count() != 0)
            {
                foreach (string item in methodsWithUserParametr)
                    sw.WriteLine(item);
            }
            else
                sw.WriteLine("Отсутсвуют");
            sw.WriteLine("-------------------------------------------------");
            sw?.Close();
        }

        /*c. извлекает все общедоступные публичные методы класса
        (возвращает IEnumerable<string>);*/
        private static IEnumerable<string> GetPublicMethods(Type CurrentClass)
        {
            var publicMethods = new List<string>();
            foreach (var item in CurrentClass.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                if (item.IsPublic)
                    publicMethods.Add(item.ToString());
            return publicMethods;
        }

        /*d. получает информацию о полях и свойствах класса (возвращает 
        IEnumerable<string>);*/
        private static IEnumerable<MemberInfo[]> GetFieldsAndProperties(Type CurrentClass)
        {
            return new List<MemberInfo[]> 
            { CurrentClass.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic), CurrentClass.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic) };
        }
        /*e. получает все реализованные классом интерфейсы (возвращает 
        IEnumerable<string>);*/
        private static IEnumerable<string> GetInterfaces(Type CurrentClass)
        {
            var interfaces = new List<string>();
            foreach (var item in CurrentClass.GetInterfaces())
                if (item.IsPublic)
                    interfaces.Add(item.ToString());
            return interfaces;
        }

        /*f. выводит по имени класса имена методов, которые содержат заданный (пользователем) тип параметра 
         * (имя класса передается в качестве аргумента);*/
        private static IEnumerable<string> GetMethodsWithUserParametr(Type CurrentClass, string userParametr)
        {
            var methodsWithParameters = new List<string>();
            var currentClassMethods = CurrentClass.GetMethods();

            foreach (var item in currentClassMethods)
            {
                var parameter = item.GetParameters();

                if (parameter.Any(param => param.Name == userParametr))
                    methodsWithParameters.Add(item.ToString());
            }
            return methodsWithParameters;
        }

        /*g. метод Invoke, который вызывает метод класса, при этом значения 
        для его параметров необходимо 1) прочитать из текстового файла 
        (имя класса и имя метода передаются в качестве аргументов) 2) 
        сгенерировать, используя генератор значений для каждого типа.
        Параметрами метода Invoke должны быть : объект, имя метода, 
        массив параметров.*/
        public static void Invoke(string className, string methodName)
        {
            try
            {
                object obj = Activator.CreateInstance(Type.GetType(className));
                var method = Type.GetType(className).GetMethod(methodName);
                List<string> list = File.ReadAllLines(@"C:\University\3_cем\ОOП\Lab11\Lab11\invoke.txt").ToList();
                List<string>[] list2 = new List<string>[] { list };
                method.Invoke(obj, list2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ClearFile()
        {
            using (sw = new StreamWriter(@"C:\University\3_cем\ОOП\Lab11\Lab11\ClassInfo.txt", false))
            {
                sw.WriteLine("");
            }
            sw.Close();
        }

        /* 2. Добавьте в Reflector обобщенный метод Create, который создает объект
        переданного типа (на основе имеющихся публичных конструкторов) и возвращает
        его пользователю.*/
        public static object Create(string currentClassName)
        {
            return Activator.CreateInstance(Type.GetType(currentClassName));
        }
    }
}
