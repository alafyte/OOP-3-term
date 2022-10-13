using System;

namespace Lab08
{
    /*1) Используя делегаты (множественные) и события промоделируйте 
    ситуации, приведенные в таблице ниже. Можете добавить новые типы (классы), 
    если существующих недостаточно. */

    public delegate void Upgrade(string str);
    public delegate void Work();
    class User
    {
        public static event Upgrade OnUpgrade;
        public static event Work StartWork;
        public static event Work EndWork;

        public static void WorkWithSoft(Software soft)
        {
            Console.WriteLine("Начинаю работу!");
            User.StartWork += soft.StartWork;
            StartWork?.Invoke();
        }
        public static void EndWorkWithSoft(Software soft)
        {
            Console.WriteLine("Завершаю работу...");
            User.EndWork += soft.EndWork;
            EndWork?.Invoke();
        }
        public static void UpgradeVersion(Software soft, string newVersion)
        {
            Console.WriteLine("Обновление...");
            User.OnUpgrade += soft.ChangeVersion;
            OnUpgrade?.Invoke(newVersion);
        }
    }
}
