using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreePlaySim.Abstract;
using ThreePlaySim.TraficPlaySim.model;

namespace ThreePlaySim.TraficPlaySim
{
    public class AlerteurChangementEtatFeu : ObservateurAbstrait
    {
        private SimulationTraffic simulation;
        private Personnage sujet;

        public AlerteurChangementEtatFeu(string nom, SimulationTraffic sim, Personnage feuObserve)
            : base(nom)
        {
            simulation = sim;
            sujet = feuObserve;
        }

        public override void MiseAjour(string message)
        {
            simulation.SimView.Paragraph.Inlines.Add(String.Format("Une infraction vient d'être comise") + Environment.NewLine);
        }


    }
}
