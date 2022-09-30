using System;

namespace Lab05
{
    public partial class Mats
    {
        /*К предыдущей лабораторной работе(л.р. 4) добавьте к существующим классам структуру.*/
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
