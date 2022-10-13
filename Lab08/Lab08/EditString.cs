using System.Text.RegularExpressions;
using System;

namespace Lab08
{
    /*2. Создайте пять методов пользовательской обработки строки (например,
     удаление знаков препинания, добавление символов, замена на заглавные, 
     удаление лишних пробелов и т.п.). И*/
    public static class EditString
    {
        public static string str { get; set; }
        public static void RemovePunctuation()
        {
            str = Regex.Replace(str, @"[,.:;!?-]", "");
            Console.WriteLine(str);
        }

        public static void ToUpperCase()
        {
            str = str.ToUpper();
            Console.WriteLine(str);
        }

        public static void ToLowerCase()
        {
            str = str.ToLower();
            Console.WriteLine(str);
        }

        public static void RemoveSpaces()
        {
            str = Regex.Replace(str, @"(\s)+", " ");
            Console.WriteLine(str);
        }

        public static void AddQuestion()
        {
            str = str.Insert(str.Length, "?");
            Console.WriteLine(str);
        }
    }
}
