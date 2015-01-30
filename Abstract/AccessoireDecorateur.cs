using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreePlaySim.Abstract
{
    public abstract class AccessoireDecorateur : Accessoire
    {
        public Accessoire Accessoire { get; set; }
        public abstract override void Utiliser();


        public AccessoireDecorateur(Accessoire accessoire)
            : base(accessoire.Nom,accessoire.Img)
        {
            Accessoire = accessoire;
        }
    }
}
