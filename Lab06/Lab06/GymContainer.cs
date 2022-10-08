using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab06
{
    public class GymContainer
    {
        private readonly int _budget;

        public List<Inventory> InventoryList { get; private set; }
        public int NumberOfEquipment { get; private set; }
        public int CurrentBudget { get; private set; }

        public GymContainer()
        {
            _budget = CurrentBudget = 1000;
            NumberOfEquipment = 0;
            InventoryList = new List<Inventory>();
        }
        public GymContainer(int budget)
        {
            _budget = CurrentBudget = budget;
            NumberOfEquipment = 0;
            InventoryList = new List<Inventory>();
        }
        public GymContainer(int budget, List<Inventory> list)
        {
            _budget = budget;
            CurrentBudget = _budget - list.Sum(item => item.Cost);
            NumberOfEquipment = list.Count;
            InventoryList = list;
            SortInventoryList();
        }

        public void AddItem(Inventory item)
        {
            if (item.Cost > CurrentBudget)
                throw new ArgumentException();

            InventoryList.Add(item);
            CurrentBudget -= item.Cost;
            NumberOfEquipment++;
            SortInventoryList();
        }

        public void DeleteItem(Inventory item)
        {
            if (!InventoryList.Contains(item))
                throw new ArgumentException();

            InventoryList.Remove(item);

            CurrentBudget += item.Cost;
            NumberOfEquipment--;
            SortInventoryList();
        }

        public void PrintList()
        {
            Console.WriteLine(
               $"----------------------\nСпортзал:\n" +
               $"Количество снарядов: {NumberOfEquipment}\n" +
               $"Бюджет: {_budget}\n" +
               $"Текущий бюджет: {CurrentBudget}\n");

            foreach(var item in InventoryList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("----------------------");
        }
        private void SortInventoryList()
        {
            InventoryList = InventoryList.OrderBy(x => x.Cost).ToList();
        }
    }
}
