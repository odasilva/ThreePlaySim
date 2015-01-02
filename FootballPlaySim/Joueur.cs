using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreePlaySim.FootballPlaySim
{
    public class Joueur
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Numero { get; set; }
        public string Poste {get;set;}
        public Equipe Equipe { get; set; }

        public Joueur(string prenom,string nom,string numero,string poste )
        {
            Prenom = prenom;
            Nom = nom;
            Numero = numero;
            Poste = poste;
        }



    }

    public enum EPosteJoueur
    {
        attaquant,
        millieu,
        defenseur
    }
}
