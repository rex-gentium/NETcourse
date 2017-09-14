using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    abstract class CompositeParticle : Particle
    {
        private Particle[] components;
        private double radius;
    }
}
