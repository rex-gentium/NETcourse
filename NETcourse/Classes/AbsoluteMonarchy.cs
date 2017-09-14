using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    class AbsoluteMonarchy : Monarchy
    {
        private int monarchAuthority;

        public AbsoluteMonarchy(String name, String capitalName, int population, int treasury,
            String monarchTitle, String monarchName, String monarchDynasty, uint authority)
            : base(name, capitalName, population, treasury, monarchTitle, monarchName, monarchDynasty)
        {
            this.monarchAuthority = 0;
            IncreaseRoyalAuthority(authority);
        }

        public int GetRoyalAuthority()
        {
            return monarchAuthority;
        }

        public void IncreaseRoyalAuthority(uint value)
        {
            int impact = Convert.ToInt32(value);
            monarchAuthority += impact;
            if (monarchAuthority > 100)
                monarchAuthority = 100;
        }

        public void DecreaseRoyalAuthority(uint value)
        {
            int impact = Convert.ToInt32(value);
            monarchAuthority -= impact;
            if (monarchAuthority < 0)
                monarchAuthority = 0;
        }

        public override string GetCountryIntroduction()
        {
            return GetMonarchTitle() + " " + GetMonarchName() + " of house " + GetMonarchDynasty() 
                + " is the sole and supreme ruler of the people of " + GetName() + ". His royal palace is in " + GetCapital() + ".";
        }
    }
}
