using System;
using System.Collections.Generic;

namespace Lab19_20
{
    public interface ITravel
    {
        public void Fly();
    }

    //Клиент использует объект ITravel для путешествий 
    public class Client : ITicketState
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PassportData { private get; set; }

        private float _luggageWeight;
        private List<Ticket> tickets;

        public Client(string name, DateTime dateOfBirth, string passportData)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            PassportData = passportData;
            tickets = new List<Ticket>();
        }

        //Adapter
        public void Travel(ITravel plane)
        {
            plane.Fly();
        }
        //State
        public void Ordered(Ticket ticket) => Console.WriteLine($"Билет на рейс {ticket.Flight.FlightNumber} заказан");
        public void Paid(Ticket ticket) => Console.WriteLine($"Билет на рейс {ticket.Flight.FlightNumber} оплачен");

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void SetLuggageWeight(float weight)
        {
            _luggageWeight = weight;
            Console.WriteLine($"Вес вашего багажа: {_luggageWeight}");
        }

        public void ShowListOfOrders()
        {
            if (tickets.Count == 0)
                Console.WriteLine("Список пуст!");
            else
                foreach (var i in tickets)
                    Console.WriteLine(i.ToString());
        }
        public void MakeOrder(Flight flight)
        {
            Ticket ticket = new Ticket(DateTime.Now, flight, _luggageWeight);
            Ordered(ticket);
            Paid(ticket);
            tickets.Add(ticket);
        }

        public void CancelOrder(Flight flight)
        {
            foreach(var t in tickets)
            {
                if (t.Flight.Equals(flight))
                {
                    tickets.Remove(t);
                    flight.FreeSeatsCount += 1;
                }
                if (tickets.Count == 0)
                    break;
            }
        }
    }
}
