using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using ThreePlaySim.Abstract;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Data;

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
        public bool Accessible { get; set; }
        public Personnage Personnage
        {
            get { return personnage; }
            set
            {
                personnage = value;
                RaiseEvent("Value");
                if(personnage != null && personnage.Accessoire != null)
                {
                    ImgSource = new System.Windows.Media.Imaging.BitmapImage(new Uri(personnage.Accessoire.Img, UriKind.Relative));
                }
                else
                {
                    ImgSource = null;        
                }
                    
            }
        }
        private ImageSource imgSource;
        public ImageSource ImgSource
        {
            get
            {
                return imgSource;
            }

            set
            {
                imgSource = value;
                RaiseEvent("ImgSource");
            }
        }
        public SolidColorBrush FontColor
        {
            get { return fontColor == null ? defaultFont : fontColor; }
            set
            {
                fontColor = value;
                RaiseEvent("FontColor");
            }
        }
        private SolidColorBrush defaultFont;
        public SolidColorBrush DefaultFont { get { return defaultFont; } set { defaultFont = value; } }
        private SolidColorBrush fontColor;
        public Point Coordonnees { get; set; }
     
        
        
        public Area(Point coordonnees, bool isAccessible = true)
        {
            Coordonnees = coordonnees;
            Accessible = isAccessible;
        }

        public Area()
        {
            Accessible = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaiseEvent(string propertyName)
        {
           if(PropertyChanged != null)
           {
               PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
           }
        }
    }
}
