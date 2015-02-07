/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 15/12/2014
 * Time: 14:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.WarPlaySim
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class SimulationWar : SimulationAbstraite
	{
        public Armee armeA;
        public Armee armeB;
        public Arc Arc { get; set; }
        public Epee Epee { get; set; }
        public Lance Lance { get; set; }
        public Coeur Coeur { get; set; }




        public SimulationWar(String xmlContent, String mapFile)
            : base(mapFile)
		{
            Arc = new Arc("arc", @"..\images\bow.png");
            Epee = new Epee("epee", @"..\images\sword.png");
            Lance = new Lance("lance", @"..\images\lance.png");
            Coeur = new Coeur("nom", @"..\images\heart.png");
		}
		

        public override void Routine()
        {
            ListPersonnage.ForEach(P => P.Action());
        }

        public override void PlacerPersonnages()
        {

            foreach (Soldat s in ListPersonnage)
            {
                if (s.Type == "Archer")
                    s.Accessoire = new DeFlamme(Arc);
                if (s.Type == "Fantassin")
                    s.Accessoire = new DeFoudre(Epee);
                if (s.Type == "Cavalier")
                    s.Accessoire = Lance;
                if (s.Type == "Princesse")
                    s.Accessoire = Coeur;
            }

            var armeeAInitialPosition = new Point(1,4);
            var armeeBInitialPosition = new Point(28, 4);

            armeA.ListSoldats.ForEach(P =>
            {
                armeeAInitialPosition.Y += 2;
                P.SeDeplacer(armeeAInitialPosition.X, armeeAInitialPosition.Y);
                P.Context.Grid[P.Position.X, P.Position.Y].FontColor = P.Armee.FontColor;
            });

            armeB.ListSoldats.ForEach(P =>
            {
                armeeBInitialPosition.Y += 2;
                P.SeDeplacer(armeeBInitialPosition.X, armeeBInitialPosition.Y);
                P.Context.Grid[P.Position.X, P.Position.Y].FontColor = P.Armee.FontColor;
            });
        }

        protected override void SetColorToArea()
        {
            
        }
    }
}
