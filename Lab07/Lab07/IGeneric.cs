using System;
using System.Collections.Generic;

namespace Lab07
{
    //1) Создайте обобщенный интерфейс с операциями добавить, удалить, просмотреть.

    public interface IGeneric<T>
    {
        public void Add(T elem);
        public void Remove(T elem);
        public void Show();
    }
}
