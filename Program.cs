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
			Console.WriteLine("Hello World!");
			
			// TODO: Implement Functionality Here
            SimulationFabrique fabrique = new SimulationFabrique();

            var equipe1 = new Equipe("PSG");
            equipe1.AddJoueur(new Joueur{Prenom = "Jean-Christophe", Nom = "BAHEBECK", Numero = 32, Poste = EPosteJoueur.Attaquant});
            equipe1.AddJoueur((new Joueur {Prenom = "Marco", Nom = "VERRATTI", Numero = 6, Poste = EPosteJoueur.Millieu}));
            equipe1.AddJoueur(new Joueur{ Prenom ="Gregory", Nom = "VAN DER WIEL", Numero = 4, Poste = EPosteJoueur.Defenseur});

            var equipe2 = new Equipe("OM");
            equipe2.AddJoueur(new Joueur { Prenom = "andre-Pierre", Nom = "Gignac", Numero = 10, Poste = EPosteJoueur.Attaquant });
            equipe2.AddJoueur(new Joueur { Prenom = "Dimitri", Nom = "PAYET", Numero = 8, Poste = EPosteJoueur.Millieu });
            equipe2.AddJoueur(new Joueur { Prenom = "Alain", Nom = "MENDY", Numero = 3, Poste = EPosteJoueur.Defenseur });
            var footballSimulation = fabrique.CreerSimulationFootball(equipe1, equipe2);
            footballSimulation.RenderMap();

			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}