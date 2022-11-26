using System;
using System.Collections.Generic;

namespace Lab17_18
{
    public class Client
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
