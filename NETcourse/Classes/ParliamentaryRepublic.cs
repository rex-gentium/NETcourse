using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    class ParliamentaryRepublic : Republic
    {
        public int parliamentApproval;

        public ParliamentaryRepublic(String name, String capitalName, int population,
            int treasury, String presidentName, DateTime inaugurationDate,
            uint electionCycleYears, uint parliamentApproval)
            : base(name, capitalName, population, treasury, presidentName, inaugurationDate, electionCycleYears)
        {
            this.parliamentApproval = 0;
            IncreaseParliamentApproval(parliamentApproval);
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

        public override string GetCountryIntroduction()
        {
            return "President " + GetPresidentName() + " represents " + GetName() + " and its parliament located in the city of " + GetCapital() + ".";
        }
    }
}
