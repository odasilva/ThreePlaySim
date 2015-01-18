using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ThreePlaySim
{
    public class Area
    {
        /// <summary>
        /// Coordonées de l'area en pixels
        /// </summary>
        public Point Location { get; set; }
        public int Id { get; set; }
        /// <summary>
        /// Coordonées de la position de l'area dans la grid
        /// </summary>
        public Point GridLocation { get; set; }
        public Dictionary<String,String> Proprietes { get; set; }

        public Area(int id, int pixelX,int pixelY,int xGrid, int yGrid)
        {
            Id = id;
            Location = new Point(pixelX,pixelY);
            GridLocation = new Point(xGrid, yGrid);
            Proprietes = new Dictionary<string, string>();
        }
    }
}
