using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using ThreePlaySim.Abstract;

namespace ThreePlaySim
{
    public class MapItem : ObservateurAbstrait
    {
        private Area actualArea;
        public Area ActualArea
        {
            get { return actualArea; }
            set
            {
                actualArea = value;
                PictureBox.Location = actualArea.Location;
            }
        }
        public Point GridLocation
        {
            get
            {
                return actualArea.GridLocation;
            }
        }
        private Personnage personnage;
        public PictureBox PictureBox { get; set; }

        public MapItem(Personnage perso,Area a,Bitmap img) : base()
        {
            PictureBox = new PictureBox();
            PictureBox.Size = new System.Drawing.Size(15, 15);
            PictureBox.Image = img;
            PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            personnage = perso;
            PictureBox.Name = personnage.Nom;
            PictureBox.Location = a.Location;
            ActualArea = a;
            personnage.Attach(this);
        }

        public override void MiseAjour()
        {
            
        }

        public void MiseAjourPosition()
        {
            
        }


    }
}
