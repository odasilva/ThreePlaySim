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
        public MapItem(string nom,Point placement) : base()
        {
            Size = new System.Drawing.Size(15, 15);
            Image = ThreePlaySim.Properties.Resources.pionBleu;
            SizeMode = PictureBoxSizeMode.StretchImage;
            Location = placement;
        }
    }
}
