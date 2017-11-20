using NETcourse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    abstract class Country : ICloneable, IRivalry<Country>, IComparable
    {
        private String name;
        private String capital;
        private int treasury;
        private int population;
        private Country rival;
        private LinkedList<Country> allies;
        private static Func<Country, Country, int> comparator;

        protected Country(String name, String capitalName, int population, int treasury)
        {
            this.name = name;
            this.capital = capitalName;
            this.population = population;
            this.treasury = treasury;
            this.allies = new LinkedList<Country>();
            this.rival = null;
        }

        public abstract override String ToString();

        protected String GetCountryStringInfo()
        {
            String res = "Nation of " + GetName() + "\n"
                + "\twith capital in " + GetCapital() + "\n"
                + "\tis populated by " + GetPopulation().ToString() + " inhabitans\n"
                + "\tand posesses total wealth of $" + GetTreasury().ToString() + " millions\n";
            if (allies.Count > 0)
            {
                res += "Allies: ";
                foreach (Country ally in allies)
                    res += ally.GetName() + ' ';
                res += '\n';
            }
            return res;
        }

        public String GetName() {
            return name;
        }

        public void SetName(String name) {
            this.name = name;
        }

        public String GetCapital()
        {
            return capital;
        }

        public void SetCapital(String name)
        {
            this.capital = name;
        }

        public int GetTreasury()
        {
            return treasury;
        }

        public void IncreaseTreasury(uint sum)
        {
            this.treasury += Convert.ToInt32(sum);
        }

        public void DecreaseTreasury(uint sum)
        {
            this.treasury -= Convert.ToInt32(sum);
        }

        public int GetPopulation()
        {
            return population;
        }

        public void IncreasePopulation(uint population)
        {
            this.population += Convert.ToInt32(population);
        }

        public void DecreasePopulation(uint population)
        {
            this.population -= Convert.ToInt32(population);
        }

        public LinkedList<Country> GetAllies()
        {
            return allies;
        }

        public void AllyWith(Country ally)
        {
            if (allies.Find(ally) == null)
                allies.AddLast(ally);
            if (ally.allies.Find(this) == null)
                ally.allies.AddLast(this);
        }

        public void DissolveAlliance(Country ally)
        {
            allies.Remove(allies.Find(ally));
            ally.allies.Remove(ally.allies.Find(this));
        }

        public abstract object Clone();

        public Country GetRival()
        {
            return rival;
        }

        public void SetRival(Country rival)
        {
            this.rival = rival;
        }

        internal static void SetComparator<T>(Func<T, T, int> comparator) where T : Country
        {
            Country.comparator = (Func<Country, Country, int>) comparator;
        }

        public int CompareTo(object obj)
        {
            return comparator.Invoke(this, (Country)obj);
        }
    }
}
