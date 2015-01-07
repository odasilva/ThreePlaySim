/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 06/01/2015
 * Time: 14:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ThreePlaySim.Abstract
{
	/// <summary>
	/// Description of Personnage.
	/// </summary>
	public abstract class Personnage
	{
		public ComportementConfrontation comportementConfrontation { get; set; }
		public ComportementEmettreUnSon comportementEmmettreUnSon { get; set; }
		public string Nom { get; set; }
				
		
		public Personnage(string nom)
		{
			this.Nom = nom;
		}

        public abstract string Afficher();

		
        public string Confrontation(){
        	return comportementConfrontation.Confrontation();
        }


        public string EmmettreUnSon(){
        	return ComportementEmettreUnSon.EmmettreSon();
        }

        public string SeDeplacer(){
        	return "";
        }
	}
}
