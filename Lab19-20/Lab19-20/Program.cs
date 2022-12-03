using System;

namespace Lab19_20
{
    class Program
    {
        static void Main(string[] args)
        {
            /*1) Добавьте к лабораторной №17-18 два структурных паттерна. */

            Console.ForegroundColor = ConsoleColor.Green;
            Client client = new Client("Ivanov Ivan Ivanovich", new DateTime(1998, 9, 23), "JH67423");
            Flight flight = new Flight(6, "Варшава", "Токио", new DateTime(2023, 2, 3, 13, 37, 00), "Boeing 737", 160, 393.21);

            Console.WriteLine("---- Adapter ----");
            client.Travel(flight);

            Bus bus = new Bus();

            ITravel busToAirport = new Adapter(bus);
            client.Travel(busToAirport);

            /////////////////////////////////////////////////////////
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n---- Decorator ----");
            flight = new FlightWithAirport("Lotnisko Chopina w Warszawie", "Narita International Airport", flight);
            Console.WriteLine(flight.ToString());

            //2) Добавьте три паттерна поведения.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n---- State ----");
            client.MakeOrder(flight);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n---- Command ----");
            Flight flight1 = new Flight(4, "Барселона", "Берлин", new DateTime(2023, 1, 15, 1, 01, 00), "Boeing 737", 214, 230);
            Admin admin = new Admin();
            admin.SetCommand(new FlightOnCommand(flight1));
            admin.AddNewFlight();
            admin.CancelFlight();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n---- Strategy ----");
            Bus bus1 = new Bus("Mercedes", 1243, new PetrolMove());
            bus1.Move();
            bus1.Movable = new ElectricMove();
            bus1.Move();
        }
    }
}
