using System;


namespace Lab08
{
    public class Software
    {
        public string Name { get; set; }
        public string Version { get; set; } = "1.0";
        public bool IsWorking { get; set; } = false;
        private Software() { }
        public Software(string name)
        {
            Name = name;
        }

        public void ShowInfo()
        {
            Console.Write($"Приложение {Name}, версия: {Version}. ");
            if (IsWorking)
                Console.WriteLine("Запущено");
            else
                Console.WriteLine("Не запущено");
        }

        public void StartWork() => IsWorking = true;
        public void EndWork() => IsWorking = false;
        public void ChangeVersion(string newVersion) => Version = newVersion;
    }

}
