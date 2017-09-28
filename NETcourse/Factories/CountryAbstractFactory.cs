using NETcourse.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Factories
{
    abstract class CountryAbstractFactory
    {
        public abstract Monarchy CreateMonarchy();
        public abstract Republic CreateRepublic();
    }
}
