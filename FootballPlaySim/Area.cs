using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ThreePlaySim.FootballPlaySim
{
    public class Area
    {
        public Point Location { get; set; }
        public int Id { get; set; }
        public Point GridLocation { get; set; }

        public Area(int id, int x,int y,int xGrid, int yGrid)
        {
            Id = id;
            Location = new Point(x, y);
            GridLocation = new Point(xGrid, yGrid);
        }
    }
}
