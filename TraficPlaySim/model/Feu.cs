using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.TraficPlaySim.model
{
    public class Feu : ThreePlaySim.Abstract.Personnage
    {
        public const int ETAT_ROUGE = 0;
        public const int ETAT_VERT = 1;
        public int etat = ETAT_VERT;
        public const int NOMBRE_TOUR_CHG_ETAT = 5;
        public int number_tr = 0;
        SimulationAbstraite simulation;

        public Feu(string nom, string x, string y, SimulationAbstraite _simulation) : base (nom) {
            Nom = nom;
            Position = new Point(Double.Parse(x), Double.Parse(y));
            simulation = _simulation;
        }

        public void changerEtat() {
            if (etat == ETAT_ROUGE)
                etat = ETAT_VERT;
            else
                etat = ETAT_ROUGE;

            Notify(Nom + "Observateur", "Le feu " + Nom + " vient de passer à l'etat " + ((etat == ETAT_ROUGE) ? "rouge" : "vert"));

            if (etat == Feu.ETAT_ROUGE) {
                simulation.Grid[Position.X, Position.Y].FontColor = Brushes.Red;
            }
            else {
                simulation.Grid[Position.X, Position.Y].FontColor = Brushes.Green;
            }
        }

        public override void Action()
        {
            if (number_tr++ == NOMBRE_TOUR_CHG_ETAT)
            {
                number_tr = 0;
                changerEtat();
            } 
        }

        public override string Afficher()
        {
            return "";
        }

    }
}
