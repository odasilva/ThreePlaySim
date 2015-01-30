using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreePlaySim.Abstract;
using System.Drawing;

namespace ThreePlaySim.FootballPlaySim
{
    public class Ballon : Accessoire
    {
        public Ballon(string nom,string image)
            : base(nom,image)
        {

        }

        public override void Utiliser()
        {
            throw new NotImplementedException();
        }
    }
}
