using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreePlaySim.Abstract;
using ThreePlaySim.TraficPlaySim.model;

namespace ThreePlaySim.TraficPLaySim.model
{
    public abstract class ComportementVehicule
    {
        protected Vehicule vehicule;

        public ComportementVehicule(Vehicule v)
        {
            vehicule = v;
        }
        public abstract void rouler();
        public abstract Boolean cederLePassage();
        public abstract void doubler(Vehicule v);
    }
}
