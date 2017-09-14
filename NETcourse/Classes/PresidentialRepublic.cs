using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    class PresidentialRepublic : Republic
    {
        public int presidentApproval;

        public PresidentialRepublic(String name, String capitalName, int population,
            int treasury, String presidentName, DateTime inaugurationDate,
            uint electionCycleYears, uint presidentApproval)
            : base(name, capitalName, population, treasury, presidentName, inaugurationDate, electionCycleYears)
        {
            this.presidentApproval = 0;
            IncreasePresidentApproval(presidentApproval);
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
            return "President " + GetPresidentName() + " is elected to rule the nation of " + GetName() + ". His office is in the city of " + GetCapital() + ".";
        }
    }
}
