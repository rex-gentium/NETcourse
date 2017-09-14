using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Factories
{
    abstract class Randomizer
    {
        private static Random rand = new Random();
        private static char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
        private static char[] hards = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'z' };
        private static String[] countryEnd = { "land", "ia", "stan", "staat", "" };
        private static String[] cityEnd = { "berg", "burg", "ville", "holm", "grad", "sk", "town", "" };
        private static String[] dynastyEnd = { "dor", "sson", "in", "ov", "insky", "burg", "son", "" };
        private static String[] titles = { "Emperor", "King", "Duke", "Count", "Prince", "Tsar", "Sultan", "Emir", "High King" };

        private static char randomSymbol(bool vowel)
        {
            return (vowel) ? vowels[rand.Next() % vowels.Length] : hards[rand.Next() % hards.Length];
        }

        public static String RandomTitle()
        {
            return titles[rand.Next() % titles.Length];
        }

        public static String RandomCountryName()
        {
            bool vowel = rand.Next() % 2 == 0;
            String res = randomSymbol(!vowel).ToString().ToUpper();
            int length = rand.Next(2, 7);
            for (int i = 0; i < length; ++i)
            {
                res += randomSymbol(vowel);
                vowel = (rand.Next(100) < 85) ? !vowel : vowel;
            }
            res += countryEnd[rand.Next() % countryEnd.Length];
            return res;
        }

        public static String RandomPersonName()
        {
            bool vowel = rand.Next() % 2 == 0;
            String res = randomSymbol(!vowel).ToString().ToUpper();
            int length = rand.Next(5, 10);
            for (int i = 0; i < length; ++i)
            {
                res += randomSymbol(vowel);
                vowel = (rand.Next(100) < 85) ? !vowel : vowel;
            }
            return res;
        }

        public static String RandomCityName()
        {
            bool vowel = rand.Next() % 2 == 0;
            String res = randomSymbol(!vowel).ToString().ToUpper();
            int length = rand.Next(2, 6);
            for (int i = 0; i < length; ++i)
            {
                res += randomSymbol(vowel);
                vowel = (rand.Next(100) < 85) ? !vowel : vowel;
            }
            res += cityEnd[rand.Next() % cityEnd.Length];
            return res;
        }

        public static String RandomDynastyName()
        {
            bool vowel = rand.Next() % 2 == 0;
            String res = randomSymbol(!vowel).ToString().ToUpper();
            int length = rand.Next(3, 7);
            for (int i = 0; i < length; ++i)
            {
                res += randomSymbol(vowel);
                vowel = (rand.Next(100) < 85) ? !vowel : vowel;
            }
            res += dynastyEnd[rand.Next() % dynastyEnd.Length];
            return res;
        }

    }
}
