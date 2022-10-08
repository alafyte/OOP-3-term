using System;

namespace Lab06
{
    public partial class Mats
    {
        private struct MatSpecification
        {
            int size;
            string color;
            string typeOfMat;

            public MatSpecification(int size, string color, string typeOfMat)
            {
                this.size = size;
                this.color = color;
                this.typeOfMat = typeOfMat;
            }
            public void Specification()
            {
                Console.WriteLine($"Размер мата - {this.size}, цвет - {this.color}, тип - {this.typeOfMat}");
            }
        }
    }
}
