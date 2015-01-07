using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreePlaySim.FootballPlaySim;
using System.Xml;
using ThreePlaySim.FootballPlaySim;
using ThreePlaySim.TraficPlaySim;
using ThreePlaySim.WarPlaySim;

namespace ThreePlaySim.Abstract
{
    public class SimulationFabrique : FabriqueAbstraite
    {
        private EquipeFabrique equipeFactory;

        public SimulationFabrique(string xml)
            : base(xml)
        {
            equipeFactory = new EquipeFabrique(xmlFile);
        }
        public SimulationAbstraite CreerSimulationFootball()
        {
            Equipe equipe1, equipe2;
            xmlDoc.Load(xmlFile);
            //var doc = new XmlDocument();
            //doc.Load(xmlFile);
            var xmlEquipeList = xmlDoc.GetElementsByTagName("equipe");
            var xmlEquipe1JoueursList = xmlEquipeList[0].ChildNodes;
            var xmlEquipe2JoueursList = xmlEquipeList[1].ChildNodes;

            var eq = equipeFactory.CreerEquipe1();

            equipe1 = equipeFactory.CreerEquipe1();
            equipe2 = equipeFactory.CreerEquipe2();

            return new SimulationFootball(equipe1,equipe2);
        }

    }

    public class EquipeFabrique : FabriqueAbstraite
    {
        private  JoueurFabrique joueurFactory;

        public  EquipeFabrique(string xml)
            : base(xml)
        {
            joueurFactory = new JoueurFabrique(xmlFile);
        }

        public Equipe CreerEquipe(int i)
        {
            xmlDoc.Load(xmlFile);
            var xpathRequest = String.Format("//equipe[{0}]/@nom", i);
            var equipe = new Equipe(xmlDoc.SelectSingleNode(xpathRequest).Value);

            //var nbJoueurRequest = String.Format("//equipe[{0}])", i);
            //var equipeNode = xmlDoc.SelectSingleNode(nbJoueurRequest);

            var nbJoueurs = 3;

            for (int j = 1; j < nbJoueurs;j++ )
            {
                equipe.AddJoueur(joueurFactory.CreerJoueur(equipe.Nom, j));
            }
                return equipe;
        }

        public Equipe CreerEquipe1()
        {
            xmlDoc.Load(xmlFile);
            var equipeNode = xmlDoc.SelectSingleNode("//equipe[1]");
            var equipe = new Equipe(equipeNode.Attributes["nom"].Value);
            
            foreach(XmlNode joueurNode in equipeNode.ChildNodes)
            {
                equipe.AddJoueur(new Joueur(joueurNode.Attributes["prenom"].Value,joueurNode.Attributes["nom"].Value,joueurNode.Attributes["numero"].Value,joueurNode.Attributes["poste"].Value));
            }
            return equipe;
        }

        public Equipe CreerEquipe2()
        {
            xmlDoc.Load(xmlFile);
            var xpathRequest = String.Format("//equipe[2]/@nom");
            return new Equipe(xmlDoc.SelectSingleNode(xpathRequest).Value);
        }
    }

    public class JoueurFabrique : FabriqueAbstraite
    {
        public  JoueurFabrique(string xml)
            : base(xml)
        {

        }

        public Joueur CreerJoueur(string nomEquipe,int i)
        {
            xmlDoc.Load(xmlFile);

            var request = String.Format("//equipe[@nom={0}]/joueur[{1}]", nomEquipe, i);
            var joueurNode = xmlDoc.SelectSingleNode(request);

            var prenom = joueurNode.Attributes["prenom"].Value;
            var nom = joueurNode.Attributes["nom"].Value;
            var numero = joueurNode.Attributes["numero"].Value;
            var poste = joueurNode.Attributes["poste"].Value;

            return new Joueur(prenom, nom, numero, poste);
        }
    }


}
