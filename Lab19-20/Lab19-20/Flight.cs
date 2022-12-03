using System;

namespace Lab19_20
{
    public class Flight : ITravel
    {
        public int FlightNumber { get; set; }
        public string Wherefrom { get; set; }
        public string Where { get; set; }
        public DateTime DepartureTime { get; set; }
        public string PlaneModel { get; set; }
        public int FreeSeatsCount { get; set; }
        public double TicketStartPrice { get; set; }

        public Flight()
        {
            FlightNumber = 0;
            Wherefrom = "";
            Where = "";
            DepartureTime = new DateTime();
            PlaneModel = "";
            FreeSeatsCount = 0;
            TicketStartPrice = 0;

        }
        public Flight(int flightNum, string wherefrom, string where, DateTime departureTime, string planeModel, int freeSeats, double ticketStartPrice)
        {
            FlightNumber = flightNum;
            Wherefrom = wherefrom;
            Where = where;
            DepartureTime = departureTime;
            PlaneModel = planeModel;
            FreeSeatsCount = freeSeats;
            TicketStartPrice = ticketStartPrice;
        }

        //Adapter
        public void Fly()
        {
            Console.WriteLine($"Летим в самолёте");
        }

        //State
        public void Add(Flight flight)
        {
            Console.WriteLine($"Рейс номер {flight.FlightNumber} {flight.Wherefrom} - {flight.Where} успешно добавлен");
        }

        public void Сanceled(Flight flight)
        {
            Console.WriteLine($"Рейс номер {flight.FlightNumber} {flight.Wherefrom} - {flight.Where} успешно отменён");
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////
        public Flight Clone() => new Flight(FlightNumber, Wherefrom, Where, DepartureTime, PlaneModel, FreeSeatsCount, TicketStartPrice);
        public override bool Equals(object obj)
        {
            var fl = obj as Flight;
            if (fl.DepartureTime == DepartureTime && fl.PlaneModel == PlaneModel
                && fl.TicketStartPrice == TicketStartPrice && fl.Where == Where && fl.Wherefrom == Wherefrom)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return $"Номер рейса: {FlightNumber}\n Откуда: {Wherefrom}\n куда: {Where}\n Дата и время отправления: {DepartureTime}\n Модель самолёта {PlaneModel}\n Свободные места: {FreeSeatsCount}";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
