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
using Microsoft.Win32;
using Module;
using BusinessLogic;

namespace WinPages
{
    /// <summary>
    /// Логика взаимодействия для Arrays.xaml
    /// </summary>
    public partial class Arrays : Page
    {
        public Arrays()
        {
            InitializeComponent();
            FillArrays.Focus();
            if (ModuleData.Trigegr == 1)
            {
                ArrayA.ItemsSource = FormirationDataGrid.ToDataTable(ModuleData.A).DefaultView;
                ArrayC.ItemsSource = FormirationDataGrid.ToDataTable(ModuleData.C).DefaultView;
                ArrayX.ItemsSource = FormirationDataGrid.ToDataTable(ModuleData.X).DefaultView;
                ArrayY.ItemsSource = FormirationDataGrid.ToDataTable(ModuleData.Y).DefaultView;
                ArraySortY.ItemsSource = FormirationDataGrid.ToDataTable(ModuleData.YSort).DefaultView;
            }
            if (ModuleData.R == 0 && ModuleData.B == 0 && ModuleData.C1 == 0 && ModuleData.M == 0 && ModuleData.Astart == 0 && ModuleData.Aend == 0 && ModuleData.H == 0)
            {
                FillArrays.IsEnabled = false;
            }
            else
            {
                FillArrays.IsEnabled = true;
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/AllData.xaml", UriKind.Relative));
        }

        private void ReturnPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Main.xaml", UriKind.Relative));
        }

        private void FillArrays_Click(object sender, RoutedEventArgs e)
        {
            LogicBusiness.RandomMassivA();
            ArrayA.ItemsSource = FormirationDataGrid.ToDataTable(ModuleData.A).DefaultView;
            LogicBusiness.MassivC();
            ArrayC.ItemsSource = FormirationDataGrid.ToDataTable(ModuleData.C).DefaultView;
            LogicBusiness.MainDiagonal(); 
            LogicBusiness.MassivX();
            ArrayX.ItemsSource = FormirationDataGrid.ToDataTable(ModuleData.X).DefaultView;
            LogicBusiness.MassivY();
            ArrayY.ItemsSource = FormirationDataGrid.ToDataTable(ModuleData.Y).DefaultView;
            LogicBusiness.SelectionSortMassivY();
            ArraySortY.ItemsSource = FormirationDataGrid.ToDataTable(ModuleData.YSort).DefaultView;
            ModuleData.Trigegr = 1;
        }
    }
}
