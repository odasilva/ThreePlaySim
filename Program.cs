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

            var fabrique = new SimulationFootballFabrique(Properties.Resources.footballSimulation);
            var footballSimulation = fabrique.CreerSimulation(Properties.Resources.footballMap, Properties.Resources.terrain);
            footballSimulation.RenderMap();

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}