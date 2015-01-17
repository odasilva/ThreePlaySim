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

namespace ThreePlaySim.FootballPlaySim
{
    public partial class FootballMap : Form
    {
        private SimulationFootball sim;
        private Area[,] grid;
        private PictureBox fond;
        private List<MapItem> joueursEquipe1;
        private List<MapItem> joueursEquipe2;

        public FootballMap(SimulationFootball simFoot)
        {
            InitializeComponent();
            joueursEquipe1 = new List<MapItem>();
            joueursEquipe2 = new List<MapItem>();
            sim = simFoot;
            LoadMap();
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

        private void LoadMap()
        {
            WindowState = FormWindowState.Maximized;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(ThreePlaySim.Properties.Resources.footballMap);
            var hauteurTerrain = int.Parse(doc.GetElementsByTagName("dimension")[0].Attributes["height"].Value);
            var largeurTerrain = int.Parse(doc.GetElementsByTagName("dimension")[0].Attributes["width"].Value);
       
            fond = new PictureBox();
            fond.Image = Properties.Resources.terrain;
            fond.Height = hauteurTerrain;
            fond.Width = largeurTerrain;
            Controls.Add(fond);

            LoadGrid();

            var it = new MapItem("nom", grid[10, 29]);
            AddItem(it);
            joueursEquipe1.Add(it);

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
