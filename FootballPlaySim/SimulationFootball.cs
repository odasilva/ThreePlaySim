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
        

		public SimulationFootball(String xmlContent)
            : base()
		{
            ListPersonnage = new List<Personnage>();
		}

        //public void Init()
        //{
        //    foreach(Joueur j in ListPersonnage)
        //    {
        //        if (j.Equipe.Nom == Equipe1.Nom)
        //        {
        //            if (j.Position == "DG")
        //            {
        //                var spawnArea = Map.GetAreaByProperty("spawnDG1");
                       
        //                continue;
        //            }

        //            if (j.Position == "DC")
        //            {
        //                var spawnArea = Map.GetAreaByProperty("spawnDC1");
        //                continue;
        //            }

        //            if (j.Position == "DD")
        //            {
        //                var spawnArea = Map.GetAreaByProperty("spawnDD1");
                   
        //                continue;
        //            }

        //            if (j.Position == "MG")
        //            {
        //                var spawnArea = Map.GetAreaByProperty("spawnMG1");

        //                continue;
        //            }

        //            if (j.Position == "MD")
        //            {
        //                var spawnArea = Map.GetAreaByProperty("spawnMD1");

        //                continue;
        //            }

        //            if (j.Position == "BU")
        //            {
        //                var spawnArea = Map.GetAreaByProperty("spawnBU1");

        //                continue;
        //            }
        //        }

        //        if (j.Position == "DG")
        //        {
        //            var spawnArea = Map.GetAreaByProperty("spawnDG2");
                   
        //            continue;
        //        }

        //        if (j.Position == "DC")
        //        {
        //            var spawnArea = Map.GetAreaByProperty("spawnDC2");
        //            continue;
        //        }

        //        if (j.Position == "DD")
        //        {
        //            var spawnArea = Map.GetAreaByProperty("spawnDD2");

        //            continue;
        //        }

        //        if (j.Position == "MG")
        //        {
        //            var spawnArea = Map.GetAreaByProperty("spawnMG2");

        //            continue;
        //        }

        //        if (j.Position == "MD")
        //        {
        //            var spawnArea = Map.GetAreaByProperty("spawnMD2");

        //            continue;
        //        }

        //        if (j.Position == "BU")
        //        {
        //            var spawnArea = Map.GetAreaByProperty("spawnBU2");

        //            continue;
        //        }

        //    }
        //}


        public override void Routine()
        {
           
            foreach(Personnage p in ListPersonnage)
            {
                p.Action();
            }
        }
	}
}
