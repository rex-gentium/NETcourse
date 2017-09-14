using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    class MixedRepublic : Republic
    {
        public int parliamentApproval;
        public int presidentApproval;

        public MixedRepublic(String name, String capitalName, int population,
            int treasury, String presidentName, DateTime inaugurationDate,
            uint electionCycleYears, uint parliamentApproval, uint presidentApproval)
            : base(name, capitalName, population, treasury, presidentName, inaugurationDate, electionCycleYears)
        {
            this.parliamentApproval = this.presidentApproval = 0;
            IncreaseParliamentApproval(parliamentApproval);
            IncreasePresidentApproval(presidentApproval);
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

        public int GetPresidentApproval()
        {
            return presidentApproval;
        }

        public void IncreasePresidentApproval(uint value)
        {
            int impact = Convert.ToInt32(value);
            presidentApproval += impact;
            if (presidentApproval > 100)
                presidentApproval = 100;
        }

        public void DecreasePresidentApproval(uint value)
        {
            int impact = Convert.ToInt32(value);
            presidentApproval -= impact;
            if (presidentApproval < 0)
                presidentApproval = 0;
        }

        public override string GetCountryIntroduction()
        {
            return "President " + GetPresidentName() + " is rules with the parliament over the " + GetName() + ", with their capital in " + GetCapital() + ".";
        }
    }
}
