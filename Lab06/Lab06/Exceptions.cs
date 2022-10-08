using System;

namespace Lab06
{
    /*1) Создайте иерархию классов исключений (собственных) – 3 типа и более. 
    Сделайте наследование пользовательских типов исключений от 
    стандартных классов .Net*/
    class InventoryException : Exception
    {
        //Класс в котором произошло исключение
        public string ErrorInClass { get; private set; }
        public InventoryException(string message, string errorInClass) : base(message)
        {
            ErrorInClass = errorInClass;
        }
    }

    class CostException : InventoryException
    {
        public int Cost { get; private set; }
        public CostException(string message, string errorInClass, int cost) : base(message, errorInClass)
        {
            Cost = cost;
        }
    }

    class BallSizeException : InventoryException
    {
        public int BallSize { get; private set; }

        public BallSizeException(string message, string ErrorInClass, int size) : base(message, ErrorInClass)
        {
            BallSize = size;
        }
    }
}
