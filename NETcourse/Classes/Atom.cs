using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETcourse.Classes
{
    class Atom : CompositeParticle
    {
        private Molecule molecule;
        private String electronConfiguration;
        private int valence;
        private int[] oxidationState;
    }
}
