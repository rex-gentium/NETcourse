using NETcourse.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Factories
{
    class ParliamentaryCountryFactory : CountryAbstractFactory
    {
        public override Monarchy CreateMonarchy()
        {
            Random rand = new Random();
            return new ParliamentaryMonarchy(Randomizer.RandomCountryName(),
                Randomizer.RandomCityName(),
                rand.Next(1000000000), rand.Next(1000000),
                Randomizer.RandomTitle(),
                Randomizer.RandomPersonName(), Randomizer.RandomDynastyName(),
                Convert.ToUInt32(rand.Next(100)));
        }

        public override Republic CreateRepublic()
        {
            Random rand = new Random();
            return new ParliamentaryRepublic(Randomizer.RandomCountryName(),
                Randomizer.RandomCityName(),
                rand.Next(1000000000), rand.Next(1000000),
                Randomizer.RandomPersonName() + " " + Randomizer.RandomDynastyName(),
                new DateTime(), Convert.ToUInt32(rand.Next(4, 6)),
                Convert.ToUInt32(rand.Next(100)));
        }
    }
}
