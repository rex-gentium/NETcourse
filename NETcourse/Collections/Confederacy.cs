﻿using NETcourse.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace NETcourse.Collections
{
    [Serializable]
    public class Confederacy<T> : ICollection<T> where T:Country
    {
        public string name;
        public T[] countries = new T[0];
        private int size = 0;

        class Enumerator<T> : IEnumerator<T> where T:Country
        {
            Confederacy<T> collection;
            int index;

            public T Current => (T)collection.countries[index];
            object IEnumerator.Current => collection.countries[index];

            public Enumerator(Confederacy<T> collection, int index)
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

        public Confederacy() { }

        public Confederacy(string name)
        {
            this.name = name;
            Debug.Log(name + " (Confederacy) installed");
        }

        /* Добавляет элемент в коллекцию */
        public void Add(T item)
        {
            if (Contains(item)) return;
            if (size >= countries.Length)
            {
                T[] newCountries = new T[(countries.Length > 0) ? countries.Length * 2 : 1];
                for (int i = 0; i < size; ++i)
                    newCountries[i] = (T)countries[i];
                countries = newCountries;
            }
            countries[size++] = item;
            Debug.Log(item.GetName() + " joined the " + name + " (confederacy)");
        }
        
        /* Удаляет все элементы из коллекции */
        public void Clear()
        {
            countries = new T[0];
        }
        
        /*Определяет, содержит ли коллекция указанное значение*/
        public bool Contains(T item)
        {
            for (int i = 0; i < size; ++i)
                if (countries[i].Equals(item))
                    return true;
            return false;
        }
        
        /* Копирует элементы коллекции в массив Array, начиная с указанного индекса массива Array */
        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < size && arrayIndex + i < array.Length; ++i)
                array[arrayIndex + i] = (T) countries[i].Clone();
        }
        
        /* Возвращает перечислитель, выполняющий перебор элементов в коллекции. */
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this, 0);
        }

        /* Удаляет элемент из коллекции, если он там присутствует. Возращает результат удаления. */
        public bool Remove(T item)
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

        public async Task<bool> Sort(IComparer<T> comparer)
        {
            Debug.Log("Sorting started");
            await Task.Run(() => SortCountriesBy(comparer));
            Debug.Log("Sorting finished");
            return true;
        }

        private void SortCountriesBy(IComparer<T> comparer)
        {
            for (int i = 0; i < size; ++i)
            {
                bool wasSwapped = false;
                int lastSwap = 0;
                for (int j = 0; j < size - 1; ++j)
                    if (comparer.Compare(countries[j], countries[j + 1]) > 0)
                    {
                        T temp = countries[j];
                        countries[j] = countries[j + 1];
                        countries[j + 1] = temp;
                        wasSwapped = true;
                        lastSwap = j;
                    }
                float sortedRatio = 100.0f * (1.0f - lastSwap / (float)size);
                Debug.Log(sortedRatio.ToString("0") + "% of elements sorted");
                if (!wasSwapped) break;
            }
        }

        public void DoAction(Action<Confederacy<T>> action)
        {
            action.Invoke(this);
        }

        public override string ToString()
        {
            String res = "";
            for (int i = 0; i < size; ++i)
                res += countries[i].GetName() + '\n';
            return res;
        }

    }
}
