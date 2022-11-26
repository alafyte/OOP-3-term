using System;
using System.Collections.Generic;

namespace Lab17_18
{
    class Program
    {
        static void Main(string[] args)
        {
            Administrator admin = new Administrator();
            FlightBuilder flightBuilder = new PassengerFlightBuilder();
            List<Flight> flights = new List<Flight>()
            {
                new Flight(1, "Вильнюс", "Лондон", new DateTime(2022, 12, 12, 18, 25, 00), "Boeing 737", 200, 250.23),
                new Flight(2, "Пекин", "Нью-Йорк", new DateTime(2022, 12, 21, 20, 30, 00), "Boeing 737", 210, 373.66),
                new Flight(3, "Москва", "Милан", new DateTime(2023, 1, 3, 12, 00, 00), "Boeing 737", 190, 251.43),
                new Flight(4, "Барселона", "Берлин", new DateTime(2023, 1, 15, 1, 01, 00), "Boeing 737", 214, 230),
                new Flight(5, "Стамбул", "Минск", new DateTime(2023, 1, 27, 5, 14, 00), "Boeing 737", 189, 240.34),
                new Flight(6, "Варшава", "Токио", new DateTime(2023, 2, 3, 13, 37, 00), "Boeing 737", 160, 393.21),
                new Flight(7, "Минск", "Вильнюс", new DateTime(2023, 2, 14, 7, 48, 00), "Boeing 737", 125, 202.12),
                new Flight(8, "Берлин", "Вашингтон", new DateTime(2023, 3, 1, 19, 56, 00), "Boeing 737", 135, 350.86),
                new Flight(9, "Прага", "Веллингтон", new DateTime(2023, 3, 18, 3, 12, 00), "Boeing 737", 178, 400.45),
                new Flight(10, "Торонто", "Лос-Анжелес", new DateTime(2023, 3, 16, 18, 45, 00), "Boeing 737", 201, 350.34),
            };

            string name, passportData;
            DateTime dateOfBirth = new DateTime();

            Console.WriteLine("Добро пожаловать на официальный сайт компании AirLow!\n" +
                "--- Пройдите регистрацию ---");
            try
            {
                Console.Write("Введите ФИО: ");
                name = Console.ReadLine();
                Console.Write("\nВведите день рождения: ");
                dateOfBirth.AddDays(double.Parse(Console.ReadLine()));
                Console.Write("\nВведите месяц рождения: ");
                dateOfBirth.AddMonths(int.Parse(Console.ReadLine()));
                Console.Write("\nВведите год рождения: ");
                dateOfBirth.AddYears(int.Parse(Console.ReadLine()));
                Console.Write("\nВведите серию и номер пасспорта: ");
                passportData = Console.ReadLine();
                Client client = new Client(name, dateOfBirth, passportData);
                bool exit = true;
                while (exit)
                {
                    Console.WriteLine("Выберите действие: \n" +
                    "1 - установить вес багажа\n" +
                    "2 - просмотреть доступные рейсы\n" +
                    "3 - сделать заказ\n" +
                    "4 - просмотреть список своих заказов\n" +
                    "5 - отменить заказ\n" +
                    "6 - выход");

                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            {
                                Console.WriteLine("Введите вес:");
                                float weight = float.Parse(Console.ReadLine());
                                client.SetLuggageWeight(weight);
                                continue;
                            }
                        case 2:
                            {
                                foreach (var f in flights)
                                    Console.WriteLine(f.ToString());
                                continue;
                            }
                        case 3:
                            {
                                Console.WriteLine("Введите номер рейса:");
                                int flNumber = int.Parse(Console.ReadLine());
                                client.MakeOrder(flights[flNumber - 1]);
                                continue;
                            }
                        case 4:
                            {
                                client.ShowListOfOrders();
                                continue;
                            }
                        case 5:
                            {
                                Console.WriteLine("Введите номер рейса, заказ на который хотите отменить:");
                                int flNumber = int.Parse(Console.ReadLine());
                                client.CancelOrder(flights[flNumber - 1]);
                                continue;
                            }
                        default:
                            exit = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка!");
            }
        }
    }
}
