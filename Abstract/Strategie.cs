/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 15/12/2014
 * Time: 14:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ThreePlaySim.Abstract
{
	/// <summary>
	/// Description of Strategie.
	/// </summary>
	
	internal abstract class StrategieAbstraite
 	{
 		public abstract void Operation();
 	}

	  internal class Contexte
	{
 		private StrategieAbstraite stategieCourante;
 
 		public Contexte(StrategieAbstraite uneStrategie)
 		{
 			stategieCourante = uneStrategie;
 		}
 
 		internal void ModifieStrategie(StrategieAbstraite uneStrategie)
 		{
 			stategieCourante = uneStrategie;
 		}

 		internal void Execute()
 		{
 			stategieCourante.Operation();
 		}
 	}
}
