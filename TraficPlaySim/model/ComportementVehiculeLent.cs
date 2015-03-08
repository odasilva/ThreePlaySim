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
        public const int VITESSE = 1;
        public ComportementVehiculeLent(Vehicule v) : base(v) { }
        public override void rouler() {
            if (vehicule.Position.X - VITESSE >= 0)
                vehicule.SeDeplacer(vehicule.Position.X - VITESSE, vehicule.Position.Y);
            else
            {
                if (vehicule.Position.Y > 12)
                    vehicule.SeDeplacer(29, vehicule.Position.Y - 12);
                else
                {
                    vehicule.SeDeplacer(0, vehicule.Position.Y);
                }
            }
        }
        public override Boolean cederLePassage() {
            return false;
        }
        public override void doubler(Vehicule v) { }
    }
}
