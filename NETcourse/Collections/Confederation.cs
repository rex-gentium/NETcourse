using NETcourse.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace NETcourse.Collections
{
    class Confederation : ICollection<Country>
    {
        Country[] countries = new Country[0];
        int size = 0;

        class Enumerator : IEnumerator<Country>
        {
            Confederation collection;
            int index;

            public Country Current => collection.countries[index];
            object IEnumerator.Current => collection.countries[index];

            public Enumerator(Confederation collection, int index)
            {
                this.collection = collection;
                this.index = index;
            }

            public void Dispose() {}

            public bool MoveNext()
            {
                return ++index < collection.size;
            }

            public void Reset()
            {
                index = 0;
            }
        }

        /* Получает число элементов, содержащихся в коллекции */
        public int Count => size;
        /* Получает значение, указывающее, является ли объект коллекции доступным только для чтения */
        public bool IsReadOnly => false;

        /* Добавляет элемент в коллекцию */
        public void Add(Country item)
        {
            if (Contains(item)) return;
            if (size >= countries.Length)
            {
                Country[] newCountries = new Country[countries.Length * 2];
                for (int i = 0; i < size; ++i)
                    newCountries[i] = countries[i];
                countries = newCountries;
            }
            countries[size++] = item;
        }
        
        /* Удаляет все элементы из коллекции */
        public void Clear()
        {
            countries = new Country[0];
        }
        
        /*Определяет, содержит ли коллекция указанное значение*/
        public bool Contains(Country item)
        {
            for (int i = 0; i < size; ++i)
                if (countries[i].Equals(item))
                    return true;
            return false;
        }
        
        /* Копирует элементы коллекции в массив Array, начиная с указанного индекса массива Array */
        public void CopyTo(Country[] array, int arrayIndex)
        {
            for (int i = 0; i < size && arrayIndex + i < array.Length; ++i)
                array[arrayIndex + i] = (Country) countries[i].Clone();
        }
        
        /* Возвращает перечислитель, выполняющий перебор элементов в коллекции. */
        public IEnumerator<Country> GetEnumerator()
        {
            return new Enumerator(this, 0);
        }

        /* Удаляет элемент из коллекции, если он там присутствует. Возращает результат удаления. */
        public bool Remove(Country item)
        {
            for (int i = 0; i < size; ++i)
                if (countries[i].Equals(item))
                {
                    for (int j = i; j < size; ++j)
                        countries[j] = countries[j + 1];
                    --size;
                    return true;
                };
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
