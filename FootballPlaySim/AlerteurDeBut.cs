using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.FootballPlaySim
{
    public class AlerteurDeBut : ObservateurAbstrait
    {
        private SimulationFootball simulation;
        private Joueur sujet;

        public AlerteurDeBut(string nom,SimulationFootball sim,Joueur joueurObserve)
            : base(nom)
        {
            simulation = sim;
            sujet = joueurObserve;
        }

        public override void MiseAjour(string message)
        {
            sujet.Equipe.Score++;
            simulation.SimView.TBNotification.Text += String.Format("BUT POUR {0}. Le score est de {1} à {2}", sujet.Equipe.Nom, simulation.Equipe1.Score, simulation.Equipe2.Score)
                + Environment.NewLine;

        }


    }
}
