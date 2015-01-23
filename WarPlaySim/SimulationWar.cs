/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 15/12/2014
 * Time: 14:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.WarPlaySim
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class SimulationWar : SimulationAbstraite
	{
        public string[,] map;
        public List<Personnage> armeA;
        public List<Personnage> armeB;        
        public int x = 10;
        public int y = 10;
        
		public SimulationWar(String xml,System.Drawing.Bitmap imgFond)
            : base(xml,imgFond)
		{
			map = new string [x,y];
			armeA = new List<Personnage>();
			armeB = new List<Personnage>();
			
			armeA.Add(new Princesesse("PrinA"));
			armeA.Add(new Fantassin("FantA"));
			armeA.Add(new Cavalier("CavaA"));
			                   
			armeB.Add(new Princesesse("PrinB"));
			armeB.Add(new Archer("ArchB"));
			armeB.Add(new Cavalier("CavaB"));
			
			for(int i = 0; i<x; i++){
				for(int j = 0; j<y; j++){
					if(i == 0 && j == (y/2))
						map[i,j] = " P ";
					else if(i == 1)
						map[i,j] = " ";
					else
						map[i,j] = " - ";
				}
			}
		}
		
		public string AfficherTous()
		{
			string window = "";
			
			for(int i = 0; i<x; i++){
				for(int j = 0; j<y; j++){
					window += map[i,j];
				}
				window += "\n";
			}
			
			return window;
		}

        public override void Routine()
        {
            throw new NotImplementedException();
        }
    }
}
