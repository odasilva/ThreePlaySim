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
	/// <summary
	/// Description of Archer.
	/// </summary>
    public class Archer : Personnage
    {
        public Archer(string nom)
            : base(nom)
        {

        }


        public override string Afficher()
        {
            return "A";
        }
    }
}
