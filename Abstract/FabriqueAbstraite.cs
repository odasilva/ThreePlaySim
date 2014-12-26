/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 15/12/2014
 * Time: 14:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ThreePlaySim.FootballPlaySim;

namespace ThreePlaySim.Abstract
{
	/// <summary>
	/// Description of FabriqueAbstraite.
	/// </summary>
	abstract public class FabriqueAbstraite
	{		
 		public abstract SimulationAbstraite CreerSimulationFootball(Equipe equipe1,Equipe equipe2);
 		//public abstract ProduitAbstraitB CreerProduitB();
	}
	
 }

