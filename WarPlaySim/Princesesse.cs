﻿/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 06/01/2015
 * Time: 15:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.WarPlaySim
{
	/// <summary>
	/// Description of Princesesse.
	/// </summary>
	public class Princesesse : Personnage
	{
		public Princesesse(string nom) : base(nom)
		{
		}

        public override string Afficher()
        {
            return "P";
        }


        public override void Action()
        {
            throw new NotImplementedException();
        }
    }
}
