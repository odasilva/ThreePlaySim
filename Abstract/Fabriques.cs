using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreePlaySim.FootballPlaySim;
using System.Xml;
using ThreePlaySim.TraficPlaySim;
using ThreePlaySim.WarPlaySim;
using System.Windows.Media;
using ThreePlaySim.Abstract;
using ThreePlaySim.TraficPlaySim.model;

namespace ThreePlaySim.Abstract
{
    public class SimulationTrafficFabrique : FabriqueAbstraite
    {
        public SimulationTrafficFabrique(string xml)
            : base(xml)
        {

        }
        public SimulationTraffic CreerSimulation()
        {
            var simulationTraffic = new SimulationTraffic(xmlContent, Properties.Resources.TrafficMap);

            xmlDoc.LoadXml(xmlContent);
            var parcFabrique = new ParcFabrique(xmlContent);
            var parcAuto = parcFabrique.CreerParcAutomobile(simulationTraffic);
            var parcFeu = parcFabrique.CreerParcFeux(simulationTraffic);

            parcAuto.ListComposantRoutier().ForEach(P => simulationTraffic.AjoutePersonnage(P));
            parcFeu.ListComposantRoutier().ForEach(P => simulationTraffic.AjoutePersonnage(P));

            simulationTraffic.parcAuto = parcAuto;
            simulationTraffic.parcFeu = parcFeu;

            return simulationTraffic;
        }

        public class ParcFabrique : FabriqueAbstraite
        {
            private VehiculeFabrique vehiculeFabrique;
            private FeuFabrique feuFabrique;

            public ParcFabrique(string xml)
                : base(xml)
            {
                vehiculeFabrique = new VehiculeFabrique(xmlContent);
                feuFabrique = new FeuFabrique(xmlContent);
            }

            public ParcAutomobile CreerParcAutomobile(SimulationAbstraite simulation)
            {
                xmlDoc.LoadXml(xmlContent);
                var composantNode = xmlDoc.SelectSingleNode("//Vehicules[1]");
                var parcAutomobile = new ParcAutomobile();
                int i = 0;
                foreach (XmlNode composantRoutierNode in composantNode.ChildNodes)
                {
                    Vehicule vehicule = new Vehicule(composantRoutierNode.Attributes["nom"].Value, 
                                                        composantRoutierNode.Attributes["x"].Value, 
                                                        composantRoutierNode.Attributes["y"].Value,
                                                        composantRoutierNode.Attributes["conduite"].Value, simulation);
                    parcAutomobile.AddComposantRoutier(vehicule);
                }
                return parcAutomobile;
            }

            public ParcFeu CreerParcFeux(SimulationAbstraite simulation)
            {
                xmlDoc.LoadXml(xmlContent);
                var composantNode = xmlDoc.SelectSingleNode("//Feux[1]");
                var parcFeu = new ParcFeu();

                foreach (XmlNode composantRoutierNode in composantNode.ChildNodes)
                {
                    Feu feu = new Feu(composantRoutierNode.Attributes["nom"].Value, composantRoutierNode.Attributes["x"].Value, composantRoutierNode.Attributes["y"].Value, simulation);
                    parcFeu.AddComposantRoutier(feu);
                }
                return parcFeu;
            }
        }

        public class VehiculeFabrique : FabriqueAbstraite
        {
            public VehiculeFabrique(string xml)
                : base(xml)
            {}

            public Vehicule CreerVehiculeRoutier(int i, SimulationTraffic sim)
            {
                xmlDoc.LoadXml(xmlContent);

                var request = String.Format("//vehicules/composantRoutier[{0}]", i);
                var composantRoutierNode = xmlDoc.SelectSingleNode(request);
                
                var nom = composantRoutierNode.Attributes["nom"].Value;
                var x = composantRoutierNode.Attributes["x"].Value;
                var y = composantRoutierNode.Attributes["y"].Value;
                var conduite = composantRoutierNode.Attributes["conduite"].Value;

                return new Vehicule(nom, x, y, conduite, sim);
            }
        }

        public class FeuFabrique : FabriqueAbstraite
        {
            public FeuFabrique(string xml)
                : base(xml)
            {

            }

            public Feu CreerComposantRoutier(string nomComposant, int i, SimulationAbstraite sim)
            {
                xmlDoc.LoadXml(xmlContent);

                var request = String.Format("//feux/composantRoutier[{0}]", i);
                var composantRoutierNode = xmlDoc.SelectSingleNode(request);

                var nom = composantRoutierNode.Attributes["nom"].Value;
                var x = composantRoutierNode.Attributes["x"].Value;
                var y = composantRoutierNode.Attributes["y"].Value;

                return new Feu(nom, x, y, sim);
            }
        }
    }


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

            var simulationFoot = new SimulationFootball(xmlContent,Properties.Resources.FootballMap );
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
        public SimulationWar CreerSimulation()
        {
            xmlDoc.LoadXml(xmlContent);
            var armeeFactory = new ArmeeFabrique(xmlContent);
            var armeA = armeeFactory.CreerArmeeA();
            var armeB = armeeFactory.CreerArmeeB();

            var simulationWar = new SimulationWar(xmlContent,Properties.Resources.WarMap);
            armeA.ListSoldats.ForEach(P => simulationWar.AjoutePersonnage(P));
            armeB.ListSoldats.ForEach(P => simulationWar.AjoutePersonnage(P));

            simulationWar.armeA = armeA;
            simulationWar.armeB = armeB;

            simulationWar.armeA.FontColor = Brushes.Gold;
            simulationWar.armeB.FontColor = Brushes.CornflowerBlue;


            return simulationWar;
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


public class ArmeeFabrique : FabriqueAbstraite
{
    private ArmeeFabrique armeeFactory;

    public ArmeeFabrique(string xml)
        : base(xml)
    {
        //armeeFactory = new SoldatFabrique(xmlContent);
    }

    public Armee CreerArmeeA()
    {
        xmlDoc.LoadXml(xmlContent);
        var armeeNode = xmlDoc.SelectSingleNode("//armee[1]");
        var armee = new Armee(armeeNode.Attributes["nom"].Value);

        foreach (XmlNode soldatNode in armeeNode.ChildNodes)
        {
            var soldat = new Soldat(soldatNode.Attributes["prenom"].Value, soldatNode.Attributes["nom"].Value, soldatNode.Attributes["type"].Value);
            armee.AddSoldat(soldat);
        }
        return armee;
    }


    public Armee CreerArmeeB()
    {
        xmlDoc.LoadXml(xmlContent);
        var armeeNode = xmlDoc.SelectSingleNode("//armee[2]");
        var armee = new Armee(armeeNode.Attributes["nom"].Value);

        foreach (XmlNode soldatNode in armeeNode.ChildNodes)
        {
            armee.AddSoldat(new Soldat(soldatNode.Attributes["prenom"].Value, soldatNode.Attributes["nom"].Value, soldatNode.Attributes["type"].Value));
        }
        return armee;
    }


    public class SoldatFabrique : FabriqueAbstraite
    {
        public SoldatFabrique(string xml)
            : base(xml)
        {

        }

        public Soldat CreerSoldat(string nomArmee, int i, SimulationWar sim)
        {
            xmlDoc.LoadXml(xmlContent);

            var request = String.Format("//armee[@nom={0}]/soldat[{1}]", nomArmee, i);
            var soldatNode = xmlDoc.SelectSingleNode(request);

            var prenom = soldatNode.Attributes["prenom"].Value;
            var nom = soldatNode.Attributes["nom"].Value;
            var type = soldatNode.Attributes["type"].Value;

            return new Soldat(prenom, nom, type);
        }
    }
}
