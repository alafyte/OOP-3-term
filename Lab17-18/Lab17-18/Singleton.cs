using System;

namespace Lab17_18
{
    /*3) Создайте пользовательский тип, который хранит настройки 
        приложения (цвет фона, шрифт, размер и т.п.) и сделайте его 
        Singleton*/
    public sealed class Singleton
    {
        private static Singleton instance;
        private static object syncRoot = new object();
        public string settings;
        public ConsoleColor ForegroundColor { get; private set; }
        public ConsoleColor BackgroundColor { get; private set; }
        private Singleton(string settings, ConsoleColor forColor, ConsoleColor backColor)
        {
            this.settings = settings;
            ForegroundColor = forColor;
            BackgroundColor = backColor;
        }
        public static Singleton GetInstance(string settings, ConsoleColor forColor, ConsoleColor backColor)
        {
            if (instance == null)
                lock (syncRoot)
                {
                    instance = new Singleton(settings, forColor, backColor);
                }
            return instance;
        }
    }
}
