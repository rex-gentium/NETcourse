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

        public int Count => countries.Length;
        public bool IsReadOnly => false;

        /* Добавляет элемент в коллекцию */
        public void Add(Country item)
        {
            if (Contains(item)) return;
            Country[] newCountries = new Country[Count + 1];
            for(int i = 0; i < Count; ++i)
                newCountries[i] = countries[i];
            newCountries[Count] = item;
        }
        /* Удаляет все элементы из коллекции */
        public void Clear()
        {
            countries = new Country[0];
        }
        /*Определяет, содержит ли коллекция указанное значение*/
        public bool Contains(Country item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Country[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Country> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Country item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
