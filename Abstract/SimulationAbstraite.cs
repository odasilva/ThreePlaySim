using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreePlaySim.Abstract
{
    abstract public class SimulationAbstraite
    {
        public System.Windows.Forms.Form Map { get; set; }    
        public List<Personnage> ListPersonnage {get;set;}
        public Area[,] Grid { get; set; }
		 
		public SimulationAbstraite()
		{
			ListPersonnage = new List<Personnage>();				
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

        abstract public void LoadMap();
        abstract public void RenderMap();   
        abstract protected void LoadGrid();
    }
}
