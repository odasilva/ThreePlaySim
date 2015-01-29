using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using ThreePlaySim.Abstract;
using System.Windows.Media;
using System.ComponentModel;

namespace ThreePlaySim
{
    public class Area : INotifyPropertyChanged
    {
        /// <summary>
        /// Coordonées de l'area en pixels
        /// </summary>
        public String Value
        {
            get
            {
                if (Personnage == null)
                    return "";
                if (Personnage.Nom.Length > 3)
                    return new String(Personnage.Nom.Take(3).ToArray());
                return Personnage.Nom[1].ToString();
            }
        }
        private Personnage personnage;
        public Personnage Personnage
        {
            get { return personnage; }
            set
            {
                personnage = value;
                RaiseEvent("Value");
            }
        }

        public SolidColorBrush FontColor
        {
            get { return fontColor == null ? defaultFont : fontColor; }
            set { fontColor = value; }
        }
        private SolidColorBrush defaultFont = Brushes.White;
        private SolidColorBrush fontColor;
        public Point Coordonnees { get; set; }
        
        
        public Area(Point coordonnees)
        {
            Coordonnees = coordonnees;
        }

        public Area()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaiseEvent(string propertyName)
        {
           if(PropertyChanged != null)
           {
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
           }
        }

    }
}
