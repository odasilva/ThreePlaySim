using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.FootballPlaySim
{
    public abstract class ComportementJoueurDeFoot
    {
        protected Joueur joueur;
        public ComportementJoueurDeFoot(Joueur j)
        {
            joueur = j;
        }
        public abstract void PasserLaBalle();
        public abstract void FrapperAuButs();
        public abstract void Dribbler(Joueur adversaire);
    }
}
