﻿using System;
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
        public string Placement {get;set;}
        public Equipe Equipe { get; set; }

        public ComportementJoueurDeFoot ComportementJoueur;

        public Joueur(string prenom,string nom,string numero,string poste,string placement)
            : base(nom)
        {
            Prenom = prenom;
            Nom = nom;
            Numero = numero;
            Poste = poste;
            Placement = placement;
            switch(poste)
            {
                case "attaquant": ComportementJoueur = new ComportementAttaquant(this);
                    break;
                case "millieu": ComportementJoueur = new ComportementMillieuDeTerrain();
                break;
                case "defenseur": ComportementJoueur = new ComportementDefenseur();
                    break;
            }
        }


        public void Dribbler(Joueur adversaire)
        {
            ComportementJoueur.Dribbler(adversaire);
        }

        public void FrapperAuxBut()
        {
            ComportementJoueur.FrapperAuButs();
        }

        public void PasserLaBalle()
        {
            ComportementJoueur.PasserLaBalle();
        }

        public override string Afficher()
        {
            throw new NotImplementedException();
        }


        public override void Action()
        {
            SeDeplacer(Position.X + 1, Position.Y);
            if (Poste == "attaquant")
                FrapperAuxBut();
        }

        public override void SeDeplacer(double x, double y)
        {
            base.SeDeplacer(x, y);
            if(Position != new Point(100,100))
                Context.Grid[Position.X,Position.Y].FontColor = Equipe.FontColor;
        }

        public void RecoitLeBallon()
        {
            var simulationFoot = Context as SimulationFootball;
            Accessoire = simulationFoot.Ballon;
            Equipe.ALeBallon = true;
        }

        public void PerdLeBallon()
        {
            Accessoire = null;
            Equipe.ALeBallon = false;
            EquipeAdverse().ALeBallon = true;
        }

        public  Equipe EquipeAdverse()
        {
            var simulationFoot = Context as SimulationFootball;
            return Equipe.Equals(simulationFoot.Equipe1) ? simulationFoot.Equipe2 : simulationFoot.Equipe1;
        }
        
    }

    

    public enum EPosteJoueur
    {
        attaquant,
        millieu,
        defenseur
    }
}
