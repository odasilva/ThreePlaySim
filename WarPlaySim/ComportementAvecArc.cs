﻿/*
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

        private Soldat soldat;

		public ComportementAvecArc(Soldat s)
		{
            soldat = s;
		}
		

        public override void Confrontation(Personnage adversaire)
        {
            throw new NotImplementedException();
        }
    }
}
