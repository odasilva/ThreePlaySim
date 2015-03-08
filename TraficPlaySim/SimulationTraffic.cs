/*
 * Created by SharpDevelop.
 * User: jcambray
 * Date: 15/12/2014
 * Time: 14:36
 */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ThreePlaySim.Abstract;
using System.Windows.Media;
using System.Windows;
using ThreePlaySim.TraficPlaySim.model;

namespace ThreePlaySim.TraficPlaySim
{

    public class SimulationTraffic : SimulationAbstraite
    {
        public ParcAutomobile parcAuto;
        public ParcFeu parcFeu;
        
        public SimulationTraffic(string xmlfile, string mapFile)
            : base(mapFile) { }

        public override void PlacerPersonnages()
        {
            foreach (Personnage p in ListPersonnage)
            {
                p.SeDeplacer(p.Position.X, p.Position.Y);
                if (p is Feu)  {
                    ((Feu)p).changerEtat();
                }
            }
        }

        protected override void SetColorToArea() {}

        public override void InitObservateurs() {
            base.InitObservateurs();
        }

        public override void Routine()  {}

    }
}
