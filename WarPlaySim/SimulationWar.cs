/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 15/12/2014
 * Time: 14:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.WarPlaySim
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class SimulationWar
	{
		public List<Personnage> ListPersonnage;
		 
		public SimulationWar()
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
