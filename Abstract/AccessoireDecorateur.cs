using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreePlaySim.Abstract
{
    public abstract class AccessoireDecorateur : Accessoire
    {
        protected Accessoire Accessoire { get; set; }

        public override String Utiliser()
        {
            if (Accessoire != null)
                return Accessoire.Utiliser();
            else
                return "";
        }


        public AccessoireDecorateur(Accessoire accessoire)
            : base(accessoire.Nom,accessoire.Img)
        {
            Accessoire = accessoire;
        }
    }
}
