using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreePlaySim.Abstract;
namespace ThreePlaySim.WarPlaySim
{
    public class ComportementConfrontationPrincesse : ComportementConfrontation
    {
        private Soldat soldat;

        public ComportementConfrontationPrincesse(Soldat s)
        {
            soldat = s;
        }

        public override void Confrontation(Personnage adversaire)
        {
            
        }
    }
}
