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
           var joueurAdversaire = adversaire as Joueur;
           if(joueurAdversaire.Accessoire != null)
           {
               var r = new Random();
               if(r.Next(1,3) == 1)
               {
                   joueurAdversaire.PerdLeBallon();
                   joueur.RecoitLeBallon();
                   joueur.SeDeplacer(joueur.Position.X + 1, joueur.Position.Y);
                   joueur.Notify(joueur.Nom + "Observateur", String.Format("{0} {1} à pri le ballon dans les pieds de {2} {3}",joueur.Prenom,joueur.Nom,joueurAdversaire.Prenom,joueur.Nom));
               }
           }
        }
    }
}
