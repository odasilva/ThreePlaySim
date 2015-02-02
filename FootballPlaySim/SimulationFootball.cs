/*
 * Created by SharpDevelop.
 * User: jcambray
 * Date: 15/12/2014
 * Time: 14:36
 */
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using ThreePlaySim.Abstract;
using System.Windows.Media;
using System.Windows;

namespace ThreePlaySim.FootballPlaySim
{
	
	public class SimulationFootball : SimulationAbstraite
	{
        public Equipe Equipe1 { get; set; }
        public Equipe Equipe2 { get; set; }
        public Ballon Ballon { get; set; }
      
        

		public SimulationFootball(String xmlContent,string mapFile)
            : base(mapFile)
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
                        j.StartPosition = new Point(25, 2);
                        continue;
                    }

                    if (j.Placement == "DC")
                    {
                        j.SeDeplacer(25, 12);
                        j.StartPosition = new Point(25, 12);
                        continue;
                    }

                    if (j.Placement == "DD")
                    {
                        j.SeDeplacer(25, 22);
                        j.StartPosition = new Point(25, 22);
                        continue;
                    }

                    if (j.Placement == "MG")
                    {
                        j.SeDeplacer(20, 2);
                        j.StartPosition = new Point(20,2);
                        continue;
                    }

                    if (j.Placement == "MD")
                    {
                        j.SeDeplacer(20, 22);
                            j.StartPosition = new Point(20, 22);
                        continue;
                    }

                    if (j.Placement == "BU")
                    {
                        j.SeDeplacer(15, 12);
                        j.StartPosition = new Point(15, 12);
                        continue;
                    }
                }

                if (j.Placement == "DG")
                {
                    j.SeDeplacer(4, 2);
                    j.StartPosition = new Point(4,2);
                    continue;
                }

                if (j.Placement == "DC")
                {
                    j.SeDeplacer(4, 12);
                    j.StartPosition = new Point(4, 12);
                    continue;
                }

                if (j.Placement == "DD")
                {
                    j.SeDeplacer(4, 22);
                    j.StartPosition = new Point(4, 22);
                    continue;
                }

                if (j.Placement == "MG")
                {
                    j.SeDeplacer(8, 2);
                    j.StartPosition = new Point(8, 2);
                    continue;
                }

                if (j.Placement == "MD")
                {
                    j.SeDeplacer(8, 22);
                    j.StartPosition = new Point(8,22);
                    continue;
                }

                if (j.Placement == "BU")
                {
                    j.SeDeplacer(13, 12);
                    j.StartPosition = new Point(13,12);
                    continue;
                }

            }

            Equipe1.ListJoueurs.Where(P => P.Poste == "defenseur").ToList()[0].RecoitLeBallon();
        }

        public override void InitObservateurs()
        {
            base.InitObservateurs();
            ListPersonnage.ForEach(P => P.Attach(new AlerteurDeBut("alerteurDeBut",this,(Joueur)P)));
        }

        public override void Routine()
        {
           if(Equipe1.Score == 5)
           {
               Timer.Stop();
               //Afficher Equipe1 vainqueur
               SimView.Close();
               return;
           }
            if(Equipe2.Score == 5)
            {
                Timer.Stop();
                //Afficher Equipe2 vainqueur
                SimView.Close();
                return;
            }

            foreach (Personnage p in ListPersonnage)
            {
                p.Action();
            }
        }

        public void RemiseEnJeu()
        {
            ListPersonnage.Select(P => P as Joueur).ToList().ForEach(J => J.SeDeplacer(J.StartPosition.X, J.StartPosition.Y));
            System.Threading.Thread.Sleep(2);
        }


        protected override void SetColorToArea()
        {
            Grid[0, 12].DefaultFont = Brushes.Yellow;
            Grid[0, 11].DefaultFont = Brushes.Yellow;
            Grid[0, 13].DefaultFont = Brushes.Yellow;
            Grid[29, 11].DefaultFont = Brushes.Yellow;
            Grid[29, 12].DefaultFont = Brushes.Yellow;
            Grid[29, 13].DefaultFont = Brushes.Yellow;
        }
    }
}
