using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ThreePlaySim.Abstract
{
    public abstract class Accessoire
    {
        public String Nom {get;set;}
        private Bitmap img;
        public Bitmap Img
        {
            get { return img; }
            set { img = value; }
        }

        public BitmapImage {get;set;}

        public Accessoire(string nomAccessoire, Bitmap image)
        {
            Nom = nomAccessoire;
            img = image;
        }

        public abstract void Utiliser();
    }
}

