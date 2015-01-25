using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ThreePlaySim.Abstract
{
    abstract public class SimulationAbstraite
    {
        public SimulationMap Map { get; set; }    
        public List<Personnage> ListPersonnage {get;set;}
        private String mapXml;
        private Bitmap fondImg;
		 
		public SimulationAbstraite(String mapXmlContent,Bitmap fond)
		{
			ListPersonnage = new List<Personnage>();
            mapXml = mapXmlContent;
            fondImg = fond;
            LoadMap();	
            
		}

        public void Start()
        {
            Map.StartTimer();
        }

        public void Pause()
        {
            Map.stopTimer();
        }

        private void LoadMap()
        {
            MapFabrique fabrique = new MapFabrique(mapXml);
            Map = fabrique.CreeMap(fondImg, this);
            Map.Grid = new GridFabrique(mapXml).CreerGrid();
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
		
		public void CreationPersonnages(Personnage personnage)
		{
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


        public void RenderMap()
        {
            System.Windows.Forms.Application.Run(Map);
        }

        /// <summary>
        /// Code éxecuté en boucle tout au long de la simulation.
        /// (déplacements des personnages, IA...)
        /// </summary>
        public abstract void Routine();

    }
}
