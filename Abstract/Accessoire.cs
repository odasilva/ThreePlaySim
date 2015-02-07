using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media;


namespace ThreePlaySim.Abstract
{
    public abstract class Accessoire
    {
        public String Nom {get;set;}
        private string img;
        public String Img
        {
            get { return img; }
            set { img = value; }
        }


        public Accessoire(string nomAccessoire, string image)
        {
            Nom = nomAccessoire;
            img = image;
        }

        public abstract String Utiliser();
    }
}

