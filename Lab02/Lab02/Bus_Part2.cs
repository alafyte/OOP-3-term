using System;

namespace Lab02
{
    public partial class Bus
    {
        //Добавить метод вывода возраста автобуса.

        public int BusAge()
        {
            int currentYear = DateTime.Now.Year;

            int busAge = currentYear - this.yearOfOpetationStart;
            return(busAge);
        }

        /*в одном из методов класса для работы с аргументами используйте ref -
        и out-параметры.*/
        public void IncreaseMileage (ref int transportMileage)
        {
            transportMileage++;
        }

        public void ChangeDriver (out string oldName, string newName)
        {
            oldName = newName;
        }

        //Создайте статический метод вывода информации о классе.
        public static void ShowClassInfo()
        {
            Console.WriteLine($"---- Поля класса ----\n" +
            $"busID\n" +
            $"driverName\n" +
            $"busNumber\n" +
            $"routeNumber\n" +
            $"busBrand\n" +
            $"yearOfOperationStart\n" +
            $"mileage\n" +
            $"---- Методы класса ----\n" +
            $"ShowClassInfo\n" +
            $"PrintBusAge\n" +
            $"IncreaseMileage\n" +
            $"ChangeDriver");
        }

        /*переопределите методы класса Object: Equals, для сравнения объектов,
        GetHashCode, ToString – вывода строки информации об объекте.*/

        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new NullReferenceException();

            Bus bus = obj as Bus;

            return bus.busID == this.busID;
        }
        public override int GetHashCode()
        {
            return (int)(this.busNumber * this.yearOfOpetationStart / this.RouteNum);
        }

        public override string ToString()
        {
            return $"ФИО водителя: {this.driverName}\n" +
               $"Серийный номер автобуса: {this.busNumber}\n" +
               $"ID автобуса: {this.busID}\n" +
               $"Номер маршрута: {this.routeNumber}\n" +
               $"Марка автобуса: {this.busBrand}\n" +
               $"Год начала эксплуатации: {this.yearOfOpetationStart}\n" +
               $"Пробег: {this.mileage}";
        }
    }
}
