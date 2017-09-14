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
                + " represents " + GetName() + ". " + GetName() + " is ruled by the parliament in its capital " + GetCapital() + ".";
        }
    }
}
