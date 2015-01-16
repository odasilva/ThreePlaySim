using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ThreePlaySim.FootballPlaySim
{
    public partial class FootballMap : Form
    {
        private SimulationFootball sim;
        private Area[][] grid;

        public FootballMap(SimulationFootball simFoot)
        {
            InitializeComponent();
            sim = simFoot;
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void FootballMap_Load(object sender, EventArgs e)
        {
            LoadMap();
        }

        public void AddItem(MapItem item)
        {
            Controls.Add(item);
            Controls.SetChildIndex(item,0);
        }

        private void LoadMap()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ThreePlaySim.Properties.Resources.footballMap);
            Height = int.Parse(doc.GetElementsByTagName("dimension")[0].Attributes["height"].Value);
            Width = int.Parse(doc.GetElementsByTagName("dimension")[0].Attributes["width"].Value);
        }

    }
}
