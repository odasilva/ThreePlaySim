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
using System.Windows.Shapes;
using ThreePlaySim.Abstract;

namespace ThreePlaySim
{
    /// <summary>
    /// Logique d'interaction pour SimulationView.xaml
    /// </summary>
    public partial class SimulationView : Window
    {
        private SimulationAbstraite simulation;
        public Map Map { get { return grid; } }
        public SimulationView(SimulationAbstraite sim)
        {
            InitializeComponent();
            simulation = sim;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (simulation.Timer.IsEnabled)
            {
                simulation.Timer.Stop();
                btnStop.Content = "Reprendre";
            }
            else
            {
                simulation.Timer.Start();
                btnStop.Content = "Pause";
            }
                
        }
    }
}
