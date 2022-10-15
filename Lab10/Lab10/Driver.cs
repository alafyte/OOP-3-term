using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Driver
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }

        private Driver() {}
        public Driver(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }
            

    }
}
