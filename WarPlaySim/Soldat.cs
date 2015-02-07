using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ThreePlaySim.Abstract;

namespace ThreePlaySim.WarPlaySim
{
    public class Soldat : Personnage
    {
        
        public string Prenom { get; set; }
        public string Type {get;set;}
        public Armee Armee { get; set; }
        public Point StartPosition { get; set; }

        public ComportementConfrontation ComportementConfrontation;

        public ComportementEmettreUnSon ComportementEmettreUnSon;


        public Soldat(string prenom,string nom, string type)
            : base(nom)
        {
            Prenom = prenom;
            Nom = nom;
            Type = type;

            switch(type)
            {
                case "Princesse": 
                        ComportementConfrontation = new ComportementConfrontationPrincesse(this);
                        ComportementEmettreUnSon = new ComportementParlerPrincesse();
                    break;
                case "Archer": 
                        ComportementConfrontation = new ComportementAvecArc(this);
                        ComportementEmettreUnSon = new ComportementParler();

                    break;
                case "Cavalier": 
                        ComportementConfrontation = new ComportementACheval(this);
                        ComportementEmettreUnSon = new ComportementParlerCrier();
                    break;

                case "Fantassin":
                    comportementConfrontation = new ComportementAPied(this);
                    comportementEmettreUnSon = new ComportementParlerCrier();
                    break;
            }
        }


        public void Attaquer(Soldat ennemi)
        {
            comportementConfrontation.Confrontation(ennemi);
        }


        public override string Afficher()
        {
            throw new NotImplementedException();
        }



        public override void Action()
        {            

           var r = new Random();

           var context = (SimulationWar)Context;
           if(Armee == context.armeB)
           {
               
                if(Accessoire == null)
                {
                    if (Position.X >= 30)
                        SeDeplacer(Position.X - 1, Position.Y);
                    if(Position.X == 0)
                        SeDeplacer(Position.X + 1, Position.Y);
                    if (Position.Y >= 25)
                        SeDeplacer(Position.X, Position.Y-1);
                    if (Position.Y == 0)
                        SeDeplacer(Position.X, Position.Y+1);
                    var value = r.Next(1, 4);
                    if (value == 1)
                        SeDeplacer(Position.X - 1, Position.Y-1);
                    if (value == 2)
                        SeDeplacer(Position.X - 1, Position.Y);
                    if (value == 3)
                        SeDeplacer(Position.X - 1, Position.Y + 1);
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
           else
           {
               if (Accessoire == null)
               {
                   if (Position.X >= 30)
                       SeDeplacer(Position.X + 1, Position.Y);
                   if (Position.X == 0)
                       SeDeplacer(Position.X - 1, Position.Y);
                   if (Position.Y >= 25)
                       SeDeplacer(Position.X, Position.Y + 1);
                   if (Position.Y == 0)
                       SeDeplacer(Position.X, Position.Y - 1);
                   var value = r.Next(1, 4);
                   if (value == 1)
                       SeDeplacer(Position.X + 1, Position.Y + 1);
                   if (value == 2)
                       SeDeplacer(Position.X + 1, Position.Y);
                   if (value == 3)
                       SeDeplacer(Position.X + 1, Position.Y - 1);
               }
               else
               {

                   if (Position.X >= 30)
                       SeDeplacer(Position.X + 1, Position.Y);
                   if (Position.X == 0)
                       SeDeplacer(Position.X - 1, Position.Y);
                   if (Position.Y >= 25)
                       SeDeplacer(Position.X, Position.Y + 1);
                   if (Position.Y == 0)
                       SeDeplacer(Position.X, Position.Y - 1);
                   var value = r.Next(1, 4);
                   if (value == 1)
                       SeDeplacer(Position.X + 1, Position.Y + 1);
                   if (value == 2)
                       SeDeplacer(Position.X + 1, Position.Y);
                   if (value == 3)
                       SeDeplacer(Position.X + 1, Position.Y - 1);

               }
           }

           System.Threading.Thread.Sleep(new TimeSpan(0, 0, 0, 0, 20));
        }


        private Area VerifieSiSoldatACote()
        {
            if ((int)Position.X >= 30 || (int)Position.Y >= 25)
                return null;
            var context = (SimulationWar)Context;
            if (context.Grid[Position.X - 1, Position.Y].Personnage != null)
                return context.Grid[Position.X - 1, Position.Y];
            if (context.Grid[Position.X - 1, Position.Y+1].Personnage != null)
                return context.Grid[Position.X - 1, Position.Y+1];
            if (context.Grid[Position.X, Position.Y+1].Personnage != null)
                return context.Grid[Position.X, Position.Y+1];
            if (context.Grid[Position.X + 1, Position.Y+1].Personnage != null)
                return context.Grid[Position.X+1, Position.Y+1];
            if (context.Grid[Position.X+1, Position.Y].Personnage != null)
                return context.Grid[Position.X + 1, Position.Y];
            if (context.Grid[Position.X+1, Position.Y-1].Personnage != null)
                return context.Grid[Position.X+1, Position.Y-1];
            if (context.Grid[Position.X, Position.Y-1].Personnage != null)
                return context.Grid[Position.X, Position.Y-1];
            return null;
        }

        public override void SeDeplacer(double x, double y)
        {
            base.SeDeplacer(x, y);
            Position = new Point(x,y);
            if(Position != new Point(100,100))
                Context.Grid[Position.X,Position.Y].FontColor = Armee.FontColor;
        }

        public  Armee ArmeeAdverse()
        {
            var simulationWar = Context as SimulationWar;
            return Armee.Equals(simulationWar.armeA) ? simulationWar.armeB : simulationWar.armeA;
        }
        
    }
 }
