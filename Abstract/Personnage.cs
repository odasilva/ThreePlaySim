/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 06/01/2015
 * Time: 14:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Collections.Generic;

namespace ThreePlaySim.Abstract
{
	/// <summary>
	/// Description of Personnage.
	/// </summary>
	public abstract class Personnage : SujetAbstrait
	{
		public ComportementConfrontation comportementConfrontation { get; set; }
		public ComportementEmettreUnSon comportementEmettreUnSon { get; set; }
		public string Nom { get; set; }
				
		
		public Personnage(string nom)
		{
			this.Nom = nom;
			comportementConfrontation = null;
			comportementEmettreUnSon = null;
            observateurList = new List<ObservateurAbstrait>();
		}

        public abstract string Afficher();

		
        public string Confrontation(){
        	return comportementConfrontation.Confrontation();
        }


        public string EmmettreUnSon(){
        	return comportementEmettreUnSon.EmmettreSon();
        }

        public virtual void SeDeplacer(){
           var mapitem = observateurList.First(O => O is MapItem) as MapItem;
           mapitem.MiseAjourPosition();
        }
  
        public abstract void Action();
	}
}
