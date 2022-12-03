using System;

namespace Lab19_20
{
    public interface IBus
    {
        public void Drive();
    }
    //Bus является адаптируемым под интерфейс ITravel
    public class Bus : IBus, IMovable
    {
        public string BusBrand { get; set; }
        private int BusNumber { get; set; }
        public IMovable Movable { private get; set; }

        //Adapter
        public void Drive()
        {
            Console.WriteLine("Едем в автобусе");
        }

        //Strategy
        public void Move()
        {
            Movable.Move();
        }

        public Bus()
        {
            BusBrand = "Default";
            BusNumber = 100;
        }

        public Bus(string driverName, int busNumber, IMovable movable)
        {
            BusBrand = driverName;
            BusNumber = busNumber;
            Movable = movable;
        }
    }

    //Интерфейс выступает в качестве IStrategy
    public interface IMovable
    {
        void Move();
    }

    //Семейство алгоритмов для Strategy
    class PetrolMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на бензине");
        }
    }

    class ElectricMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на электричестве");
        }
    }
}
