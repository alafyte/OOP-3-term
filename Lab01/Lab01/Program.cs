using System;
using System.Text;
using System.Linq;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {

            //ТИПЫ
            /*a. Определите переменные всех возможных примитивных типов С# и проинициализируйте их.
             * Осуществите ввод и вывод их значений используя консоль. 
             */
            bool var1 = false;
            byte var2 = 35;
            sbyte var3 = 126;
            char var4 = 'a';
            decimal var5 = 16m;
            double var6 = 1.56d;
            float var7 = 13.78f;
            int var8 = -25;
            uint var9 = 6723939;
            nint var10 = 11022;
            nuint var11 = 192346789;
            long var12 = -2020202020203984;
            ulong var13 = 292930;
            short var14 = -18283;
            ushort var15 = 1929;
            string var16 = "Hello, World!";
            object var17 = 67;

            Console.WriteLine("Вывод значений переменных:");
            Console.WriteLine($"bool    - {var1}\n" +
                              $"byte    - {var2}\n" +
                              $"sbyte   - {var3}\n" +
                              $"char    - {var4}\n" +
                              $"decimal - {var5}\n" +
                              $"double  - {var6}\n" +
                              $"float   - {var7}\n" +
                              $"int     - {var8}\n" +
                              $"uint    - {var9}\n" +
                              $"nint    - {var10}\n" +
                              $"nuint   - {var11}\n" +
                              $"long    - {var12}\n" +
                              $"ulong   - {var13}\n" +
                              $"short   - {var14}\n" +
                              $"ushort  - {var15}\n" +
                              $"string  - {var16}\n" +
                              $"object  - {var17}\n"
                              );

            Console.WriteLine("Ввод значений переменных: ");
            Console.Write("bool: ");
            var1 = bool.Parse(Console.ReadLine());
            Console.Write("byte: ");
            var2 = byte.Parse(Console.ReadLine());
            Console.Write("sbyte: ");
            var3 = sbyte.Parse(Console.ReadLine());
            Console.Write("char: ");
            var4 = char.Parse(Console.ReadLine());
            Console.Write("decimal: ");
            var5 = decimal.Parse(Console.ReadLine());
            Console.Write("double: ");
            var6 = double.Parse(Console.ReadLine());
            Console.Write("float: ");
            var7 = float.Parse(Console.ReadLine());
            Console.Write("int: ");
            var8 = int.Parse(Console.ReadLine());
            Console.Write("uint: ");
            var9 = uint.Parse(Console.ReadLine());
            Console.Write("nint: ");
            var10 = nint.Parse(Console.ReadLine());
            Console.Write("nuint: ");
            var11 = nuint.Parse(Console.ReadLine());
            Console.Write("long: ");
            var12 = long.Parse(Console.ReadLine());
            Console.Write("ulong: ");
            var13 = ulong.Parse(Console.ReadLine());
            Console.Write("short: ");
            var14 = short.Parse(Console.ReadLine());
            Console.Write("ushort: ");
            var15 = ushort.Parse(Console.ReadLine());
            Console.Write("string: ");
            var16 = Console.ReadLine();
            Console.Write("object: ");
            var17 = Console.ReadLine();

            Console.WriteLine($"bool    - {var1}\n" +
                             $"byte    - {var2}\n" +
                             $"sbyte   - {var3}\n" +
                             $"char    - {var4}\n" +
                             $"decimal - {var5}\n" +
                             $"double  - {var6}\n" +
                             $"float   - {var7}\n" +
                             $"int     - {var8}\n" +
                             $"uint    - {var9}\n" +
                             $"nint    - {var10}\n" +
                             $"nuint   - {var11}\n" +
                             $"long    - {var12}\n" +
                             $"ulong   - {var13}\n" +
                             $"short   - {var14}\n" +
                             $"ushort  - {var15}\n" +
                             $"string  - {var16}\n" +
                             $"object  - {var17}\n"
                             );

            /*b. Выполните 5 операций явного и 5 неявного приведения. Изучите возможности класса Convert.*/

            //Явное преобразование
            short var20 = 1245;
            int var21 = (int)var20;
            byte var22 = (byte)var21;
            char var23 = (char)var22;
            double var24 = (double)var23;

            Console.WriteLine("Явное преобразование: ");
            Console.WriteLine($"short   - {var20}\n" +
                              $"int     - {var21}\n" +
                              $"byte    - {var22}\n" +
                              $"char    - {var23}\n" +
                              $"double  - {var24}\n"
                           );


            //Неявное преобразование
            char var25 = 'n';
            ushort var26 = var25;
            int var27 = var26;
            float var28 = var27;
            double var29 = var28;

            Console.WriteLine("Неявное преобразование: ");
            Console.WriteLine($"char    - {var25}\n" +
                              $"ushort  - {var26}\n" +
                              $"int     - {var27}\n" +
                              $"float   - {var28}\n" +
                              $"double  - {var29}\n"
                           );

            //Класс Convert 
            Console.WriteLine("Класс Convert: ");
            int var30 = 1893;
            double var31 = Convert.ToDouble(var30);
            Console.WriteLine($"int     - {var30}\n" +
                              $"double  - {var31}\n"
                          );

            //c. Выполните упаковку и распаковку значимых типов
            long var32 = 18829440050;
            object var33 = var32;
            var32 = (long)var33;

            //d. Продемонстрируйте работу с неявно типизированной переменной.
            var var34 = "Maxim";
            Console.WriteLine($"Hello,  {var34}");

            //e. Продемонстрируйте пример работы с Nullable переменной
            int? var35 = null;
            if (var35.HasValue)
                Console.WriteLine(var35.Value);
            else
                Console.WriteLine("var35 равен null");

            /*f. Определите переменную типа var и присвойте ей любое значение.
             * Затем следующей инструкцией присвойте ей значение другого типа. Объясните причину ошибки
            */

            //var var36 = 4;
            //var36 = 3.5f;
            //Console.WriteLine($"{var36}");


            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //СТРОКИ
            //а. Объявите строковые литералы. Сравните их.
            string str1 = "Hello";
            string str2 = "World";

            Console.WriteLine("--------------------------------------------------------------");
            if (str1 == str2)
                Console.WriteLine($"Строка {str1} равна {str2}");
            else
                Console.WriteLine($"Строка {str1} не равна {str2}");

            /*b. Создайте три строки на основе String. Выполните: сцепление, копирование, выделение подстроки,
             * разделение строки на слова, вставки подстроки в заданную позицию, удаление заданной
               подстроки. Продемонстрируйте интерполирование строк.*/
            String str3 = "First";
            String str4 = "Second";
            String str5 = "Third";
            String strBuff;
            String str6 = "Many words  in one string";

            Console.WriteLine($"Сцепление: {str3 + str4}");

            strBuff = str4;
            Console.WriteLine($"Копирование: {strBuff}");

            Console.WriteLine($"Выделение подстроки (с 1 по 3 позицию из строки 'Third'): {str5.Substring(1, 3)}");

            Console.WriteLine("Разделение на слова: ");
            String[] wordsFromString = str6.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (String s in wordsFromString)
                Console.WriteLine(s);

            Console.WriteLine($"\nВставка в заданную позицию (строку Second в строку First со 2 позиции): {str3.Insert(2, str4)}");
            Console.WriteLine($"Удаление подстроки (с 0 по 11 символ из строки 'Many words in one string'): {str6.Remove(0, 11)}");

            /*c. Создайте пустую и null строку. Продемонстрируйте использование метода string.IsNullOrEmpty.
             * Продемонстрируйте что еще можно выполнить с такими строками*/
            string str7 = "";
            string str8 = null;
            string str9 = "   \t   ";

            if (String.IsNullOrEmpty(str7))
                Console.WriteLine("Str7 пустая или null-строка");
            else
                Console.WriteLine("Str7 не null-строка или не пустая");


            if (String.IsNullOrEmpty(str8))
                Console.WriteLine("Str8 пустая или null-строка");
            else
                Console.WriteLine("Str8 не null-строка или не пустая");

            if (String.IsNullOrEmpty(str9))
                Console.WriteLine("Str9 пустая или null-строка");
            else
                Console.WriteLine("Str9 не null-строка или не пустая");

            if (String.IsNullOrWhiteSpace(str7))
                Console.WriteLine("Str7 пустая или null-строка или строка из пробелов");
            else
                Console.WriteLine("Str7 не null-строка или не пустая");

            if (String.IsNullOrWhiteSpace(str8))
                Console.WriteLine("Str8 пустая или null-строка или строка из пробелов");
            else
                Console.WriteLine("Str8 не null-строка или не пустая");

            if (String.IsNullOrWhiteSpace(str9))
                Console.WriteLine("Str9 пустая или null-строка или строка из пробелов");
            else
                Console.WriteLine("Str9 не null-строка или не пустая");
            /*d. Создайте строку на основе StringBuilder. Удалите определенные позиции и добавьте 
             * новые символы в начало и конец строки. */

            StringBuilder str10 = new StringBuilder(" an old");
            str10.Remove(2, 5);
            str10.Insert(0, "This is");
            str10.Append(" new string");
            Console.WriteLine(str10);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //МАССИВЫ
            //a. Создайте целый двумерный массив и выведите его на консоль в отформатированном виде (матрица). 
            int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };

            Console.WriteLine("\n\nМатрица:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }

            /*b. Создайте одномерный массив строк. Выведите на консоль его содержимое, длину массива. Поменяйте произвольный элемент
            (пользователь определяет позицию и значение).*/

            Console.WriteLine();

            string[] stringArray = { "First", "Second", "Third", "Fourth" };
            foreach (string str in stringArray)
                Console.Write($"{str}\t");
            Console.WriteLine($"\nДлина массива: {stringArray.Length}");

            Console.WriteLine($"Введите позицию замены (от 0 до {stringArray.Length - 1}):");
            int position = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите новую строку:");
            string newString = Console.ReadLine();

            stringArray[position] = newString;

            Console.WriteLine("Новый массив: ");
            foreach (string str in stringArray)
                Console.Write($"{str}\t");

            /*c. Создайте ступечатый (не выровненный) массив вещественных чисел с 3-мя строками, 
             * в каждой из которых 2, 3 и 4 столбцов соответственно. Значения массива введите с консоли.*/

            float[][] array1 = new float[3][];
            array1[0] = new float[2];
            array1[1] = new float[3];
            array1[2] = new float[4];

            Console.WriteLine("\nВведите элементы массива: ");
            for (var i = 0; i < array1.Length; i++)
            {
                for (var j = 0; j < array1[i].Length; j++)
                    array1[i][j] = float.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            Console.WriteLine("Массив: ");
            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array1[i].Length; j++)
                {
                    Console.Write($"{array1[i][j]} \t");
                }
                Console.WriteLine();
            }

            //d. Создайте неявно типизированные переменные для хранения массива и строки.
            var array2 = new[] { 1.5, 2.87, 3.23, 4.1 };
            var string1 = "abcdefgh";

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //КОРТЕЖИ
            //a.Задайте кортеж из 5 элементов с типами int, string, char, string, ulong.

            (int, string, char, string, ulong) myTuple = (-4, "Hello", 'a', "World", 199388384848);
            (int, string, char, string, ulong) myTuple1 = (235, "Goodbye", 'l', "World", 23423200201);

            //b. Выведите кортеж на консоль целиком и выборочно ( например 1, 3, 4 элементы)
            Console.WriteLine("Кортеж: ");
            Console.WriteLine(myTuple);
            Console.WriteLine("Элементы кортежа (1, 3, 4): ");
            Console.WriteLine(myTuple.Item1);
            Console.WriteLine(myTuple.Item3);
            Console.WriteLine(myTuple.Item4);

            /*c. Выполните распаковку кортежа в переменные. Продемонстрируйте различные способы распаковки кортежа.
            Продемонстрируйте использование переменной(_).*/
            var firstItem = myTuple.Item1;
            var secondItem = myTuple.Item2;
            var thirdItem = myTuple.Item3;
            var fourthItem = myTuple.Item4;
            var fifthItem = myTuple.Item5;

           var (item1, item2, tem3, item4, item5) = myTuple1;

            (int, float) newTuple = (-43, 7.8f);
            (int intVar, float floatVar) = newTuple;

            var (_, string11, _, string12, _) = (-4, "Hello", 'a', "World", 199388384848);

            //d. Сравните два кортежа.
            if (myTuple == myTuple1)
                Console.WriteLine("Кортежи равны");
            else
                Console.WriteLine("Кортежи не равны");

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //ЛОКАЛЬНАЯ ФУНКЦИЯ
            int[] arr = { 1, 2, 3, 4, 5, 6 };

            (int maxV, int minV, int sum, char letter) = myFunc(arr, string1);

  
            Console.WriteLine($"\nМаксимальный элемент массива: {maxV}\n" +
                              $"Минимальный элемент массива: {minV}\n" +
                              $"Сумма всех элементов массива: {sum}\n" +
                              $"Первая буква строки: {letter}\n");


            static (int, int, int, char ) myFunc (int[] arr , string str)
            {
                int max = arr.Max();
                int min = arr.Min();
                int sum = arr.Sum();
                char s = str[0];

                return (max, min, sum, s);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //checked/unchecked

            try
            {
                firstChecked();
            }
            catch(OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            secondUnchecked();

            static void firstChecked()
            {
                checked
                {
                    int maxVal1 = int.MaxValue;
                    maxVal1++;
                    Console.WriteLine(maxVal1);
                }

            }

            static void secondUnchecked()
            {
                unchecked
                {
                    int maxVal2 = int.MaxValue;
                    maxVal2++;
                    Console.WriteLine(maxVal2);
                }
            }

        } 
    }
}
