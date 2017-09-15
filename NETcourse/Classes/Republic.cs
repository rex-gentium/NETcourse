using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    abstract class Republic : Country
    {
        private String presidentName;
        private DateTime inaugurationDate;
        private int electionCycleYears;
        private DateTime nextElectionDate;

        protected Republic(String name, String capitalName, int population,
            int treasury, String presidentName, DateTime inaugurationDate, uint electionCycleYears)
            : base(name, capitalName, population, treasury)
        {
            this.presidentName = presidentName;
            this.inaugurationDate = (inaugurationDate == null) ? new DateTime() : inaugurationDate;
            this.electionCycleYears = Convert.ToInt32(electionCycleYears);
            this.nextElectionDate = inaugurationDate.AddYears(this.electionCycleYears);
        }

        protected String GetRepublicStringInfo()
        {
            return "President " + GetPresidentName() + " is head of state, inaugurated in " 
                + GetInaugurationDate().ToShortDateString() + " for the next "
                + GetElectionCycleYears().ToString() + " years.\n";
        }
        
        public String GetPresidentName()
        {
            return presidentName;
        }

        public void SetPresidentName(String name)
        {
            this.presidentName = name;
        }

        public void SetPresident(String name)
        {
            this.presidentName = name;
            this.inaugurationDate = new DateTime();
            this.nextElectionDate = inaugurationDate.AddYears(electionCycleYears);
        }
        public DateTime GetInaugurationDate()
        {
            return inaugurationDate;
        }
         
        public int GetElectionCycleYears()
        {
            return electionCycleYears;
        }

        public void SetElectionCycleYears(uint electionCycleYears)
        {
            this.electionCycleYears = Convert.ToInt32(electionCycleYears);
        }

        public DateTime GetNextElectionDate()
        {
            return nextElectionDate;
        }
    }
}
