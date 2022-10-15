using System.Collections;

namespace Lab09
{
    //1) Создайте класс по варианту, определите в нем свойства и методы
    class GeometricFigure
    {
        public string Name { get; set; }
        public int Area { get; set; }

        private GeometricFigure() { }
        public GeometricFigure(string name, int area)
        {
            Name = name;
            Area = area;
        }

        public override string ToString()
        {
            return $"Название - {Name}, площадь - {Area}";
        }
    }
}
