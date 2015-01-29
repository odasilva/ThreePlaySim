using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace ThreePlaySim.FootballPlaySim
{
   
    public class Equipe
    {
        public List<Joueur> ListJoueurs;
        public SolidColorBrush FontColor { get; set; }
        private string nom;
        public String Nom
        {
            get { return nom; }
        }

        public Equipe(string _nom)
        {
            nom = _nom;
            ListJoueurs = new List<Joueur>();
        }

        public void AddJoueur(Joueur j)
        {
            j.Equipe = this;
            ListJoueurs.Add(j);
        }
    }
}
