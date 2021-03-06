﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    [Serializable]
    [DataContract]
    public class ParliamentaryRepublic : Republic
    {
        [DataMember]
        public int parliamentApproval;

        public ParliamentaryRepublic(): base() { }

        public ParliamentaryRepublic(String name, String capitalName, int population,
            int treasury, String presidentName, DateTime inaugurationDate,
            uint electionCycleYears, uint parliamentApproval)
            : base(name, capitalName, population, treasury, presidentName, inaugurationDate, electionCycleYears)
        {
            this.parliamentApproval = 0;
            IncreaseParliamentApproval(parliamentApproval);
        }

        public override object Clone()
        {
            return new ParliamentaryRepublic(GetName(), GetCapital(), GetPopulation(),
                GetTreasury(), GetPresidentName(), GetInaugurationDate(),
                Convert.ToUInt32(GetElectionCycleYears()),
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

        private String GetParliamentaryRepublicStringInfo()
        {
            return "Nation is ruled by the Parliament, its decisions are approved by "
                + GetParliamentApproval().ToString() + "/100 of population. "
                + GetPresidentName() + " is a simple representative of the country.\n";
        }

        public override String ToString()
        {
            return GetCountryStringInfo() + GetRepublicStringInfo() + GetParliamentaryRepublicStringInfo();
        }
    }
}
