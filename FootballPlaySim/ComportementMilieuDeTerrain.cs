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
            var coequipiers = joueur.Equipe.ListJoueurs.Where(J => J.Poste == "milieu");
            var r = new Random();
            var i = r.Next(0, coequipiers.Count());
            joueur.Accessoire = null;
            var receveur = coequipiers.ToList()[i];
            receveur.RecoitLeBallon();
            joueur.Notify(joueur.Nom + "Observateur", String.Format("{0} {1} passe le ballon à {2} {3}", joueur.Prenom, joueur.Nom, receveur.Prenom, receveur.Nom));
        }
        public override void PasserLaBalle()
        {
            throw new NotImplementedException();
        }

        public override void FrapperAuButs()
        {
            throw new NotImplementedException();
        }

        public override void Dribbler(Joueur adversaire)
        {
            throw new NotImplementedException();
        }
    }
}
