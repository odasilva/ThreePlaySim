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


        public SimulationWar(String xmlContent, String mapFile)
            : base(mapFile)
		{
			
		}
		

        public override void Routine()
        {
            throw new NotImplementedException();
        }

        public override void PlacerPersonnages()
        {
           
        }

        protected override void SetColorToArea()
        {
            
        }
    }
}
