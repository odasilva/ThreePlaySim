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
        private Accessoire accessoire;
        public Accessoire Accessoire
        {
            get { return accessoire; }
            set { accessoire = value; }
        }

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

		
        public void Confrontation(Personnage ennemi){
             comportementConfrontation.Confrontation(ennemi);
        }


        public string EmmettreUnSon(){
        	return comportementEmettreUnSon.EmmettreSon();
        }

        public virtual void SeDeplacer(double x, double y){
           
            if (x >= 30)
                return;
            if (y >= 25)
                return;
            if (!Context.Grid[x, y].Accessible)
                return;

            if (Position != new Point(100, 100))
            {
                Context.Grid[Position.X, Position.Y].Personnage = null;
                Context.Grid[Position.X, Position.Y].FontColor = Context.Grid[Position.X, Position.Y].DefaultFont;
            }

            Context.Grid[x,y].Personnage = this;
            Position = new Point(x,y);
            //Notify( Nom + "Observateur", String.Format("{0} se deplace vers la position {1};{2}",Nom, Position.X, Position.Y));
        }

        public double GetDistance(Point pointA, Point pointB)
        {
            return Math.Sqrt(Math.Pow(pointB.X - pointA.X, 2) + Math.Pow(pointB.Y - pointA.Y, 2));
        }

        public List<Area> GetAreaAdjacentes()
        {
            var areas = new List<Area>();
            if(Position != new Point(0,0))
                areas.Add(Context.Grid[Position.X+1,Position.Y-1]);
            if (Position.X > 0)
                areas.Add(Context.Grid[Position.X - 1, Position.Y]);
            if (Position != new Point(0,24))
                areas.Add(Context.Grid[Position.X - 1, Position.Y+1]);
            if (Position.Y <= 23)
                areas.Add(Context.Grid[Position.X, Position.Y+1]);
            if (Position != new Point(29,24))
                areas.Add(Context.Grid[Position.X + 1, Position.Y +1]);
            if (Position.X < 29)
                areas.Add(Context.Grid[Position.X + 1, Position.Y]);
            if (Position != new Point(29,0))
                areas.Add(Context.Grid[Position.X + 1, Position.Y-1]);
            if (Position.Y > 0)
                areas.Add(Context.Grid[Position.X, Position.Y-1]);
            return areas;
        }

        public abstract void Action();
	}
}
