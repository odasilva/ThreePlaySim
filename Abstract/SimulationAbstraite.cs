using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Threading;


namespace ThreePlaySim.Abstract
{
    abstract public class SimulationAbstraite
    {
        public List<Personnage> ListPersonnage {get;set;}
        public SimulationView SimView { get; set; }
        public DispatcherTimer Timer { get; set; }

		public SimulationAbstraite()
		{
			ListPersonnage = new List<Personnage>();
            SimView = new SimulationView();
            Timer = new DispatcherTimer();
            Timer.Interval = new TimeSpan(0,0,1);
            Timer.Tick += Routine;
            Timer.Start();
		}

        void Routine(object sender, EventArgs e)
        {
           foreach(var p in ListPersonnage)
           {
               p.Action();
           }
        }

        public void RenderMap()
        {
            SimView.Show(); 
        }
		
		public string AfficherTous()
		{
			return "";
		}
		
		public void ChangerComportement(Personnage personnage, ComportementConfrontation comportementConfrontation)
		{
			foreach(Personnage perso in ListPersonnage)
			{
				if(perso.GetType().Name == personnage.GetType().Name && perso.Nom == personnage.Nom)
					perso.comportementConfrontation = comportementConfrontation;
			}	
			
		}
		
		public void AjoutePersonnage(Personnage personnage)
		{
            personnage.Context = this;
			ListPersonnage.Add(personnage);
		}
		
		public string EmmettreSontous()
		{
			string sonTous = "";
			foreach(Personnage perso in ListPersonnage)
			{
				sonTous += perso.EmmettreUnSon()+"\n";
			}
			return sonTous;
		}
		
		public string LancerCombat()
		{
			return "";
		}


        /// <summary>
        /// Code éxecuté en boucle tout au long de la simulation.
        /// (déplacements des personnages, IA...)
        /// </summary>
        public abstract void Routine();

    }
}
