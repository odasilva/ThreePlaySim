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
        public Map Grid { get { return SimView.Map; } }
        private String mapFileContent;

		public SimulationAbstraite(string mapFile)
		{
            mapFileContent = mapFile;
			ListPersonnage = new List<Personnage>();
            SimView = new SimulationView(this);
            Timer = new DispatcherTimer(DispatcherPriority.SystemIdle);
            Timer.Interval = TimeSpan.FromMilliseconds(400);
            Timer.Tick += Routine;
            Timer.Start();
		}

        public SimulationAbstraite()
        {
            // TODO: Complete member initialization
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
            SetAreasAccessibility();
            SetColorToArea();
            InitObservateurs();
            PlacerPersonnages();
            SimView.Show(); 
        }

        protected abstract void SetColorToArea();

        protected virtual void SetAreasAccessibility()
        {
            var distinctLines = mapFileContent.Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
            for(int i = 0 ;i < 30;i++)
            {
                for (int j = 0; j < 25; j++)
                {

                    if (distinctLines[i].ElementAt(j) == '0')
                    {
                        Grid[i, j].Accessible = true;
                        Grid[i, j].DefaultFont = System.Windows.Media.Brushes.White;
                    }
                    else
                    {
                        Grid[i, j].Accessible = false;
                        Grid[i, j].DefaultFont = System.Windows.Media.Brushes.Black;
                    }
                }
            }
        }

        public virtual void InitObservateurs()
        {
            ListPersonnage.ForEach(P => P.Attach(new ObservateurPersonnage(P, this, P.Nom + "Observateur")));
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

        public abstract void PlacerPersonnages();
        

        /// <summary>
        /// Code éxecuté en boucle tout au long de la simulation.
        /// (déplacements des personnages, IA...)
        /// </summary>
        public abstract void Routine();

    }
}
