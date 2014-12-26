using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreePlaySim.FootballPlaySim;

namespace ThreePlaySim.Abstract
{
    public class SimulationFabrique : FabriqueAbstraite
    {
        public override SimulationAbstraite CreerSimulationFootball(Equipe _equipe1,Equipe _equipe2)
        {
            return new SimulationFootball { Equipe1 = _equipe1, Equipe2 = _equipe2 };
        }

       
    }
}
