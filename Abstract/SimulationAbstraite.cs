using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreePlaySim.Abstract
{
    abstract public class SimulationAbstraite
    {
        protected System.Windows.Forms.Form map;
        abstract public void RenderMap();
    }
}
