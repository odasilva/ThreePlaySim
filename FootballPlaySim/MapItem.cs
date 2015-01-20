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
        private Joueur joueur;

        public MapItem(Joueur j,Area a,Bitmap img) : base()
        {
            Size = new System.Drawing.Size(15, 15);
            Image = img;
            SizeMode = PictureBoxSizeMode.StretchImage;
            joueur = j;
            Name = joueur.Nom;
            Location = a.Location;
            ActualArea = a;
        }
    }
}
