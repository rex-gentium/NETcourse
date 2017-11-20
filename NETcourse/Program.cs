using NETcourse.Classes;
using NETcourse.Collections;
using NETcourse.Factories;
using NETcourse.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse
{
    class Program
    {
        class CountryComparer : IComparer<Country>
        {
            Func<Country, Country, int> comparer;

            public CountryComparer(Func<Country, Country, int> comparerFunc)
            {
                this.comparer = comparerFunc;
            }

            public int Compare(Country x, Country y)
                => comparer.Invoke(x, y);            
        }

        static int CountryNameComparer(Country a, Country b) {
            if (a == null && b == null) return 0;
            if (a == null && b != null) return -1;
            if (a != null && b == null) return 1;
            return a.GetName().CompareTo(b.GetName());
        }

        static void PrintCountryComparison(Country x, Country y, IComparer<Country> comparer)
        {
            int res = comparer.Compare(x, y);
            if (res > 0)
                Console.WriteLine(x.GetName() + " is bigger than " + y.GetName());
            else if (res < 0)
                Console.WriteLine(x.GetName() + " is less than " + y.GetName());
            else
                Console.WriteLine(x.GetName() + " equals " + y.GetName());
            Console.WriteLine();
        }

        static void DoAction(Action<Country, Country, IComparer<Country>> action, 
            Country arg1, Country arg2, IComparer<Country> arg3)
        {
            action.Invoke(arg1, arg2, arg3);
        }

        static void Main(string[] args)
        {
            TextWriter outFile = new StreamWriter("C:\\dump\\NET.txt");
            Debug.Log("Switching to File output", Debug.MessageLayer.WARNING);
            Debug.LogAction = outFile.WriteLine;
            
            CountryAbstractFactory factory = new DualisticCountryFactory();
            Confederacy<Country> countryList = new Confederacy<Country>("Republican Union");
            for (int i = 0; i < 10; ++i)
                countryList.Add(factory.CreateRepublic());

            Console.WriteLine("Initial collection:");
            Console.WriteLine(countryList.ToString());

            DoAction(PrintCountryComparison, countryList.First(), countryList.Last(),
                new CountryComparer(CountryNameComparer));

            countryList.Sort(new CountryComparer(CountryNameComparer));

            Console.WriteLine("Sorted by name:");
            Console.WriteLine(countryList.ToString());
            Console.ReadLine();

            outFile.Close();
        }
    }
}
