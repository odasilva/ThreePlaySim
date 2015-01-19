using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ThreePlaySim.Properties;
using ThreePlaySim.FootballPlaySim;
using ThreePlaySim.TraficPlaySim;
using ThreePlaySim.WarPlaySim;
using ThreePlaySim.Abstract;


namespace ThreePlaySim
{
    public partial class SimulationMap : Form
    {
        private SimulationAbstraite sim;
        public List<List<Area>> Grid { get; set; }
        public PictureBox fond;
        public List<MapItem> MapItems { get; set; }

        public SimulationMap(SimulationAbstraite simulation)
        {
            InitializeComponent();
            MapItems = new List<MapItem>();
            sim = simulation;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void FootballMap_Load(object sender, EventArgs e)
        {
            //LoadMap();
        }

        public void AddItem(MapItem item)
        {
            MapItems.Add(item);
            Controls.Add(item);
            Controls.SetChildIndex(item,0);
        }


        public Area GetAreaByProperty(string propertyValue)
        {
            return Grid.SelectMany(L => L = L).First(A => A.Proprietes.ContainsKey(propertyValue));
        }
    }
}
