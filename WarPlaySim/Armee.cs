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
        public List<Soldat> ListSoldats;
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
            ListSoldats = new List<Soldat>();
            Score = 0;
        }

        public void AddSoldat(Soldat p)
        {
            p.Armee = this;
            ListSoldats.Add(p);
        }
    }
}
