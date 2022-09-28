using System;

namespace Lab04
{
    class Printer
    {
        public void IAmPrinting(Inventory inventory)
        {
            Console.WriteLine(inventory.ToString());
        }
    }
}
