using System;


namespace Lab02
{
    public partial class Bus
    {

        public string driverName { get; set; }
        private int busNumber;
        private int routeNumber;
        private string busBrand { get; set; }
        private int yearOfOpetationStart;
        private int mileage;


        /*поле - только для чтения(например, для каждого экземпляра сделайте
        поле только для чтения ID - равно некоторому уникальному номеру
        (хэшу) вычисляемому автоматически на основе инициализаторов объекта);*/
        private readonly int busID;

        //поле- константу;
        private const string busColor = "Yellow";

        /*создайте в классе статическое поле, хранящее количество созданных
        объектов(инкрементируется в конструкторе)*/
        private static int count;



        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        //КОНСТРУКТОРЫ
        /*Не менее трех конструкторов (с параметрами и без, а также с 
        параметрами по умолчанию )*/

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

        //статический конструктор(конструктор типа);

        static Bus()
        {
            count = 0;
        }

        //определите закрытый конструктор; предложите варианты его вызова;
        //private Bus() { }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////
        //СВОЙСТВА
        //свойства (get, set) – для всех поле класса (поля класса должны быть закрытыми)
        public int BusNum
        {
            get { return this.busNumber; }
            private set // Для одного из свойств ограните доступ по set
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
    }
}
