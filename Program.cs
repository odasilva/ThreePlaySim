/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 15/12/2014
 * Time: 14:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using ThreePlaySim.Abstract;
using ThreePlaySim.FootballPlaySim;
using ThreePlaySim.TraficPlaySim;
using ThreePlaySim.WarPlaySim;

namespace ThreePlaySim
{
	class Program
	{
		public static void Main(string[] args)
		{
			//Console.WriteLine("Hello World!");


            SimulationFabrique fabrique = new SimulationFabrique(@"C:\Users\jerome\Documents\GitHub\ThreePlaySim\FootballPlaySim\SimulationFootball.xml");
            
            var footballSimulation = fabrique.CreerSimulationFootball();
            footballSimulation.RenderMap();

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}