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
		protected readonly List<ObservateurAbstrait> observateurList = new List<ObservateurAbstrait>();
	 
		public void Attach(ObservateurAbstrait observer)
	 	{
	 		observateurList.Add(observer);
	 	}
	 
		public void Detach(ObservateurAbstrait observer)
	 	{
	 		observateurList.Remove(observer);
	 	}
	 
	 	public void Notify()
	 	{
	 		foreach (ObservateurAbstrait o in observateurList)
	 		{
	 			o.MiseAjour();
	 		}
	 	}
	}
	
	public abstract class ObservateurAbstrait
 	{
 		public abstract void MiseAjour();
 	}



}
