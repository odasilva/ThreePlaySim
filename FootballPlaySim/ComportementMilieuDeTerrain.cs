using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreePlaySim.FootballPlaySim
{
    class ComportementMillieuDeTerrain : ComportementJoueurDeFoot
    {
        public ComportementMillieuDeTerrain(Joueur j)
            : base(j)
        {
            
        }
        public override void PasserLaBalle()
        {
            var receveur = joueur.Equipe.ListJoueurs.Find(J => J.Poste == "attaquant");
            joueur.Accessoire = null;
            receveur.RecoitLeBallon();
            joueur.Notify(joueur.Nom + "Observateur", String.Format("{0} {1} passe le ballon à {2} {3}", joueur.Prenom, joueur.Nom, receveur.Prenom, receveur.Nom));
        }

        public override void FrapperAuButs()
        {
            joueur.Notify(joueur.Nom + "Observateur", String.Format("Sachant qu'il n'est pas très abile de ses pieds, {0} {1} préfère passer le ballon", joueur.Prenom, joueur.Nom));
            joueur.PasserLaBalle();
        }

        public override void Dribbler(Joueur adversaire)
        {
            throw new NotImplementedException();
        }
    }
}
