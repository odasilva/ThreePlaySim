/*
 * Created by SharpDevelop.
 * User: odasilva
 * Date: 07/01/2015
 * Time: 08:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ThreePlaySim.Abstract;
	
namespace ThreePlaySim.WarPlaySim
{
	/// <summary>
	/// Description of ComportementACheval.
	/// </summary>
	public class ComportementACheval : ComportementConfrontation
	{
        /* l attibut prive permet au soldat de notifier son action pour qu'elle soit affichée dans la liste des action à lécran. */
        private Soldat soldat;

		public ComportementACheval(Soldat s)
		{
            soldat = s;
		}
		
	
        public override void Confrontation(Personnage adversaire)
        {
            var ennemi = adversaire as Soldat;
            soldat.Notify(soldat.Nom + "Observateur",String.Format("{0} {1} attaque {2} {3} avec son arme qui lui permet de {4} du haut de son cheval",soldat.Prenom,soldat.Nom,ennemi.Prenom,ennemi.Prenom,soldat.Accessoire.Utiliser()));
            var r = new Random();
            if (r.Next(1, 4) == 3)
            {
                adversaire = null;
                soldat.Notify(soldat.Nom + "Observateur", String.Format("Et a tué {0} {1}", ennemi.Prenom, ennemi.Nom));
            }
            else
                soldat.Notify(soldat.Nom + "Observateur", String.Format("Mais {0} {1} a esquiver son attaque", ennemi.Prenom, ennemi.Nom));
        }
    }
}
