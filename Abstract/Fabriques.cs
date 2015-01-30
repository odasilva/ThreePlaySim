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

    //public class MapFabrique : FabriqueAbstraite
    //{

    //    public MapFabrique(String xml)
    //        :base(xml)
    //    {
    //    }

    //    public SimulationMap CreeMap(System.Drawing.Bitmap img, SimulationAbstraite simulation)
    //    {
    //        var map = new SimulationMap(simulation);
    //        map.WindowState = FormWindowState.Maximized;
    //        XmlDocument doc = new XmlDocument();
    //        doc.LoadXml(xmlContent);
    //        var hauteurTerrain = int.Parse(doc.GetElementsByTagName("dimension")[0].Attributes["height"].Value);
    //        var largeurTerrain = int.Parse(doc.GetElementsByTagName("dimension")[0].Attributes["width"].Value);

    //        map.fond = new PictureBox();
    //        map.fond.Image = img;
    //        map.fond.Height = hauteurTerrain;
    //        map.fond.Width = largeurTerrain;
    //        map.Controls.Add(map.fond);

    //        return map;
    //    }
    //}

    //public class GridFabrique : FabriqueAbstraite
    //{
    //    public GridFabrique(String xml)
    //        :base(xml)
    //    {
    //    }

    //    public List<List<Area>> CreerGrid()
    //    {
    //        var doc = new XmlDocument();
    //        doc.LoadXml(Properties.Resources.footballMap);
    //        var largeurGrid = int.Parse(doc.GetElementsByTagName("map")[0].Attributes["width"].Value);
    //        var longueurGrid = int.Parse(doc.GetElementsByTagName("map")[0].Attributes["height"].Value);
    //        var longueurArea = int.Parse(doc.GetElementsByTagName("map")[0].Attributes["tileheight"].Value);
    //        var largeurArea = int.Parse(doc.GetElementsByTagName("map")[0].Attributes["tilewidth"].Value);
    //        int x, y;
    //        int areaId = 0;
    //        //var grid = new Area[longueurGrid, largeurGrid];
    //        var grid = new List<List<Area>>(largeurGrid);

    //        for (int i = 0; i < longueurGrid; i++)
    //        {
    //            y = i * longueurArea;
    //            grid.Add(new List<Area>());
    //            for (int j = 0; j < largeurGrid; j++)
    //            {
    //                x = j * largeurArea;
    //                //grid[i, j] = new Area(areaId++, x, y, i, j);
    //                //GetAreaProperties(doc, grid[i, j]);
    //                grid[i].Add(new Area(areaId++, x, y, i, j));
    //                GetAreaProperties(doc, grid[i][j]);
    //            }
    //        }
            
    //        return grid;
    //    }

    //    private void GetAreaProperties(XmlDocument doc,Area area)
    //    {
    //        var tilesNodesList = doc.GetElementsByTagName("tileset")[0].ChildNodes;
    //        foreach(XmlNode tileNode in tilesNodesList)
    //        {
    //            if(tileNode.Name != "tile")
    //                continue;
    //            if( int.Parse(tileNode.Attributes["id"].Value) == area.Id)
    //            {
    //                foreach(XmlNode propertyNode in tileNode.FirstChild.ChildNodes)
    //                {
    //                    area.Proprietes.Add(propertyNode.Attributes["name"].Value, propertyNode.Attributes["value"].Value);
    //                }
    //            }
                    
    //        }
    //    }
    //}


}
