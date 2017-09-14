using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    abstract class Country
    {
        private String name;
        private String capital;
        private int treasury;
        private int population;
        private LinkedList<Country> allies;

        protected Country(String name, String capitalName, int population, int treasury)
        {
            this.name = name;
            this.capital = capitalName;
            this.population = population;
            this.treasury = treasury;
            this.allies = new LinkedList<Country>();
        }

        public abstract String GetCountryIntroduction();

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
            allies.AddLast(ally);
        }

        public void DissolveAlliance(Country ally)
        {
            allies.Remove(ally);
        }

    }
}
