using System;
using System.Collections;
using System.Linq;

namespace Lab09
{
    /*1) Реализуйте указанный интерфейс и другие при необходимости, соберите объекты класса в 
    коллекцию (можно сделать специальных класс с вложенной коллекцией и методами ею управляющими)*/
    class GeometricFiguresCollection : IEnumerator, IEnumerable
    {
        private GeometricFigure[] _geometricFigures;
        private int _index;

        public GeometricFiguresCollection()
        {
            _index = -1;
            _geometricFigures = Array.Empty<GeometricFigure>();
        }


        //Реализация интерфейсов
        public bool MoveNext()
        {
            if (_index == _geometricFigures.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }

        public object Current
        {
            get
            {
                return _geometricFigures[_index];
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i < _geometricFigures.Length; i++)
                yield return _geometricFigures[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //Другие методы
        public void Add(GeometricFigure figure)
        {
            ++_index;
            var tmp = new GeometricFigure[_index + 1];
            _geometricFigures.CopyTo(tmp, 0);
            _geometricFigures = tmp;
            _geometricFigures[_index] = figure;
        }
        public void Insert(int index, GeometricFigure figure)
        {
            if (index < 0 || index > _index)
                throw new ArgumentOutOfRangeException();

            ++_index;
            var tmp = new GeometricFigure[_index + 1];
            _geometricFigures.CopyTo(tmp, 0);
            _geometricFigures = tmp;
            for (int i = _index - 1; i >= index; i--)
                _geometricFigures[i + 1] = _geometricFigures[i];

            _geometricFigures[index] = figure;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 && index >= _index) 
                throw new ArgumentOutOfRangeException();

            _geometricFigures = _geometricFigures.Where((val, idx) => idx != index).ToArray();
            _index--;
        }
        public int Search(GeometricFigure figure)
        {
            return Array.IndexOf(_geometricFigures, figure);
        }
        public void Show()
        {
            foreach(var item in _geometricFigures)
            {
                Console.WriteLine($"{item.ToString()}");
            }
        }

        //Индексатор
        public GeometricFigure this[int index]
        {
            get => _geometricFigures[index];
            private set => _geometricFigures[index] = value;
        }
    }
}