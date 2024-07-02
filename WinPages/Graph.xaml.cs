using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using Module;
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

namespace WinPages
{
    /// <summary>
    /// Логика взаимодействия для Graph.xaml
    /// </summary>
    public partial class Graph : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> YFormatter { get; set; }
        public Graph()
        {
            InitializeComponent();
            ReturnPage.Focus();
            if (ModuleData.Trigegr == 1)
            {
                ChartValues<ObservablePoint> observablePointsY = new ChartValues<ObservablePoint>();
                ChartValues<ObservablePoint> observablePointsSortY = new ChartValues<ObservablePoint>();
                for (int i = 0; i < ModuleData.YSort.Length; i++)
                {
                    observablePointsY.Add(new ObservablePoint(i, ModuleData.Y[i]));
                    observablePointsSortY.Add(new ObservablePoint(i, ModuleData.YSort[i]));
                }
                SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values=observablePointsY,
                    Title="Массив Y"
                },
                new LineSeries
                {
                    Values=observablePointsSortY,
                    Title="Сортированный массив Y"
                }

             };
                YFormatter = value => value.ToString("C");
                DataContext = this;
            }
        }

        private void ReturnPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AllData.xaml", UriKind.Relative));
        }
    }
}
