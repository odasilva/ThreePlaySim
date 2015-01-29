using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ThreePlaySim
{
    /// <summary>
    /// Logique d'interaction pour Map.xaml
    /// </summary>
    public partial class Map : UserControl
    {
        private AreaCollection grid;
        public ObservableCollection<ObservableCollection<Area>> GridRows { get {return grid.Rows;} }
        private int nbLines, nbRows;

        public Map()
        {
            InitializeComponent();
            grid = new AreaCollection(30, 25);
            BoardControl.ItemsSource = GridRows;
        }

        public Area this[int x, int y]
        {
            get
            {
                return null;
            }
        }


    }



    public class AreaCollection
    {
        public ObservableCollection<ObservableCollection<Area>> Rows { get; set; }
        public int nbLines { get; set; }
        public int nbRows { get; set; }

        public AreaCollection(int columns, int lines)
        {
            nbLines = columns;
            nbRows = lines;
            Rows = new ObservableCollection<ObservableCollection<Area>>();
            for(int i = 0 ; i< columns; i++)
            {
                var line = new ObservableCollection<Area>();
                for(int j = 0; j < lines ; j++)
                {
                    var area = new Area(new Point(i, j));
                    line.Add(area);
                }
                Rows.Add(line);
            }
        }
    }
}
