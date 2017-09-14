using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    abstract class Monarchy : Country
    {
        private String monarchTitle;
        private String monarchName;
        private String monarchDynasty;
        private String heirName;
        private String heirDynasty;
        private LinkedList<Monarchy> royalMarriages;

        protected Monarchy(String name, String capitalName, int population, int treasury,
            String monarchTitle, String monarchName, String monarchDynasty) 
            : base(name, capitalName, population, treasury)
        {
            this.monarchName = monarchName;
            this.monarchDynasty = monarchDynasty;
            this.monarchTitle = monarchTitle;
            royalMarriages = new LinkedList<Monarchy>();
        }

        public String GetMonarchTitle()
        {
            return monarchTitle;
        }

        public void SetMonarchTitle(String title)
        {
            this.monarchTitle = title;
        }

        public String GetMonarchName()
        {
            return monarchName;
        }

        public void SetMonarchName(String name)
        {
            this.monarchName = name;
        }

        public String GetMonarchDynasty()
        {
            return monarchDynasty;
        }

        public String GetHeirName()
        {
            return heirName;
        }

        public void SetHeirName(String name)
        {
            this.heirName = name;
        }

        public String GetHeirDynasty()
        {
            return heirDynasty;
        }

        public void SetMonarch(String name, String dynasty)
        {
            this.monarchName = name;
            this.monarchDynasty = dynasty;
        }

        public void SetHeir(String name, String dynasty)
        {
            this.heirName = name;
            this.heirDynasty = dynasty;
        }

        public LinkedList<Monarchy> GetRoyalMarriages()
        {
            return royalMarriages;
        }

        public void ArrangeRoyalMarriage(Monarchy with)
        {
            royalMarriages.AddLast(with);
        }

        public void BreakRoyalMarriage(Monarchy with)
        {
            royalMarriages.Remove(with);
        }
    }
}
