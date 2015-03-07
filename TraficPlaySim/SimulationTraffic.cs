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
            }
        }

        protected override void SetColorToArea() {}

        public override void InitObservateurs() {
            base.InitObservateurs();
            foreach(Personnage p in ListPersonnage) {
                bool isVehicule = (p is Vehicule);
                if (!isVehicule) {
                    // p.Attach(new AlerteurChangementEtatFeu("Infraction", this, (Feu)p));
                }
            }
        }

        public override void Routine()
        {

            if(ListPersonnage.Count == 0 ) {
                Timer.Stop();
                SimView.Close();
                return;
            }

            foreach (Personnage p in ListPersonnage) {
                if(((Vehicule)p).quantite_carburant <= 0) {
                    ListPersonnage.Remove(p);
                }

                p.Action();

                bool isVehicule = (p is Vehicule);
                if (!isVehicule)
                {
                    if (((Feu)p).etat == Feu.ETAT_ROUGE)
                    {
                        Grid[p.Position.X, p.Position.Y].FontColor = Brushes.Red;
                    }
                    else { 
                        Grid[p.Position.X, p.Position.Y].FontColor = Brushes.Green;
                    }
                }
            }
        }

    }
}
