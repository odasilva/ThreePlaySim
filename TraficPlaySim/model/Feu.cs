using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ThreePlaySim.TraficPlaySim.model
{
    public class Feu : ThreePlaySim.Abstract.Personnage
    {
        public const int ETAT_ROUGE = 0;
        public const int ETAT_VERT = 1;
        public int etat = ETAT_VERT;
        int number_tr = 0;

        public Feu(string nom, string x, string y) : base (nom) {
            Nom = nom;
            Position = new Point(Double.Parse(x), Double.Parse(y));
        }

        public void changerEtat() {
            if (etat == ETAT_ROUGE)
                etat = ETAT_VERT;
            else
                etat = ETAT_ROUGE;

            // Notify(Nom, "Le feu " + Nom + " vient de passer à l'etat " + ((etat == ETAT_ROUGE) ? "rouge" : "vert"));
        }

        public override void Action()
        {
            if (number_tr++ == 5) {
                number_tr = -5;
                changerEtat();
            } 
        }

        public override string Afficher()
        {
            return "";
        }

    }
}
