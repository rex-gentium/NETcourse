using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    class ParliamentaryMonarchy : Monarchy
    {
        private int parliamentApproval;

        public ParliamentaryMonarchy(String name, String capitalName, int population, int treasury,
            String monarchTitle, String monarchName, String monarchDynasty, uint parliamentApproval)
            : base(name, capitalName, population, treasury, monarchTitle, monarchName, monarchDynasty)
        {
            this.parliamentApproval = 0;
            IncreaseParliamentApproval(parliamentApproval);
        }

        public override object Clone()
        {
            return new ParliamentaryMonarchy(GetName(), GetCapital(), GetPopulation(),
                GetTreasury(), GetMonarchTitle(), GetMonarchName(), GetMonarchDynasty(),
                Convert.ToUInt32(GetParliamentApproval()));
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

        private String GetParliamentaryMonarchyStringInfo()
        {
            return "Parliament rule over the nation, its decisions are approved by " 
                + GetParliamentApproval().ToString() + "/100 of population. "
                + GetMonarchTitle() + ' ' + GetMonarchName() + " is a simple representative of the country.\n";
        }

        public override String ToString()
        {
            return GetCountryStringInfo() + GetMonarchyStringInfo() + GetParliamentaryMonarchyStringInfo();
        }
    }
}
