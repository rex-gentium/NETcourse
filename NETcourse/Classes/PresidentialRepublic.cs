using NETcourse.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    class PresidentialRepublic : Republic, IPersonalizable<Republic>
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

        public override object Clone()
        {
            return new PresidentialRepublic(GetName(), GetCapital(), GetPopulation(),
                GetTreasury(), GetPresidentName(), GetInaugurationDate(), 
                Convert.ToUInt32(GetElectionCycleYears()),
                Convert.ToUInt32(GetPresidentApproval()));
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

        private String GetPresidentialRepublicStringInfo()
        {
            return "President wields the power in country, "
                + GetPresidentApproval().ToString() + "/100 of population approves his government.\n";
        }

        public override String ToString()
        {
            return GetCountryStringInfo() + GetRepublicStringInfo() + GetPresidentialRepublicStringInfo();
        }

        public void ArrangePersonalNegotiations(Republic rival)
        {
            Console.WriteLine("Presidents of " + GetName() + " and " + rival.GetName() + " have had a private negotiation.");
        }
    }
}
