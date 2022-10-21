using System;

namespace Lab11
{
    public class Bars
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public Bars()
        {
            Name = "Брусья";
            Cost = 100;
        }
        public Bars(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public void TakeItem()
        {
            Console.WriteLine("Взяты брусья");
        }

        public void UseInventory()
        {
            Console.WriteLine("Вы использовали брусья");
        }
        public void GetInventoryType()
        {
            Console.WriteLine("Это брусья");
        }

        public override string ToString()
        {
            return $"название: {this.Name}, цена: {this.Cost}\n";
        }
    }
    
}
