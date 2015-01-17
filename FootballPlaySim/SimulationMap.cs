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
        private Area[,] grid;
        public PictureBox fond;
        private List<MapItem> mapItems;
        private List<MapItem> MapItems;

        public SimulationMap(SimulationAbstraite simulation)
        {
            InitializeComponent();
            mapItems = new List<MapItem>();
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
            Controls.Add(item);
            Controls.SetChildIndex(item,0);
        }

        private void LoadGrid()
        {
            var doc = new XmlDocument();
            doc.LoadXml(Properties.Resources.footballMap);
            var longueurGrid = int.Parse(doc.GetElementsByTagName("map")[0].Attributes["width"].Value);
            var largeurGrid = int.Parse(doc.GetElementsByTagName("map")[0].Attributes["height"].Value);
            var longueurArea = int.Parse(doc.GetElementsByTagName("map")[0].Attributes["tileheight"].Value);
            var largeurArea = int.Parse(doc.GetElementsByTagName("map")[0].Attributes["tilewidth"].Value);
            int x,y;

            grid = new Area[longueurGrid,largeurGrid];

            for(int i = 0; i < longueurGrid; i++)
            {
                x = longueurArea + i * longueurArea;
                for(int j = 0; j < largeurGrid; j++)
                {
                    y = j + j * largeurArea;
                    grid[i, j] = new Area(grid.Length, x, y,i,j);
                }
            }
        }

    }
}
