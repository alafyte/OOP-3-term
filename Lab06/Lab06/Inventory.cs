using System;


namespace Lab06
{
    public abstract class Inventory
    {
        public string Name { get; set; }
        public int Cost { get; set; }

        public virtual void TakeItem()
        {
            Console.WriteLine("Взят предмет инвентаря");
        }

        public abstract void GetInventoryType();
    }


    //Скамейка
    public class Bench : Inventory, IUseInventory
    {
        public Bench()
        {
            Name = "Скамейка";
            Cost = 145;
        }

        public Bench(string name, int cost = 145)
        {
            if (cost > 1000 || cost < 10)
                throw new CostException("Неккоректная цена", "Bench", cost);
            Name = name;
            Cost = cost;
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
            return $"Название - {this.Name}, стоимость - {this.Cost}";
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
            Cost = 200;
        }
        public Bars(string name, int cost = 200)
        {
            if (cost > 1000 || cost < 10)
                throw new CostException("Неккоректная цена", "Bars", cost);
            Name = name;
            Cost = cost;
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
            return $"Название - {this.Name}, стоимость - {this.Cost}";
        }
    }

    //Мяч
    public class Ball : Inventory, IUseInventory
    {
        public int BallSize { get; set; }
        public Ball()
        {
            Name = "Мяч";
            Cost = 200;
            BallSize = 3;
        }
        public Ball(string name, int cost = 200, int ballsize = 3)
        {
            if (cost > 1000 || cost < 10)
                throw new CostException("Неккоректная цена", "Ball", cost);
            if (ballsize > 7 || ballsize < 3)
                throw new BallSizeException("Неккоректный размер мяча", "Ball", ballsize);
            Name = name;
            Cost = cost;
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
            return $"Название - {this.Name}, стоимость - {this.Cost}";
        }
    }

    //Маты
    public partial class Mats : Inventory, IUseInventory
    {
        public Mats()
        {
            Name = "Мат";
            Cost = 113;
        }
        public Mats(string name, int cost = 113)
        {
            if (cost > 1000 || cost < 10)
                throw new CostException("Неккореткная цена", "Mats", cost);
            Name = name;
            Cost = cost;
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
            return $"Название - {this.Name}, стоимость - {this.Cost}";
        }

    }

    //Баскетбольный мяч

    public sealed class BasketballBall : Ball, IUseInventory
    {
        private const BallTypes ballType = BallTypes.BasketballBall;
        public BasketballBall()
        {
            Name = "Баскетбольный мяч";
            BallSize = 3;
            Cost = 40;
        }
        public BasketballBall(string name, int size, int cost = 40)
        {
            if (cost > 1000 || cost < 10)
                throw new CostException("Неккореткная цена", "BasketballBall", cost);
            if (size > 7 || size < 3)
                throw new BallSizeException("Неккоректный размер мяча", "BaskeballBall", size);

            Name = name;
            BallSize = size;
            Cost = cost;
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
            return $"Название - {this.Name}, размер - {this.BallSize}, стоимость - {this.Cost}";
        }
    }
}
