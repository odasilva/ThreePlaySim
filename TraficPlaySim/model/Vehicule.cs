using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ThreePlaySim.Abstract;
using ThreePlaySim.TraficPLaySim.model;

namespace ThreePlaySim.TraficPlaySim.model
{
    public class Vehicule : ThreePlaySim.Abstract.Personnage
    {
        public int quantite_carburant = 50;
        public ComportementVehicule comportementVehicule;
        public ComportementConfrontation comportementConfrontation;
        public SimulationAbstraite simulation;

        public Vehicule(String nom, String x, String y, String _type, SimulationAbstraite _simulation)
            : base(nom)
        {
            Nom = nom;
            Position = new Point(Double.Parse(x), Double.Parse(y));
            if (_type.Equals("VOITURE"))
                comportementVehicule = new ComportementVehiculeSportif(this);
            else if (_type.Equals("CAMION"))
                comportementVehicule = new ComportementVehiculeLent(this);

            comportementConfrontation = new ComportementConfrontationVehicule(this);

            simulation = _simulation;
        }

        public override string Afficher()
        {
            return "";
        }

        public override void Action()
        {
            if (simulation.Grid[Position.X, Position.Y + 1].Personnage != null && simulation.Grid[Position.X, Position.Y + 1].Personnage is Feu && ((Feu)simulation.Grid[Position.X, Position.Y + 1].Personnage).etat == Feu.ETAT_ROUGE)
            {

            }
            else if (simulation.Grid[Position.X, Position.Y + 2].Personnage != null && simulation.Grid[Position.X, Position.Y + 2].Personnage is Feu && ((Feu)simulation.Grid[Position.X, Position.Y + 2].Personnage).etat == Feu.ETAT_ROUGE)
            {

            }
            else if (simulation.Grid[Position.X, Position.Y + 3].Personnage != null && simulation.Grid[Position.X, Position.Y + 3].Personnage is Feu && ((Feu)simulation.Grid[Position.X, Position.Y + 3].Personnage).etat == Feu.ETAT_ROUGE)
            {

            } else {
                 comportementVehicule.rouler();
            }
               
            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 0, 0, 10));
        }


    }
}
