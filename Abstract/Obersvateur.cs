/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 15/12/2014
 * Time: 14:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ThreePlaySim.Abstract
{
	/// <summary>
	/// Description of Obersvateur.
	/// </summary>
	public abstract class SujetAbstrait
	{
		protected  List<ObservateurAbstrait> observateurList;
	 
		public void Attach(ObservateurAbstrait observer)
	 	{
	 		observateurList.Add(observer);
	 	}
	 
		public void Detach(ObservateurAbstrait observer)
	 	{
	 		observateurList.Remove(observer);
	 	}
	 
	 	public void Notify(String nomObservateur, string message)
	 	{
            var o = observateurList.Find(O => O.Nom == nomObservateur);
            o.MiseAjour(message);
	 	}


	}
	
	public abstract class ObservateurAbstrait
 	{
        public string Nom;
        public ObservateurAbstrait(string nom)
        {
            Nom = nom;
        }

 		public abstract void MiseAjour(string message);
 	}



}
