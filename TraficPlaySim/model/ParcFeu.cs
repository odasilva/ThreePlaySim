using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ThreePlaySim.TraficPlaySim.model
{
    public class ParcFeu
    {
        List<Feu> mesFeux;
        public SolidColorBrush FontColor { get; set; }

        public ParcFeu()
        {
            mesFeux = new List<Feu>();
        }

        public void AddComposantRoutier(Feu cr)
        {
            mesFeux.Add(cr);
        }

        public void deleteComposantRoutier(Feu cr)
        {
            mesFeux.Remove(cr);
        }

        public List<Feu> ListComposantRoutier()
        {
            return mesFeux;
        }
    }
}
