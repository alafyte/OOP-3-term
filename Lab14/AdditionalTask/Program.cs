using System;
using System.Threading;
using System.IO;

namespace AdditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread machine1 = new Thread(Machine.Machine1);
            Thread machine2 = new Thread(Machine.Machine2);
            Thread machine3 = new Thread(Machine.Machine3);

            machine1.Start();
            machine2.Start();
            machine3.Start();

            Console.ReadKey();

            for (int i = 0; i < 15; i++)
            {
                Client client = new Client(i + 1);
            }
        }
    }
}
