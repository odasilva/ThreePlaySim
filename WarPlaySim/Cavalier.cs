/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 06/01/2015
 * Time: 15:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.WarPlaySim
{
	/// <summary>
	/// Description of Cavalier.
	/// </summary>
	public class Cavalier : Personnage
	{
		public Cavalier(string nom) : base (nom)
		{
		}

        public override string Afficher()
        {
            return "C";
        }

        public override string Confrontation()
        {
            throw new NotImplementedException();
        }

        public override string EmmettreUnSon()
        {
            throw new NotImplementedException();
        }

        public override string SeDeplacer()
        {
            throw new NotImplementedException();
        }
    }
}
