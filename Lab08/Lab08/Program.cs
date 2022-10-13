using System;

namespace Lab08
{
    class Program
    {
        static void Main(string[] args)
        {

            Software firstSoft = new Software("Visual Studio");
            Software secondSoft = new Software("Multisim");
            Software thirdSoft = new Software("Matlab");

            User.WorkWithSoft(firstSoft);
            firstSoft.ShowInfo();
            secondSoft.ShowInfo();
            thirdSoft.ShowInfo();
            Console.WriteLine();
            User.WorkWithSoft(secondSoft);
            firstSoft.ShowInfo();
            secondSoft.ShowInfo();
            thirdSoft.ShowInfo();
            Console.WriteLine();
            User.EndWorkWithSoft(secondSoft);
            User.UpgradeVersion(thirdSoft, "3.0");
            firstSoft.ShowInfo();
            secondSoft.ShowInfo();
            thirdSoft.ShowInfo();
            Console.WriteLine();

            /*Используя стандартные типы делегатов 
            (Action, Func, Predicate) организуйте алгоритм последовательной обработки 
            строки написанными вами методами. Везде где возможно использовать лямбда-выражения.*/
            Console.WriteLine("-----------------------------------------------------------------------");
            EditString.str = "Стр:Ока!      , пРо;с?ТО ..    .., стр;ока,?";
            Action stringEdit = () => EditString.RemovePunctuation();
            stringEdit += () => EditString.ToUpperCase();
            stringEdit += () => EditString.ToLowerCase();
            stringEdit += () => EditString.RemoveSpaces();
            stringEdit += () => EditString.AddQuestion();
            stringEdit?.Invoke();
            
        }
    }
}
