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
            //Controls.RemoveByKey("pictureBox1");
            var item = new PictureBox();
            item.Size = new System.Drawing.Size(15, 15);
            //item.Image = new Bitmap(@"C:\Users\jerome\Documents\GitHub\ThreePlaySim\FootballPlaySim\images\bluePawn.png");
            item.Image = ThreePlaySim.Properties.Resources.pionBleu;
            item.SizeMode = PictureBoxSizeMode.StretchImage;
            item.Location = new Point(200, 300);
            item.Name = "cutsomPictureBox";
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.Controls.Add(item);
            Controls.SetChildIndex(item, 0);
        }
    }
}
