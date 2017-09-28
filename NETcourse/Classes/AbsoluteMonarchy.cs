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

        public override object Clone()
        {
            return new AbsoluteMonarchy(GetName(), GetCapital(), GetPopulation(),
                GetTreasury(), GetMonarchTitle(), GetMonarchName(), GetMonarchDynasty(),
                Convert.ToUInt32(GetRoyalAuthority()));
        }

        private String GetAbsoluteMonarchyStringInfo()
        {
            return GetMonarchTitle() + " is a sole and supreme ruler of his nation, his reign authority is "
                + GetRoyalAuthority().ToString() + "/100\n";
        }

        public override String ToString()
        {
            return GetCountryStringInfo() + GetMonarchyStringInfo() + GetAbsoluteMonarchyStringInfo();
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

    }
}
