/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 15/12/2014
 * Time: 14:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.WarPlaySim
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class SimulationWar : SimulationAbstraite
	{
        public string[,] map;
        public Armee armeA;
        public Armee armeB;        
        public int x = 10;
        public int y = 10;

        public SimulationWar(String xmlContent)
            : base()
		{
			
		}
		
		public string AfficherTous()
		{
			string window = "";
			
			for(int i = 0; i<x; i++){
				for(int j = 0; j<y; j++){
					window += map[i,j];
				}
				window += "\n";
			}
			
			return window;
		}

        public override void Routine()
        {
            throw new NotImplementedException();
        }

        public override void PlacerPersonnages()
        {
            throw new NotImplementedException();
        }
    }
}
