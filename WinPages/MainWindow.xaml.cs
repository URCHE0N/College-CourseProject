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
using BusinessLogic;
using Module;
using System.Diagnostics;

namespace WinPages
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Welcome welcome = new Welcome();
        public MainWindow()
        {
            InitializeComponent();
            frame.Content = welcome;
        }

        private void MainPage_Click(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            frame.Content = main;
        }

        private void ArraysPage_Click(object sender, RoutedEventArgs e)
        {
            Arrays arrays = new Arrays();
            frame.Content = arrays;
        }

        private void AllDataPage_Click(object sender, RoutedEventArgs e)
        {
            AllData allData = new AllData();
            frame.Content = allData;
        }

        private void GraphPage_Click(object sender, RoutedEventArgs e)
        {
            Graph graph = new Graph();
            frame.Content = graph;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены что хотите закрыть приложение?", "Выход", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void frame_LayoutUpdated(object sender, EventArgs e)
        {
            if (frame.Content != welcome)
            {
                Menu.Visibility = Visibility.Visible;
                RickAstley.Visibility = Visibility.Visible;
            }
            else if (frame.Content == welcome)
            {
                Menu.Visibility = Visibility.Collapsed;
                RickAstley.Visibility = Visibility.Collapsed;
            }
        }

        private void Example_Click(object sender, RoutedEventArgs e)
        {
            ModuleData.R = 0.2;
            ModuleData.B = -12.6;
            ModuleData.C1 = -5;
            ModuleData.M = 5;
            ModuleData.Astart = -10;
            ModuleData.Aend = 10;
            ModuleData.H = 0.2;
            ModuleData.S = 15;
            ModuleData.A = new int[,] { { 3, 8, -3, -1, 6}, { 2, 2, 0, 7, 6}, { 3, -6, 10, -2, -10}, { 4, 2, -4, 10, 9}, { 6, 3, 3, 2, -10} };
            ModuleData.C = new double[] { -5, -4.8, -4.6, -4.4, -4.2};
            ModuleData.X = new double[] { -15.29, -11.93, -17.92, -10.95, -17.71};
            ModuleData.Y = new double[] { -15.29, -11.15, -9.36, -9.26, -10.28, -11.93, -13.8, -15.55, -16.93, -17.75, -17.92, -17.41, -16.29, -14.68, -12.81, -10.95, -9.49, -8.87, -9.61, -12.33, -17.71};
            ModuleData.YSort = new double[] { -17.92, -17.75, -17.71, -17.41, -16.93, -16.29, -15.55, -15.29, -14.68, -13.8, -12.81, -12.33, -11.93, -11.15, -10.95, -10.28, -9.61, -9.49, -9.36, -9.26, -8.87};
            ModuleData.Trigegr = 1;
            Main main = new Main();
            frame.Content = main;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ModuleData.R = 0;
            ModuleData.B = 0;
            ModuleData.C1 = 0;
            ModuleData.M = 0;
            ModuleData.Astart = 0;
            ModuleData.Aend = 0;
            ModuleData.H = 0;
            ModuleData.Trigegr = 0;
            Main main = new Main();
            frame.Content = main;
        }

        private void UserGuide_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("UserGuide.chm");
        }

        private void RickAstley_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Какой еще Рик Эстли?!", "Рик Эстли?!", MessageBoxButton.OK, MessageBoxImage.Information);
            Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ&ab_channel=RickAstley");
        }
    }
}
