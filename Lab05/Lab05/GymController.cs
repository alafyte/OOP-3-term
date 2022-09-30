using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lab05
{
    /*Определить управляющий класс-Контроллер, который управляет объектом- Контейнером и реализовать в нем запросы по варианту. 
     * При необходимости используйте стандартные интерфейсы (IComparable, ICloneable,….)*/
    //Найти снаряды, соответствующие заданному диапазону цены.
    public static class GymController
    {
        public static List<Inventory> FindItemsByCost (GymContainer gym, int minCost, int maxCost)
        {
            return gym.InventoryList.FindAll(x => x.Cost >= minCost && x.Cost <= maxCost);
        }

        /*Добавьте в класс-контроллер метод, считывающий построчно текстовый файл, в котором хранятся данные вашего 
         * класса и инициализирует таким образом коллекцию. */
        public static void CreateGymText(GymContainer gym)
        {
            StreamReader file = new StreamReader("C:\\University\\3_cем\\ОOП\\Lab05\\Lab05\\Data.txt");

            while (file.ReadLine() is string line)
            {
                switch (line)
                {
                    case "Ball":
                        gym.AddItem(new Ball());
                        break;
                    case "BasketballBall":
                        gym.AddItem(new BasketballBall());
                        break;
                    case "Bench":
                        gym.AddItem(new Bench());
                        break;
                    case "Bars":
                        gym.AddItem(new Bars());
                        break;
                    case "Mats":
                        gym.AddItem(new Mats());
                        break;
                    default:
                        break;
                }
            }
        }

        /*2. Реализуйте еще один метод, который будет считывать данные из json файла и инициализировать коллекцию*/
        public static void CreateGymJSON(GymContainer gym)
        {
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
            };
            using var stream = new StreamReader(@"C:\University\3_cем\ОOП\Lab05\Lab05\Data.json");
            string JsonData = stream.ReadToEnd();

            List<Inventory> deserializedList = JsonConvert.DeserializeObject<List<Inventory>>(JsonData, settings);
            foreach (var item in deserializedList)
                gym.AddItem(item);
        }
    }
}
