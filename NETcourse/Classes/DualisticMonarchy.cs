using NETcourse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    class DualisticMonarchy : Monarchy
    {
        private int monarchAuthority;
        private int parliamentApproval;

        public DualisticMonarchy(String name, String capitalName, int population, int treasury,
            String monarchTitle, String monarchName, String monarchDynasty, uint monarchAuthority, uint parliamentApproval)
            : base(name, capitalName, population, treasury, monarchTitle, monarchName, monarchDynasty)
        {
            this.monarchAuthority = this.parliamentApproval = 0;
            IncreaseRoyalAuthority(monarchAuthority);
            IncreaseParliamentApproval(parliamentApproval);
        }

        public override object Clone()
        {
            return new DualisticMonarchy(GetName(), GetCapital(), GetPopulation(),
                GetTreasury(), GetMonarchTitle(), GetMonarchName(), GetMonarchDynasty(),
                Convert.ToUInt32(GetRoyalAuthority()), Convert.ToUInt32(GetParliamentApproval()));
        }

        private String GetDualisticMonarchyStringInfo()
        {
            return GetMonarchTitle() + " and the Parliament rule over the nation, his authority is "
                + GetRoyalAuthority().ToString() + "/100, and Parliament has " + GetParliamentApproval().ToString()
                + "/100 electors approval.\n";
        }

        public override String ToString()
        {
            return GetCountryStringInfo() + GetMonarchyStringInfo() + GetDualisticMonarchyStringInfo();
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

        public int GetParliamentApproval()
        {
            return parliamentApproval;
        }

        public void IncreaseParliamentApproval(uint value)
        {
            int impact = Convert.ToInt32(value);
            parliamentApproval += impact;
            if (parliamentApproval > 100)
                parliamentApproval = 100;
        }

        public void DecreaseParliamentApproval(uint value)
        {
            int impact = Convert.ToInt32(value);
            parliamentApproval -= impact;
            if (parliamentApproval < 0)
                parliamentApproval = 0;
        }
    }
}
