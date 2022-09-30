using System;

namespace Lab05
{
    class Printer
    {
        public void IAmPrinting(Inventory inventory)
        {
            Console.WriteLine(inventory.ToString());
        }
    }
}

