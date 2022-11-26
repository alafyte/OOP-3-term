using System;

namespace Lab17_18
{
    /*2) Создание и изменение объектов приложения сделайте на основе
    Abstract Factory и Builder. Можно добавить функцию генерации n
    случайно заполненных объектов через запрос. */
    public interface AbstractFactory
    {
        void CountPrice(float luggage);
        Flight CreateFlightInfo();

    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    public abstract class FlightBuilder
    {
        public Flight Flight = new Flight();
        public abstract void SetID(int id);
        public abstract void SetWhereFrom(string wherefrom);
        public abstract void SetWhere(string where);
        public abstract void SetDepartureTime(DateTime dateTime);
        public abstract void SetPlaneMode(string model);
        public abstract void SetFreeSeatsCount(int count);
        public abstract void SetTicketStartPrice(double startPrice);
    }

    public class PassengerFlightBuilder : FlightBuilder
    {
        public override void SetID(int id)
        {
            Flight.FlightNumber = id;
        }
        public override void SetWhereFrom(string wherefrom)
        {
            Flight.Wherefrom = wherefrom;
        }
        public override void SetWhere(string where)
        {
            Flight.Where = where;
        }
        public override void SetDepartureTime(DateTime dateTime)
        {
            Flight.DepartureTime = dateTime;
        }
        public override void SetPlaneMode(string model)
        {
           Flight.PlaneModel = model;
        }
        public override void SetFreeSeatsCount(int count)
        {
            Flight.FreeSeatsCount = count;
        }
        public override void SetTicketStartPrice(double startPrice)
        {
            Flight.TicketStartPrice = startPrice;
        }
    }

    public class Administrator
    {
        public Flight Create(FlightBuilder flightBuilder, int id, string wherefrom, string where, DateTime departureTime, string planeModel, int freeSeats, double ticketStartPrice)
        {
            flightBuilder.SetID(id);
            flightBuilder.SetWhereFrom(wherefrom);
            flightBuilder.SetWhere(where);
            flightBuilder.SetDepartureTime(departureTime);
            flightBuilder.SetPlaneMode(planeModel);
            flightBuilder.SetFreeSeatsCount(freeSeats);
            flightBuilder.SetTicketStartPrice(ticketStartPrice);
            return flightBuilder.Flight;
        }
    }
}
