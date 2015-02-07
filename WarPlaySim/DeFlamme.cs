using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.WarPlaySim
{
    public class DeFlamme : AccessoireDecorateur
    {

        public DeFlamme(Accessoire a)
            : base(a)
        {
        }

        public override string Utiliser()
        {
            return base.Utiliser() + " et de bruler";
        }
    }
}
