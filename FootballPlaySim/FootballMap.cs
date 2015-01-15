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
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var point = joueur.Location;
            point.Y++;
            joueur.Location = new Point(point.X,point.Y);
        }

        private void FootballMap_Load(object sender, EventArgs e)
        {
            AddItem(new MapItem("player",new Point(200,150)));
        }

        public void AddItem(MapItem item)
        {
            Controls.Add(item);
            Controls.SetChildIndex(item,0);
        }


    }
}
