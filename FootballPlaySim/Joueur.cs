using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreePlaySim.Abstract;
using System.Windows;

namespace ThreePlaySim.FootballPlaySim
{
    public class Joueur : Personnage
    {
        public string Prenom { get; set; }
        public string Numero { get; set; }
        public string Poste {get;set;}
        public Equipe Equipe { get; set; }

        public ComportementJoueurDeFoot ComportementJoueur;

        public Joueur(string prenom,string nom,string numero,string poste)
            : base(nom)
        {
            Prenom = prenom;
            Nom = nom;
            Numero = numero;
            Poste = poste;

            switch(poste)
            {
                case "attaquant": ComportementJoueur = new ComportementAttaquant();
                    break;
                case "millieu": ComportementJoueur = new ComportementMillieuDeTerrain();
                break;
                case "defenseur": ComportementJoueur = new ComportementDefenseur();
                    break;
            }
        }




        public override string Afficher()
        {
            throw new NotImplementedException();
        }


        public override void Action()
        {
            SeDeplacer((int)Position.X+1,(int)Position.Y + 1);
        }

        public override void SeDeplacer(int x, int y)
        {
            base.SeDeplacer(x, y);
            if(Position != new Point(100,100))
                Context.Grid[Position.X,Position.Y].FontColor = Equipe.FontColor;
        }

        
    }

    

    public enum EPosteJoueur
    {
        attaquant,
        millieu,
        defenseur
    }
}
