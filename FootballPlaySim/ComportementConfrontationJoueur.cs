using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.FootballPlaySim
{
   public  class ComportementConfrontationJoueur : ComportementConfrontation
    {
       private Joueur joueur;

       public ComportementConfrontationJoueur(Joueur j)
       {
           joueur = j;
       }

        public override void Confrontation(Personnage adversaire)
        {
           
        }
    }
}
