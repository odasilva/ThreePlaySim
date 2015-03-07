using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreePlaySim.Abstract;
using ThreePlaySim.TraficPlaySim.model;

namespace ThreePlaySim.TraficPLaySim.model
{
    public class ComportementVehiculeLent : ComportementVehicule
    {

        public ComportementVehiculeLent(Vehicule v) : base(v) { }
        public override void rouler() {
                if (vehicule.Position.X - 1 > 0)
                    vehicule.SeDeplacer((vehicule.Position.X - 1), vehicule.Position.Y);
                else
                    vehicule.SeDeplacer(29, vehicule.Position.Y - 12);
        }
        public override Boolean cederLePassage() {
            return false;
        }
        public override void doubler(Vehicule v) { }
    }
}
