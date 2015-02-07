using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreePlaySim;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.WarPlaySim
{
    public class DeFoudre : AccessoireDecorateur
    {
        public DeFoudre(Accessoire a)
            : base(a)
        {}

        public override string Utiliser()
        {
            return base.Utiliser() + " et de foudroyer";
        }
    }
}
