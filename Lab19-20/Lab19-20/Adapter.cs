namespace Lab19_20
{
    /*Паттерн Adapter (не меняем интерфейс исходного класса)*/

    //Адаптирует объекты Bus под интерфейс ITravel
    public class Adapter : ITravel
    {
        Bus Bus { get; set; }
        public Adapter(Bus bus)
        {
            Bus = bus;
        }
        
        public void Fly()
        {
            Bus.Drive();
        }
    }
}
