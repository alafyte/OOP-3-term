using System.IO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lab06
{
    public static class GymController
    {
        public static List<Inventory> FindItemsByCost(GymContainer gym, int minCost, int maxCost)
        {
            return gym.InventoryList.FindAll(x => x.Cost >= minCost && x.Cost <= maxCost);
        }
        public static void CreateGymText(GymContainer gym)
        {
            try
            {
                StreamReader file = new StreamReader("C:\\University\\3_cем\\ОOП\\Lab06\\Lab06\\Data.txt");
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
            catch (FileNotFoundException e)
            {
                //Пример работы с логгером
                Logger.WriteLogFileConsole(e, true);
                Logger.WriteLogFileConsole(e);
            }
        }

        public static void CreateGymJSON(GymContainer gym)
        {
            try
            {
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                };

                var stream = new StreamReader(@"C:\University\3_cем\ОOП\Lab06\Lab06\Data.json");
                string JsonData = stream.ReadToEnd();

                List<Inventory> deserializedList = JsonConvert.DeserializeObject<List<Inventory>>(JsonData, settings);
                foreach (var item in deserializedList)
                    gym.AddItem(item);
            }
            catch (FileNotFoundException e)
            {
                /*5) Продемонстрируйте возможность многоразовой обработки одного
            исключения и проброс его выше по стеку вызовов.*/
                throw;
            }
        }
    }
}
