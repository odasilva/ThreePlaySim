using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreePlaySim.FootballPlaySim;
using System.Xml;
using ThreePlaySim.TraficPlaySim;
using ThreePlaySim.WarPlaySim;
using System.Windows.Media;

namespace ThreePlaySim.Abstract
{

    public class SimulationFootballFabrique : FabriqueAbstraite
    {
        public SimulationFootballFabrique(string xml)
            :base(xml)
        {
        }
        public SimulationFootball CreerSimulation()
        {
            xmlDoc.LoadXml(xmlContent);
            var equipeFactory = new EquipeFabrique(xmlContent);
            var equipe1 = equipeFactory.CreerEquipe1();
            var equipe2 = equipeFactory.CreerEquipe2();

            var simulationFoot = new SimulationFootball(xmlContent);
            equipe1.ListJoueurs.ForEach(P => simulationFoot.AjoutePersonnage(P));
            equipe2.ListJoueurs.ForEach(P => simulationFoot.AjoutePersonnage(P));

            simulationFoot.Equipe1 = equipe1;
            simulationFoot.Equipe2 = equipe2;

            simulationFoot.Equipe1.FontColor = Brushes.Green;
            simulationFoot.Equipe2.FontColor = Brushes.OrangeRed;


            return simulationFoot;
        }
    }

    public class SimulationWarFabrique : FabriqueAbstraite
    {
        public SimulationWarFabrique(string xml)
            : base(xml)
        {
        }
        public SimulationFootball CreerSimulation()
        {
            xmlDoc.LoadXml(xmlContent);
            var equipeFactory = new EquipeFabrique(xmlContent);
            var equipe1 = equipeFactory.CreerEquipe1();
            var equipe2 = equipeFactory.CreerEquipe2();

            var simulationFoot = new SimulationFootball(xmlContent);
            equipe1.ListJoueurs.ForEach(P => simulationFoot.AjoutePersonnage(P));
            equipe2.ListJoueurs.ForEach(P => simulationFoot.AjoutePersonnage(P));

            simulationFoot.Equipe1 = equipe1;
            simulationFoot.Equipe2 = equipe2;

            simulationFoot.Equipe1.FontColor = Brushes.Green;
            simulationFoot.Equipe2.FontColor = Brushes.OrangeRed;


            return simulationFoot;
        }
    }

    public class EquipeFabrique : FabriqueAbstraite
    {
        private  JoueurFabrique joueurFactory;

        public  EquipeFabrique(string xml)
            : base(xml)
        {
            joueurFactory = new JoueurFabrique(xmlContent);
        }

        public Equipe CreerEquipe1()
        {
            xmlDoc.LoadXml(xmlContent);
            var equipeNode = xmlDoc.SelectSingleNode("//equipe[1]");
            var equipe = new Equipe(equipeNode.Attributes["nom"].Value);
            
            foreach(XmlNode joueurNode in equipeNode.ChildNodes)
            {
                equipe.AddJoueur(new Joueur(joueurNode.Attributes["prenom"].Value,joueurNode.Attributes["nom"].Value,joueurNode.Attributes["numero"].Value,joueurNode.Attributes["poste"].Value,joueurNode.Attributes["position"].Value));
            }
            return equipe;
        }

        public Equipe CreerEquipe2()
        {
            xmlDoc.LoadXml(xmlContent);
            var equipeNode = xmlDoc.SelectSingleNode("//equipe[2]");
            var equipe = new Equipe(equipeNode.Attributes["nom"].Value);

            foreach (XmlNode joueurNode in equipeNode.ChildNodes)
            {
                equipe.AddJoueur(new Joueur(joueurNode.Attributes["prenom"].Value, joueurNode.Attributes["nom"].Value, joueurNode.Attributes["numero"].Value, joueurNode.Attributes["poste"].Value, joueurNode.Attributes["position"].Value));
            }
            return equipe;
        }
    }

    public class JoueurFabrique : FabriqueAbstraite
    {
        public  JoueurFabrique(string xml)
            : base(xml)
        {

        }

        public Joueur CreerJoueur(string nomEquipe,int i,SimulationFootball sim)
        {
            xmlDoc.LoadXml(xmlContent);

            var request = String.Format("//equipe[@nom={0}]/joueur[{1}]", nomEquipe, i);
            var joueurNode = xmlDoc.SelectSingleNode(request);

            var prenom = joueurNode.Attributes["prenom"].Value;
            var nom = joueurNode.Attributes["nom"].Value;
            var numero = joueurNode.Attributes["numero"].Value;
            var poste = joueurNode.Attributes["poste"].Value;
            var placement = joueurNode.Attributes["position"].Value;

            return new Joueur(prenom, nom, numero, poste,placement);
        }
    }

}
