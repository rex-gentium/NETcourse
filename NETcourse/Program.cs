using NETcourse.Classes;
using NETcourse.Collections;
using NETcourse.Factories;
using NETcourse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse
{
    class Program
    {
        static int CompareCountryName(Country a, Country b) {
            return a.GetName().CompareTo(b.GetName());
        }

        static void Main(string[] args)
        {
            //
            PresidentialRepublic russia = new PresidentialRepublic("Russia", "Moscow", 
                145000000, 12000000, "Vladimir Putin", new DateTime(2012, 5, 7), 6, 86);

            // covarience
            IEnumerable<AbsoluteMonarchy> absoluteMonarchiesAlliance = new Confederacy<AbsoluteMonarchy>();
            IEnumerable<Monarchy> monarchiesAlliance = absoluteMonarchiesAlliance;
            // contravarience
            IPersonalizable<Republic> authoritanRepublic = new PresidentialRepublic("Belarus", "Minsk", 
                9498700, 55000, "Alexander Lukashenko", new DateTime(1994, 7, 20), 5, 50);
            IPersonalizable<PresidentialRepublic> authoritanPresidentalRepublic = authoritanRepublic;

            authoritanPresidentalRepublic.ArrangePersonalNegotiations(russia);

            CountryAbstractFactory factory = new DualisticCountryFactory();
            Confederacy<Country> countryList = new Confederacy<Country>();
            for (int i = 0; i < 10; ++i)
                countryList.Add(factory.CreateRepublic());
            Console.WriteLine("Initial collection:");
            Console.WriteLine(countryList.ToString());
            countryList.Sort(CompareCountryName);
            Console.WriteLine("Sorted by name:");
            Console.WriteLine(countryList.ToString());
            Console.ReadLine();
        }
    }
}
