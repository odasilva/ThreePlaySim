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
        public int Numero { get; set; }
        public EPosteJoueur Poste {get;set;}
        public Equipe Equipe { get; set; }

        public Joueur()
        {

        }



    }

    public enum EPosteJoueur
    {
        Attaquant,
        Millieu,
        Defenseur
    }
}
