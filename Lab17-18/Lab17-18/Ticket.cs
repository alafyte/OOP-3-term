using System;

namespace Lab17_18
{
    public class Ticket : AbstractFactory
    {
        protected const float luggageLimit = 10;
        protected const double overweightCost = 20.0;
        public double CurrentPrice { get; set; }
        public DateTime DateOfOrder { get; set; }
        public Flight Flight { get; set; }
        public Ticket(DateTime dateOfOrder, Flight flight, float luggage)
        {
            CurrentPrice = flight.TicketStartPrice;
            DateOfOrder = dateOfOrder;
            Flight = flight.Clone() as Flight;
            CountPrice(luggage);
            flight.FreeSeatsCount--;
        }
        public Flight CreateFlightInfo()
        {
            return Flight;
        }

        public void CountPrice(float luggage)
        {
            double margin = Convert.ToDouble(Flight.DepartureTime.Subtract(DateOfOrder).Days) / 5;
            if (margin != 0)
                CurrentPrice = Flight.TicketStartPrice + Flight.TicketStartPrice / margin;
            if (luggage > luggageLimit)
            {
                double overweight = (luggage - luggageLimit) * overweightCost;
                //За каждый кг перевеса багажа + 20$
                CurrentPrice += overweight;
            }
           CurrentPrice = Math.Round(CurrentPrice, 2, MidpointRounding.AwayFromZero);
        }

        public override string ToString()
        {
            return $"Рейс:\n {Flight.ToString()}, цена билета: {CurrentPrice}, дата заказа: {DateOfOrder}";
        }
    }
}
