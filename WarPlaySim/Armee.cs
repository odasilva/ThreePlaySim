using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.WarPlaySim
{
    public class Armee
    {
        public List<Personnage> ListPersonnages;
        public SolidColorBrush FontColor { get; set; }
        private string nom;
        public int Score;
        public String Nom
        {
            get { return nom; }
        }
      

        public Armee(string _nom)
        {
            nom = _nom;
            ListPersonnages = new List<Personnage>();
            Score = 0;
        }

        public void AddJoueur(Personnage p)
        {
            j.Armee = this;
            ListPersonnages.Add(p);
        }
    }
}
