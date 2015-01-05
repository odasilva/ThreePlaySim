using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreePlaySim.FootballPlaySim;
using System.Xml;

namespace ThreePlaySim.Abstract
{
    public class SimulationFabrique : FabriqueAbstraite
    {
        public override SimulationAbstraite CreerSimulationFootball()
        {
            Equipe equipe1, equipe2;
            var doc = new XmlDocument();
            doc.Load(@"C:\Users\jerome\Documents\GitHub\ThreePlaySim\FootballPlaySim\SimulationFootball.xml");
            var xmlEquipeList = doc.GetElementsByTagName("equipe");
            var xmlEquipe1JoueursList = xmlEquipeList[0].ChildNodes;
            var xmlEquipe2JoueursList = xmlEquipeList[1].ChildNodes;

            equipe1 = new Equipe(xmlEquipeList[0].Attributes["nom"].Value);
            equipe2 = new Equipe(xmlEquipeList[1].Attributes["nom"].Value);

            foreach(XmlNode node in xmlEquipe1JoueursList)
                equipe1.AddJoueur(new Joueur(node.Attributes["prenom"].Value, node.Attributes["nom"].Value, node.Attributes["numero"].Value, node.Attributes["poste"].Value));

            foreach (XmlNode node in xmlEquipe2JoueursList)
                equipe2.AddJoueur(new Joueur(node.Attributes["prenom"].Value, node.Attributes["nom"].Value, node.Attributes["numero"].Value, node.Attributes["poste"].Value));

            return new SimulationFootball(equipe1,equipe2);
        }

       
    }
}
