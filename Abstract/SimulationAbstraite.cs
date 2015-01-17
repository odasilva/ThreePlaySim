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
        public Area[,] Grid { get; set; }
        private String mapXml;
        private Bitmap fondImg;
		 
		public SimulationAbstraite(String mapXmlContent,Bitmap fond)
		{
			ListPersonnage = new List<Personnage>();
            mapXml = mapXmlContent;
            fondImg = fond;
            LoadMap();	
		}

        private void LoadMap()
        {
            MapFabrique fabrique = new MapFabrique(mapXml);
            Map = fabrique.CreeMap(fondImg, this);
            Map.Grid = new GridFabrique(Properties.Resources.footballMap).CreerGrid();
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

        abstract protected void LoadGrid();
    }
}
