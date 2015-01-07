using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreePlaySim.Abstract
{
    abstract public class SimulationAbstraite
    {
        protected System.Windows.Forms.Form map;
        abstract public void RenderMap();       
        public List<Personnage> ListPersonnage {get;set}
		 
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
			foreach(Personnage perso in ListPersonnage)
			{
				perso.EmmettreUnSon();
			}
		}
		
		public string LancerCombat()
		{
			return "";
		}
    }
}
