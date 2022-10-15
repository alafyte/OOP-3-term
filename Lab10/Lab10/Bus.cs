using System;


namespace Lab10
{
    public class Bus
    {

        public string driverName { get; set; }
        private int busNumber;
        private int routeNumber;
        private string busBrand { get; set; }
        private int yearOfOpetationStart;
        private int mileage;

        private readonly int busID;


        private const string busColor = "Yellow";

        private static int count;

        public Bus()
        {
            driverName = "Default";
            busNumber = 100;
            routeNumber = 1;
            busBrand = "МАЗ";
            yearOfOpetationStart = 2022;
            mileage = 0;
            busID = GetHashCode();
            count++;
        }

        public Bus(string driverName, int busNumber, int routeNumber,
            int yearOfOpetationStart, int mileage, string busBrand = "МАЗ")
        {
            if (routeNumber > 0 && yearOfOpetationStart >= 1990 && mileage >= 0)
            {
                this.driverName = driverName;
                this.busNumber = busNumber;
                this.routeNumber = routeNumber;
                this.busBrand = busBrand;
                this.yearOfOpetationStart = yearOfOpetationStart;
                this.mileage = mileage;
                busID = GetHashCode();
                count++;
            }
            else
                throw new ArgumentException();
        }

        public Bus(int routeNum)
        {
            if (routeNum > 0)
            {
                driverName = "Default";
                busNumber = 100;
                routeNumber = routeNum;
                busBrand = "МАЗ";
                yearOfOpetationStart = 2022;
                mileage = 0;
                busID = GetHashCode();
                count++;
            }
            else
                throw new ArgumentException();
        }


        static Bus()
        {
            count = 0;
        }
        public int BusNum
        {
            get { return this.busNumber; }
            private set
            {
                if (this.busNumber > 0)
                    this.busNumber = value;
                else
                    this.busNumber = 1;
            }
        }

        public int RouteNum
        {
            get { return this.routeNumber; }
            set
            {
                if (this.routeNumber > 0)
                    this.routeNumber = value;
                else
                    this.routeNumber = 1;
            }
        }

        public int YearStart
        {
            get { return this.yearOfOpetationStart; }
            set
            {
                if (this.yearOfOpetationStart >= 1990)
                    this.yearOfOpetationStart = value;
                else
                    this.yearOfOpetationStart = 1990;
            }
        }

        public int Mileage
        {
            get { return this.mileage; }
            set
            {
                if (this.mileage >= 0)
                    this.mileage = value;
                else
                    this.mileage = 0;
            }
        }

        public int BusAge()
        {
            int currentYear = DateTime.Now.Year;

            int busAge = currentYear - this.yearOfOpetationStart;
            return (busAge);
        }

        public void IncreaseMileage(ref int transportMileage)
        {
            transportMileage++;
        }

        public void ChangeDriver(out string oldName, string newName)
        {
            oldName = newName;
        }

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
