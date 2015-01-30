/*
 * Created by SharpDevelop.
 * User: jcambray
 * Date: 15/12/2014
 * Time: 14:36
 */
using System;
using System.Collections;
using System.Collections.Generic;
using ThreePlaySim.Abstract;
using System.Windows.Media;

namespace ThreePlaySim.FootballPlaySim
{
	
	public class SimulationFootball : SimulationAbstraite
	{
        public Equipe Equipe1 { get; set; }
        public Equipe Equipe2 { get; set; }

        public Ballon Ballon { get; set; }
      
        

		public SimulationFootball(String xmlContent)
            : base()
		{
            Ballon = new Ballon("ballon", @"..\images\ball.png");
		}

        public override void PlacerPersonnages()
        {
            foreach (Joueur j in ListPersonnage)
            {
                if (j.Equipe.Nom == Equipe1.Nom)
                {
                    if (j.Placement == "DG")
                    {
                        j.SeDeplacer(25,2);
                        continue;
                    }

                    if (j.Placement == "DC")
                    {
                        j.SeDeplacer(25, 12);
                        continue;
                    }

                    if (j.Placement == "DD")
                    {
                        j.SeDeplacer(25, 22);

                        continue;
                    }

                    if (j.Placement == "MG")
                    {
                        j.SeDeplacer(20, 2);
                        continue;
                    }

                    if (j.Placement == "MD")
                    {
                        j.SeDeplacer(20, 22);
                        continue;
                    }

                    if (j.Placement == "BU")
                    {
                        j.SeDeplacer(15, 12);
                        continue;
                    }
                }

                if (j.Placement == "DG")
                {
                    continue;
                }

                if (j.Placement == "DC")
                {
                    continue;
                }

                if (j.Placement == "DD")
                {
                    continue;
                }

                if (j.Placement == "MG")
                {
                    continue;
                }

                if (j.Placement == "MD")
                {
                    continue;
                }

                if (j.Placement == "BU")
                {
                    continue;
                }

            }

            Equipe1.ListJoueurs[1].Accessoire = Ballon;
        }


        public override void Routine()
        {
           
            foreach(Personnage p in ListPersonnage)
            {
                p.Action();
            }
        }
	}
}
