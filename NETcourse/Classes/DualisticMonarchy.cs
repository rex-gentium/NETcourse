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

        public override string GetCountryIntroduction()
        {
            return GetMonarchTitle() + " " + GetMonarchName() + " of house " + GetMonarchDynasty()
                + " is the head of nation of " + GetName() + ", backed by the parliament in " + GetCapital() + ".";
        }
    }
}
