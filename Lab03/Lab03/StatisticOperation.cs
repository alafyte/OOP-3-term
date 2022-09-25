using System;


namespace Lab03
{
    public static class StatisticOperation
    {
        /* Создайте статический класс StatisticOperation, содержащий 3 метода для 
        работы с вашим классом (по варианту п.1): сумма, разница между 
        максимальным и минимальным, подсчет количества элементов.*/
        public static string ConcatStrings(List list)
        {
            if (list.Head == null)
                throw new InvalidOperationException();

            var current = list.Head;
            var resultString = "";

            while (current != null)
            {
                resultString += current.Data;
                current = current.Next;
            }

            return resultString;
        }

        public static string LongestString(List list)
        {
            if (list.Head == null)
                throw new InvalidOperationException();

            var current = list.Head;
            var maxString = "";
            while (current != null)
            {
                if (current.Data.Length > maxString.Length)
                    maxString = current.Data;
                current = current.Next;

            }

            return maxString;
        }

        public static string ShortestString(this List list)
        {
            if (list.Head == null)
                throw new InvalidOperationException();

            var current = list.Head;
            var minString = current.Data;
            while (current != null)
            {
                if (current.Data.Length < minString.Length)
                    minString = current.Data;
                current = current.Next;
            }

            return minString;
        }

        public static int CountOfElements(List list)
        {
            if (list.Head == null)
                return 0;

            int count = 0;

            var current = list.Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }

            return count;
        }

        /*Добавьте к классу StatisticOperation методы расширения для типа string
        и вашего типа из задания №1. См. задание по вариантам. */
        public static void TruncString (this List list, int length, string str)
        {
            var current = list.Head;
            bool isStringIn = false;

            while (current != null)
            {
                if (current.Data == str)
                {
                    isStringIn = true;
                    current.Data = current.Data.Substring(0, length);
                }
                else
                    current = current.Next;
            }

            if (!isStringIn)
                Console.WriteLine("Такой строки нет в списке!");
        }

    }
}
