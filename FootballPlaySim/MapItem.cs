using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ThreePlaySim.FootballPlaySim
{
    public class MapItem : PictureBox
    {
        private Area actualArea;
        public Area ActualArea
        {
            get { return actualArea; }
            set
            {
                actualArea = value;
                Location = actualArea.Location;
            }
        }
        public Point GridLocation
        {
            get
            {
                return actualArea.GridLocation;
            }
        }

        public MapItem(string nom,Area a) : base()
        {
            Size = new System.Drawing.Size(15, 15);
            Image = ThreePlaySim.Properties.Resources.pionBleu;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Location = a.Location;
            ActualArea = a;
        }
    }
}
