﻿/*
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
	/// Description of ComportementParler.
	/// </summary>
	public class ComportementParler : ComportementEmettreUnSon
	{
		public ComportementParler()
		{
		}
		
		
		public override string EmmettreSon(){
			return " Ah !";
		}
	}
}
