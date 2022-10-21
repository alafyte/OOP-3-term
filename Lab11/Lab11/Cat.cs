using System;
using System.Collections.Generic;

namespace Lab11
{
    class Cat
    {
        public string Name { get; set; }

        public void FeedCat(List<string> catFood)
        {
            foreach(var f in catFood)
                Console.WriteLine($"Вы покормили кота кормом {f}");
        }
    }
}
