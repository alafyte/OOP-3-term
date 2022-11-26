
namespace Lab17_18
{
    /*4) Добавьте функцию создания клона объекта на основе шаблона 
    Prototype*/
    public abstract class Prototype
    {
        public int FlightNumber { get; set; }
        public Prototype(int id)
        {
            FlightNumber = id;
        }
        public abstract Prototype Clone();
    }
}
