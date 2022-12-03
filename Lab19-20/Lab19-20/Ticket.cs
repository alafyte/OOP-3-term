using System;

namespace Lab19_20
{
    //Паттерн State (состояние объектов - сохраненный, редактируемый и т.п.)
    public interface ITicketState
    {
        void Ordered(Ticket ticket);
        void Paid(Ticket ticket);
    }
    public class Ticket
    {
        protected const float luggageLimit = 10;
        protected const double overweightCost = 20.0;
        public double CurrentPrice { get; set; }
        public DateTime DateOfOrder { get; set; }
        public Flight Flight { get; set; }
        public Ticket() { }
        public Ticket(DateTime dateOfOrder, Flight flight, float luggage)
        {
            CurrentPrice = flight.TicketStartPrice;
            DateOfOrder = dateOfOrder;
            Flight = flight.Clone();
            CountPrice(luggage);
            flight.FreeSeatsCount--;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ITicketState State { get; set; }

        public Ticket(ITicketState ts)
        {
            State = ts;
        }

        public void Ordered()
        {
            State.Ordered(this);
        }
        public void Paid()
        {
            State.Paid(this);
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////
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
            return $"Рейс:\n {Flight}, цена билета: {CurrentPrice}, дата заказа: {DateOfOrder}";
        }
    }
}
