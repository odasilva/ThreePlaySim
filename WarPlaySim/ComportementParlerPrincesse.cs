/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 07/01/2015
 * Time: 08:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.WarPlaySim
{
	/// <summary>
	/// Description of ComportementParlerPrincesse.
	/// </summary>
    public class ComportementParlerPrincesse : ComportementEmettreUnSon
	{
		public ComportementParlerPrincesse()
		{
		}


        public override string EmmettreSon()
        {
			return " Son de princesse !";
		}
	}
}
