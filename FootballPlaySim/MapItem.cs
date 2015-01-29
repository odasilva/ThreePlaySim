using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
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

        public MapItem(Personnage perso,Area a) : base()
        {
    
            personnage = perso;
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
