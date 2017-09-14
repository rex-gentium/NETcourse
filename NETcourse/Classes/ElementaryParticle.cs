using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    abstract class ElementaryParticle : Particle
    {
        private double charge;  // Кл
        private double spin;    // коэффициент при ħ
        private double lifetime; // с
    }
}
