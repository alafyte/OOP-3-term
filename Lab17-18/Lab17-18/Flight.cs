using System;

namespace Lab17_18
{
    public class Flight : Prototype
    {
        public string Wherefrom { get; set; }
        public string Where { get; set; }
        public DateTime DepartureTime { get; set; }
        public string PlaneModel { get; set; }
        public int FreeSeatsCount { get; set; }
        public double TicketStartPrice { get; set; }

        public Flight() : base(0)
        {
            Wherefrom = "";
            Where = "";
            DepartureTime = new DateTime();
            PlaneModel = "";
            FreeSeatsCount = 0;
            TicketStartPrice = 0;

        }
        public Flight(int flightNum, string wherefrom, string where, DateTime departureTime, string planeModel, int freeSeats, double ticketStartPrice) :base(flightNum)
        {
            Wherefrom = wherefrom;
            Where = where;
            DepartureTime = departureTime;
            PlaneModel = planeModel;
            FreeSeatsCount = freeSeats;
            TicketStartPrice = ticketStartPrice;
        }
        public override Prototype Clone() => new Flight(FlightNumber, Wherefrom, Where, DepartureTime, PlaneModel, FreeSeatsCount, TicketStartPrice);
        public override bool Equals(object obj)
        {
            var fl = obj as Flight;
            if (fl.DepartureTime == this.DepartureTime && fl.PlaneModel == this.PlaneModel
                && fl.TicketStartPrice == this.TicketStartPrice && fl.Where == this.Where && fl.Wherefrom == this.Wherefrom)
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
