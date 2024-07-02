using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Module;

namespace WinPages
{
    /// <summary>
    /// Логика взаимодействия для AllData.xaml
    /// </summary>
    public partial class AllData : Page
    {
        public AllData()
        {
            InitializeComponent();
            NextPage.Focus();
            if (ModuleData.Trigegr == 1)
            {
                LogicBusiness.RecordingAllDataTextFile();
                //using (StreamReader reader = new StreamReader("../../../../AllData.txt"))
                using (StreamReader reader = new StreamReader("../AllData.txt"))
                {
                    TextFile.AppendText(reader.ReadToEnd());
                }
            }
        }

        private void ReturnPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Arrays.xaml", UriKind.Relative));
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Graph.xaml", UriKind.Relative));
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый файл (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                StreamReader reader = new StreamReader(fileInfo.Open(FileMode.Open, FileAccess.Read), Encoding.UTF8);
                TextFile.Text = reader.ReadToEnd();
                reader.Close();
                return;
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Текстовый документ (*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.OpenFile(), Encoding.UTF8))
                {
                    sw.Write(TextFile.Text);
                    sw.Close();
                }
            }
        }
    }
}
