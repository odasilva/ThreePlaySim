/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 06/01/2015
 * Time: 15:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ThreePlaySim.Abstract
{
	/// <summary>
	/// Description of ComportementConfrontation.
	/// </summary>
	public abstract class ComportementConfrontation 
	{
		public ComportementConfrontation()
		{
			
		}

        public abstract void Confrontation(Personnage adversaire);
		
	}
}
