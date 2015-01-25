/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 06/01/2015
 * Time: 15:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.WarPlaySim
{
	/// <summary>
	/// Description of Fantassin.
	/// </summary>
	public class Fantassin : Personnage
	{
		public Fantassin(string nom) : base(nom)
		{
		}

        public override string Afficher()
        {
            return "F";
        }


        public override void Action()
        {
            throw new NotImplementedException();
        }
    }
}
