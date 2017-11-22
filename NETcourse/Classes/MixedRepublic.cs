using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NETcourse.Classes
{
    [Serializable]
    [DataContract]
    public class MixedRepublic : Republic
    {
        [DataMember]
        public int parliamentApproval;
        [DataMember]
        public int presidentApproval;

        public MixedRepublic(): base() { }

        public MixedRepublic(String name, String capitalName, int population,
            int treasury, String presidentName, DateTime inaugurationDate,
            uint electionCycleYears, uint parliamentApproval, uint presidentApproval)
            : base(name, capitalName, population, treasury, presidentName, inaugurationDate, electionCycleYears)
        {
            this.parliamentApproval = this.presidentApproval = 0;
            IncreaseParliamentApproval(parliamentApproval);
            IncreasePresidentApproval(presidentApproval);
        }

        public override object Clone()
        {
            return new MixedRepublic(GetName(), GetCapital(), GetPopulation(),
                GetTreasury(), GetPresidentName(), GetInaugurationDate(),
                Convert.ToUInt32(GetElectionCycleYears()),
                Convert.ToUInt32(GetParliamentApproval()), Convert.ToUInt32(GetPresidentApproval()));
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

        private String GetMixedRepublicStringInfo()
        {
            return "Both President and Parliament have the power, President decisions are approved by "
                + GetPresidentApproval().ToString() + "/100 of population, and Parliament has "
                + GetParliamentApproval().ToString() + "/100 electors support.\n";
        }

        public override String ToString()
        {
            return GetCountryStringInfo() + GetRepublicStringInfo() + GetMixedRepublicStringInfo();
        }
    }
}
