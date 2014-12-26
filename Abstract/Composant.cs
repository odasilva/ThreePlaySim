/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 15/12/2014
 * Time: 14:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace ThreePlaySim.Abstract
{
	/// <summary>
	/// Description of ComposantAbstrait.
	/// </summary>

	 internal abstract class ComposantAbstrait
	 {
		 protected string nom;
	
		 public ComposantAbstrait(string unNom)
		 {
			 nom = unNom;
		 }
	
		 public abstract void Ajoute(ComposantAbstrait c);

		 public abstract void Retire(ComposantAbstrait c);

		 public abstract void AffichageRecursif(int profondeur);
	 }
	

	 internal class Composite : ComposantAbstrait
	 {
		 private readonly List<ComposantAbstrait> enfants = new
		List<ComposantAbstrait>();

		public Composite(string name) : base(name)
	 	{
		}
		
	 	public override void Ajoute(ComposantAbstrait component)
	 	{
	 		enfants.Add(component);
	 	}
	 
	 	public override void Retire(ComposantAbstrait component)
	 	{
	 		enfants.Remove(component);
	 	}

        public override void AffichageRecursif(int profondeur)
	 	{
	 		Console.WriteLine(new String('-', profondeur) + nom);
	 	
	 		foreach (ComposantAbstrait component in enfants)
			 {
                 component.AffichageRecursif(profondeur + 2);
			 }
	 	}
	 }
}
