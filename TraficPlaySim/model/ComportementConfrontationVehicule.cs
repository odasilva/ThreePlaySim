using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreePlaySim.Abstract;
using ThreePlaySim.TraficPlaySim.model;

namespace ThreePlaySim.TraficPlaySim.model
{
   public  class ComportementConfrontationVehicule : ComportementConfrontation
    {
       private Vehicule vehicule;

       public ComportementConfrontationVehicule(Vehicule _vehicule)
       {
           vehicule = _vehicule;
       }

        public override void Confrontation(Personnage adversaire) {}
    }
}
