using System;

namespace Lab19_20
{
    //Паттерн Decorator (создайте различные представления объектов - расширенный интерфейс)
    class Decorator : Flight
    {
        protected Flight Flight { get; set; }
        public Decorator(int flightNum, string wherefrom, string where, DateTime departureTime, string planeModel, int freeSeats, double ticketStartPrice, Flight flight) 
            : base(flightNum, wherefrom, where, departureTime, planeModel, freeSeats, ticketStartPrice)
        {
            Flight = flight;
        }
    }

    class FlightWithAirport : Decorator
    {
        public FlightWithAirport(string airport1, string airport2, Flight flight) 
            : base(flight.FlightNumber, flight.Wherefrom + " - " + airport1, flight.Where + " - " + airport2, flight.DepartureTime, 
                  flight.PlaneModel, flight.FreeSeatsCount, flight.TicketStartPrice, flight)
        {

        }
    }
}
