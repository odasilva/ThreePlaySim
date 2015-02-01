using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreePlaySim.Abstract;
using System.ComponentModel;
using System.Windows.Documents;

namespace ThreePlaySim
{
    class ObservateurPersonnage : ObservateurAbstrait
    {
        private Personnage sujet;
        private SimulationAbstraite simulation;
        public String notificationString { get; set; }

        public ObservateurPersonnage(Personnage personnage, SimulationAbstraite sim,string nom)
            :base(nom)
        {
            sujet = personnage;
            simulation = sim;
        }

        public override void MiseAjour(String message)
        {
            simulation.SimView.Paragraph.Inlines.Add(message + Environment.NewLine);
        }
    }
}
