using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ThreePlaySim.FootballPlaySim
{
    public partial class FootballMap : Form
    {
        private SimulationFootball sim;
        public FootballMap(SimulationFootball simFoot)
        {
            InitializeComponent();
            sim = simFoot;
        }
    }
}
