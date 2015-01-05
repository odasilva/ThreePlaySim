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
        public MapItem() : base()
        {
            Size = new System.Drawing.Size(15, 15);
            Image = new Bitmap(@"C:\Users\jerome\Documents\GitHub\ThreePlaySim\FootballPlaySim\images\bluePawn.png");
            SizeMode = PictureBoxSizeMode.StretchImage;
            Location = new Point(200, 700);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
        }
    }
}
