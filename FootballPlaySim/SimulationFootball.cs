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

namespace ThreePlaySim.FootballPlaySim
{
	
	public class SimulationFootball : SimulationAbstraite
	{
        public Equipe Equipe1 { get; set; }
        public Equipe Equipe2 { get; set; }
        

		public SimulationFootball(Equipe equipe1,Equipe equipe2,String xmlContent,System.Drawing.Bitmap imgFond)
            : base(xmlContent,imgFond)
		{
            Equipe1 = equipe1;
            Equipe2 = equipe2;
            ListPersonnage = new List<Personnage>();
            ListPersonnage.AddRange(Equipe1.ListJoueurs);
            ListPersonnage.AddRange(Equipe2.ListJoueurs);
            Init();
		}

        public void Init()
        {
            foreach(Joueur j in ListPersonnage)
            {
                if (j.Equipe.Nom == Equipe1.Nom)
                {
                    if (j.Position == "DG")
                    {
                        var spawnArea = Map.GetAreaByProperty("spawnDG1");
                        Map.AddItem(new MapItem(j, spawnArea,Properties.Resources.pionBleu));
                        continue;
                    }

                    if (j.Position == "DC")
                    {
                        var spawnArea = Map.GetAreaByProperty("spawnDC1");
                        Map.AddItem(new MapItem(j, spawnArea, Properties.Resources.pionBleu));
                        continue;
                    }

                    if (j.Position == "DD")
                    {
                        var spawnArea = Map.GetAreaByProperty("spawnDD1");
                        Map.AddItem(new MapItem(j, spawnArea, Properties.Resources.pionBleu));
                        continue;
                    }

                    if (j.Position == "MG")
                    {
                        var spawnArea = Map.GetAreaByProperty("spawnMG1");
                        Map.AddItem(new MapItem(j, spawnArea, Properties.Resources.pionBleu));
                        continue;
                    }

                    if (j.Position == "MD")
                    {
                        var spawnArea = Map.GetAreaByProperty("spawnMD1");
                        Map.AddItem(new MapItem(j, spawnArea, Properties.Resources.pionBleu));
                        continue;
                    }

                    if (j.Position == "BU")
                    {
                        var spawnArea = Map.GetAreaByProperty("spawnBU1");
                        Map.AddItem(new MapItem(j, spawnArea, Properties.Resources.pionBleu));
                        continue;
                    }
                }

                if (j.Position == "DG")
                {
                    var spawnArea = Map.GetAreaByProperty("spawnDG2");
                    Map.AddItem(new MapItem(j, spawnArea, Properties.Resources.pionRouge));
                    continue;
                }

                if (j.Position == "DC")
                {
                    var spawnArea = Map.GetAreaByProperty("spawnDC2");
                    Map.AddItem(new MapItem(j, spawnArea, Properties.Resources.pionRouge));
                    continue;
                }

                if (j.Position == "DD")
                {
                    var spawnArea = Map.GetAreaByProperty("spawnDD2");
                    Map.AddItem(new MapItem(j, spawnArea, Properties.Resources.pionRouge));
                    continue;
                }

                if (j.Position == "MG")
                {
                    var spawnArea = Map.GetAreaByProperty("spawnMG2");
                    Map.AddItem(new MapItem(j, spawnArea, Properties.Resources.pionRouge));
                    continue;
                }

                if (j.Position == "MD")
                {
                    var spawnArea = Map.GetAreaByProperty("spawnMD2");
                    Map.AddItem(new MapItem(j, spawnArea, Properties.Resources.pionRouge));
                    continue;
                }

                if (j.Position == "BU")
                {
                    var spawnArea = Map.GetAreaByProperty("spawnBU2");
                    Map.AddItem(new MapItem(j, spawnArea, Properties.Resources.pionRouge));
                    continue;
                }

            }
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
