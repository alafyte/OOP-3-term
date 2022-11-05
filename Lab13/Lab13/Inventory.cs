using System;


namespace Lab13
{
    [Serializable]
    public abstract class Inventory
    {
        public string Name { get; set; }

        public virtual void TakeItem()
        {
            Console.WriteLine("Взят предмет инвентаря");
        }

        public abstract void GetInventoryType();
    }

    [Serializable]
    //Скамейка
    public class Bench : Inventory, IUseInventory
    {
        public Bench()
        {
            Name = "Скамейка";
        }

        public Bench(string name)
        {
            Name = name;
        }

        public override void TakeItem()
        {
            Console.WriteLine("Взята скамейка");
        }
        public void UseInventory()
        {
            Console.WriteLine("Вы использовали скамейку");
        }

        public override void GetInventoryType()
        {
            Console.WriteLine("Это скамейка");
        }

        void IUseInventory.GetInventoryType()
        {
            Console.WriteLine("Скамейка");
        }

        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}";
        }
        public override bool Equals(object obj)
        {
            return this == obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    //Брусья
    public class Bars : Inventory, IUseInventory
    {
        public Bars()
        {
            Name = "Брусья";
        }
        public Bars(string name)
        {
            Name = name;
        }

        public override void TakeItem()
        {
            Console.WriteLine("Взяты брусья");
        }

        public void UseInventory()
        {
            Console.WriteLine("Вы использовали брусья");
        }
        public override void GetInventoryType()
        {
            Console.WriteLine("Это брусья");
        }
        void IUseInventory.GetInventoryType()
        {
            Console.WriteLine("Брусья");
        }

        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}";
        }
    }

    [Serializable]
    //Мяч
    public class Ball : Inventory, IUseInventory
    {
        [NonSerialized] public string color = "Orange";
        public int BallSize { get; set; }
        public Ball()
        {
            Name = "Мяч";
        }
        public Ball(string name, int ballsize)
        {
            Name = name;
            BallSize = ballsize;
        }

        public override void TakeItem()
        {
            Console.WriteLine("Взят мяч");
        }

        public void UseInventory()
        {
            Console.WriteLine("Вы использовали мяч");
        }
        public override void GetInventoryType()
        {
            Console.WriteLine("Это мяч");
        }
        void IUseInventory.GetInventoryType()
        {
            Console.WriteLine("Мяч");
        }

        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}";
        }
    }

    //Маты
    public class Mats : Inventory, IUseInventory
    {
        public Mats()
        {
            Name = "Мат";
        }
        public Mats(string name)
        {
            Name = name;
        }

        public override void TakeItem()
        {
            Console.WriteLine("Взят мат");
        }

        public void UseInventory()
        {
            Console.WriteLine("Вы использовали мат");
        }
        public override void GetInventoryType()
        {
            Console.WriteLine("Это мат");
        }
        void IUseInventory.GetInventoryType()
        {
            Console.WriteLine("Мат");
        }
        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}";
        }

    }
    [Serializable]
    //Баскетбольный мяч

    public sealed class BasketballBall : Ball, IUseInventory
    {
        public BasketballBall()
        {
            Name = "Баскетбольный мяч";
            BallSize = 3;
        }
        public BasketballBall(string name, int size)
        {
            Name = name;
            BallSize = size;
        }

        public override void TakeItem()
        {
            Console.WriteLine("Взят баскетбольный мяч");
        }
        public override void GetInventoryType()
        {
            Console.WriteLine("Это баскетбольный мяч");
        }

        void IUseInventory.UseInventory()
        {
            Console.WriteLine("Вы использовали баскетбольный мяч");
        }
        void IUseInventory.GetInventoryType()
        {
            Console.WriteLine("Баскетбольный мяч");
        }
        public override string ToString()
        {
            return $"Тип {this.GetType()}, название - {this.Name}, размер - {this.BallSize}";
        }
    }
}
