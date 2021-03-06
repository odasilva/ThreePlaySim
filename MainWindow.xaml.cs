﻿using System;
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
using ThreePlaySim.Abstract;

namespace ThreePlaySim
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSimFoot_Click(object sender, RoutedEventArgs e)
        {
            var fabrique = new SimulationFootballFabrique(Properties.Resources.footballSimulation);
            var simFoot = fabrique.CreerSimulation();
            simFoot.RenderMap();
        }

        private void btnSimWar_Click(object sender, RoutedEventArgs e)
        {
            var fabrique = new SimulationWarFabrique(Properties.Resources.SimulationWar);
            var simWar = fabrique.CreerSimulation();
            simWar.RenderMap();
        }

        private void btnSimTraffic_Click(object sender, RoutedEventArgs e)
        {
            var fabrique = new SimulationTrafficFabrique(Properties.Resources.SimulationTraffic);
            var simTraffic = fabrique.CreerSimulation();
            simTraffic.RenderMap();
        }
    }
}
