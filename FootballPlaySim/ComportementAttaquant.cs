using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreePlaySim.FootballPlaySim
{
    public class ComportementAttaquant : ComportementJoueurDeFoot
    {

        private Joueur joueur;

        public ComportementAttaquant(Joueur j)
        {
            joueur = j;
        }

        public override void PasserLaBalle()
        {
            joueur.Notify(joueur.Nom + "Observateur", String.Format("{0} {1} est attaquant. il ne fait pas de passes, il marque des buts!!", joueur.Prenom, joueur.Nom));
            joueur.FrapperAuxBut();
        }

        public override void FrapperAuButs()
        {
            joueur.Notify(joueur.Nom + "Observateur", String.Format("{0} {1} frappe aux buts va t'il marquer????", joueur.Prenom, joueur.Nom));
            var r = new Random();
            if(r.Next(1, 3) != 1)
            {
                joueur.Notify(joueur.Nom + "Observateur", String.Format("{0} {1} à raté son tir",joueur.Prenom,joueur.Nom));
                joueur.PerdLeBallon();
                joueur.EquipeAdverse().ListJoueurs.First(P => P.Poste == "defenseur").RecoitLeBallon();
            }
            else
            {
                joueur.Notify(joueur.Nom + "Observateur", String.Format("BUT DE {0} {1}", joueur.Prenom.ToUpper(), joueur.Nom.ToUpper()));
                joueur.Notify("alerteurDeBut", "");
            }
        }

        public override void Dribbler(Joueur adversaire)
        {
            var r = new Random();
            if(r.Next(1,2) == 1)
            {
                joueur.Notify(joueur.Nom + "Observateur", String.Format("{0} {1} à dribbler {2} {3}", joueur.Prenom, joueur.Nom,adversaire.Prenom,adversaire.Nom));
            }
        }
    }
}
