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
        


		public SimulationFootball(Equipe equipe1,Equipe equipe2)
		{
            Equipe1 = equipe1;
            Equipe2 = equipe2;
		}

        public override void RenderMap()
        {
            map = new FootballMap(this);
            System.Windows.Forms.Application.Run(map);
        }
	}
}
