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
        public string Poste { get; set; }
        public string Placement { get; set; }
        public Equipe Equipe { get; set; }
        public Point StartPosition { get; set; }

        public ComportementJoueurDeFoot ComportementJoueur;

        public Joueur(string prenom, string nom, string numero, string poste, string placement)
            : base(nom)
        {
            Prenom = prenom;
            Nom = nom;
            Numero = numero;
            Poste = poste;
            Placement = placement;
            switch (poste)
            {
                case "attaquant": ComportementJoueur = new ComportementAttaquant(this);
                    break;
                case "milieu": ComportementJoueur = new ComportementMillieuDeTerrain(this);
                    break;
                case "defenseur": ComportementJoueur = new ComportementDefenseur(this);
                    break;
            }
            comportementConfrontation = new ComportementConfrontationJoueur(this);
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
            var r = new Random();

            var context = (SimulationFootball)Context;

            if (Equipe == context.Equipe1)
            {
                if (Equipe.ALeBallon)
                {
                    if (Accessoire == null)
                    {
                        if (Position.X >= 30)
                            SeDeplacer(Position.X - 1, Position.Y);
                        if (Position.X == 0)
                            SeDeplacer(Position.X + 1, Position.Y);
                        if (Position.Y >= 25)
                            SeDeplacer(Position.X, Position.Y - 1);
                        if (Position.Y == 0)
                            SeDeplacer(Position.X, Position.Y + 1);
                        var value = r.Next(1, 4);
                        if (value == 1)
                            SeDeplacer(Position.X - 1, Position.Y - 1);
                        if (value == 2)
                            SeDeplacer(Position.X - 1, Position.Y);
                        if (value == 3)
                            SeDeplacer(Position.X - 1, Position.Y + 1);
                    }
                    else
                    {
                        if (Math.Abs(Position.X - StartPosition.X) >= 5 || Math.Abs(Position.Y - StartPosition.Y) >= 5)
                        {
                            PasserLaBalle();
                        }
                        else
                        {
                            if (Position.X >= 30)
                                SeDeplacer(Position.X - 1, Position.Y);
                            if (Position.X == 0)
                                SeDeplacer(Position.X + 1, Position.Y);
                            if (Position.Y >= 25)
                                SeDeplacer(Position.X, Position.Y - 1);
                            if (Position.Y == 0)
                                SeDeplacer(Position.X, Position.Y + 1);
                            var value = r.Next(1, 4);
                            if (value == 1)
                                SeDeplacer(Position.X - 1, Position.Y - 1);
                            if (value == 2)
                                SeDeplacer(Position.X - 1, Position.Y);
                            if (value == 3)
                                SeDeplacer(Position.X - 1, Position.Y + 1);
                        }
                    }
                }
                else
                {
                    var areaVoisine = VerifieSiJoueurACote();
                    if (areaVoisine != null)
                    {
                        Tacler(areaVoisine.Personnage);
                    }
                    else
                    {
                        var possesseurDuBallon = EquipeAdverse().ListJoueurs.Find(J => J.Accessoire != null).Position;
                        var futurePos = Position;
                        var adjacenteAreas = GetAreaAdjacentes();
                        foreach (var area in adjacenteAreas)
                        {
                            if (area == null)
                                continue;
                            if (GetDistance(area.Coordonnees, possesseurDuBallon) <= GetDistance(futurePos, possesseurDuBallon))
                                futurePos = area.Coordonnees;
                        }
                        SeDeplacer(futurePos.X, futurePos.Y);
                    }
                }
            }
            else
            {
                if (Equipe.ALeBallon)
                {
                    if (Accessoire == null)
                    {
                        if (Position.X >= 30)
                            SeDeplacer(Position.X - 1, Position.Y);
                        if (Position.X == 0)
                            SeDeplacer(Position.X + 1, Position.Y);
                        if (Position.Y >= 25)
                            SeDeplacer(Position.X, Position.Y - 1);
                        if (Position.Y == 0)
                            SeDeplacer(Position.X, Position.Y + 1);

                        var value = r.Next(1, 4);
                        if (value == 1)
                            SeDeplacer(Position.X + 1, Position.Y - 1);
                        if (value == 2)
                            SeDeplacer(Position.X + 1, Position.Y);
                        if (value == 3)
                            SeDeplacer(Position.X + 1, Position.Y + 1);
                    }
                    else
                    {
                        if (Math.Abs(Position.X - StartPosition.X) >= 5 || Math.Abs(Position.Y - StartPosition.Y) >= 5)
                        {
                            PasserLaBalle();
                        }
                        else
                        {
                            if (Position.X >= 30)
                                SeDeplacer(Position.X - 1, Position.Y);
                            if (Position.X == 0)
                                SeDeplacer(Position.X + 1, Position.Y);
                            if (Position.Y >= 25)
                                SeDeplacer(Position.X, Position.Y - 1);
                            if (Position.Y == 0)
                                SeDeplacer(Position.X, Position.Y + 1);

                            var value = r.Next(1, 4);
                            if (value == 1)
                                SeDeplacer(Position.X + 1, Position.Y - 1);
                            if (value == 2)
                                SeDeplacer(Position.X + 1, Position.Y);
                            if (value == 3)
                                SeDeplacer(Position.X + 1, Position.Y + 1);
                        }
                    }
                }
                else
                {
                    var areaVoisine = VerifieSiJoueurACote();
                    if (areaVoisine != null)
                    {
                        Tacler(areaVoisine.Personnage);
                    }
                    else
                    {
                        var possesseurDuBallon = EquipeAdverse().ListJoueurs.Find(J => J.Accessoire != null).Position;
                        var futurePos = Position;
                        foreach (var area in GetAreaAdjacentes())
                        {
                            if (area == null)
                                continue;
                            if (GetDistance(area.Coordonnees, possesseurDuBallon) <= GetDistance(futurePos, possesseurDuBallon))
                                futurePos = area.Coordonnees;
                        }
                        SeDeplacer(futurePos.X, futurePos.Y);
                    }
                }
            }

            System.Threading.Thread.Sleep(new TimeSpan(0, 0, 0, 0, 20));
        }

        public void Tacler(Personnage adversaire)
        {
            comportementConfrontation.Confrontation(adversaire);
        }

        private Area VerifieSiJoueurACote()
        {
            if ((int)Position.X >= 29 || (int)Position.Y >= 24 || (int)Position.X == 0 || (int)Position.Y == 0)
                return null;
            var context = (SimulationFootball)Context;
            if (context.Grid[Position.X - 1, Position.Y].Personnage != null)
                return context.Grid[Position.X - 1, Position.Y];
            if (context.Grid[Position.X - 1, Position.Y + 1].Personnage != null)
                return context.Grid[Position.X - 1, Position.Y + 1];
            if (context.Grid[Position.X, Position.Y + 1].Personnage != null)
                return context.Grid[Position.X, Position.Y + 1];
            if (context.Grid[Position.X + 1, Position.Y + 1].Personnage != null)
                return context.Grid[Position.X + 1, Position.Y + 1];
            if (context.Grid[Position.X + 1, Position.Y].Personnage != null)
                return context.Grid[Position.X + 1, Position.Y];
            if (context.Grid[Position.X + 1, Position.Y - 1].Personnage != null)
                return context.Grid[Position.X + 1, Position.Y - 1];
            if (context.Grid[Position.X, Position.Y - 1].Personnage != null)
                return context.Grid[Position.X, Position.Y - 1];
            return null;
        }

        public override void SeDeplacer(double x, double y)
        {
            base.SeDeplacer(x, y);
            if (Position != new Point(100, 100))
                Context.Grid[Position.X, Position.Y].FontColor = Equipe.FontColor;
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

        public Equipe EquipeAdverse()
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
