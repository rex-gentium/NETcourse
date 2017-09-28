using NETcourse.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Interfaces
{
    interface IRivalry<out T> where T:Country
    {
        T GetRival();
        void SetRival(Country rival);
    }
}
