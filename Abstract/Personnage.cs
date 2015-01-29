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
using System.Windows;

namespace ThreePlaySim.Abstract
{
	/// <summary>
	/// Description of Personnage.
	/// </summary>
	public abstract class Personnage : SujetAbstrait
	{
		public ComportementConfrontation comportementConfrontation { get; set; }
		public ComportementEmettreUnSon comportementEmettreUnSon { get; set; }
        public Point Position { get; set; }
        public SimulationAbstraite Context { get; set; }
		public string Nom { get; set; }
				
		
		public Personnage(string nom)
		{
			this.Nom = nom;
			comportementConfrontation = null;
			comportementEmettreUnSon = null;
            Position = new Point(100, 100);
            observateurList = new List<ObservateurAbstrait>();
		}

        public abstract string Afficher();

		
        public string Confrontation(){
        	return comportementConfrontation.Confrontation();
        }


        public string EmmettreUnSon(){
        	return comportementEmettreUnSon.EmmettreSon();
        }

        public virtual void SeDeplacer(int x, int y){
           
            if (x >= 30)
                return;
            if (y >= 25)
                return;

            if (Position != new Point(100, 100))
            {
                Context.Grid[Position.X, Position.Y].Personnage = null;
                Context.Grid[Position.X, Position.Y].FontColor = Context.Grid[Position.X, Position.Y].DefaultFont;
            }

            Context.Grid[x,y].Personnage = this;
            Position = new Point(x,y);
        }
  
        public abstract void Action();
	}
}
