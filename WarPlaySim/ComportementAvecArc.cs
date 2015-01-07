/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 07/01/2015
 * Time: 08:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ThreePlaySim.Abstract;
	
namespace ThreePlaySim.WarPlaySim
{
	/// <summary>
	/// Description of ComportementAvecArc.
	/// </summary>
	public class ComportementAvecArc : ComportementConfrontation
	{
		public ComportementAvecArc()
		{
			
		}
		
		public override string Confrontation()
		{
			return " arrive avec son arc.";
		}
	}
}
