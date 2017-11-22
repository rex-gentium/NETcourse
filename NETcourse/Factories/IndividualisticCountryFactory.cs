using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NETcourse.Classes;

namespace NETcourse.Factories
{
    class IndividualisticCountryFactory : CountryAbstractFactory
    {
        public override Monarchy CreateMonarchy()
        {
            Random rand = new Random();
            return new AbsoluteMonarchy(Randomizer.RandomCountryName(),
                Randomizer.RandomCityName(),
                rand.Next(1000000000), rand.Next(1000000),
                Randomizer.RandomTitle(),
                Randomizer.RandomPersonName(), Randomizer.RandomDynastyName(),
                Convert.ToUInt32(rand.Next(100)));
        }

        public override Republic CreateRepublic()
        {
            Random rand = new Random();
            return new PresidentialRepublic(Randomizer.RandomCountryName(),
                Randomizer.RandomCityName(),
                rand.Next(1000000000), rand.Next(1000000),
                Randomizer.RandomPersonName() + " " + Randomizer.RandomDynastyName(),
                new DateTime(rand.Next(1700, 2017), rand.Next(1, 12), rand.Next(1, 28)), 
                Convert.ToUInt32(rand.Next(4, 6)),
                Convert.ToUInt32(rand.Next(100)));
        }
    }
}
