﻿/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 07/01/2015
 * Time: 08:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ThreePlaySim.Abstract;
	
namespace ThreePlaySim.WarPlaySim
{
	/// <summary>
	/// Description of ComportementAPied.
	/// </summary>
	public class ComportementAPied : ComportementConfrontation
	{
        private Soldat soldat;

		public ComportementAPied(Soldat s)
		{
            soldat = s; 
		}

        public override void Confrontation(Personnage adversaire)
        {
            throw new NotImplementedException();
        }
    }
}
