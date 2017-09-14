using NETcourse.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse
{
    class Program
    {
        static void Main(string[] args)
        {
            int governmentStyle = new Random().Next(3);
            CountryAbstractFactory cfac = null;
            switch(governmentStyle)
            {
                case 0: cfac = new IndividualisticCountryFactory(); break;
                case 1: cfac = new DualisticCountryFactory(); break;
                case 2: cfac = new ParliamentaryCountryFactory(); break;
            }
            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine(cfac.CreateMonarchy().GetCountryIntroduction());
                Console.WriteLine(cfac.CreateRepublic().GetCountryIntroduction());
            }
            Console.ReadLine();
        }
    }
}
