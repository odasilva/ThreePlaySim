using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ThreePlaySim.TraficPlaySim.model
{
    public class ParcAutomobile
    {
        List<Vehicule> mesVehicules;
        public SolidColorBrush FontColor { get; set; }

        public ParcAutomobile()
        {
            mesVehicules = new List<Vehicule>();
        }

        public void AddComposantRoutier(Vehicule cr)
        {
            mesVehicules.Add(cr);
        }

        public void deleteComposantRoutier(Vehicule cr)
        {
            mesVehicules.Remove(cr);
        }

        public List<Vehicule> ListComposantRoutier()
        {
            return mesVehicules;
        }
    }
}
