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
using Module;

namespace WinPages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            TextBoxR.Focus();
            if (ModuleData.R != 0 || ModuleData.B != 0 || ModuleData.C1 != 0 || ModuleData.M != 0 || ModuleData.Astart != 0 || ModuleData.Aend != 0 || ModuleData.H != 0)
            {
                TextBoxR.Text = $"{ModuleData.R}";
                TextBoxB.Text = $"{ModuleData.B}";
                TextBoxC1.Text = $"{ModuleData.C1}";
                TextBoxM.Text = $"{ModuleData.M}";
                TextBoxAStart.Text = $"{ModuleData.Astart}";
                TextBoxAEnd.Text = $"{ModuleData.Aend}";
                TextBoxH.Text = $"{ModuleData.H}";
            }
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxR.Text.Length == 0)
            {
                TextBoxR.ToolTip = "Это поле пустое";
                TextBoxR.Background = Brushes.DarkRed;
                TextBoxR.Foreground = Brushes.White;
                TextBoxR.Focus();
            }
            else
            {
                TextBoxR.ToolTip = "Возможно число с плавающей точкой";
                TextBoxR.Background = Brushes.Transparent;
                TextBoxR.Foreground = Brushes.Black;
                if (TextBoxB.Text.Length == 0)
                {
                    TextBoxB.ToolTip = "Это поле пустое";
                    TextBoxB.Background = Brushes.DarkRed;
                    TextBoxB.Foreground = Brushes.White;
                    TextBoxB.Focus();
                }
                else
                {
                    TextBoxB.ToolTip = "Возможно число с плавающей точкой";
                    TextBoxB.Background = Brushes.Transparent;
                    TextBoxB.Foreground = Brushes.Black;
                    if (TextBoxC1.Text.Length == 0)
                    {
                        TextBoxC1.ToolTip = "Это поле пустое";
                        TextBoxC1.Background = Brushes.DarkRed;
                        TextBoxC1.Foreground = Brushes.White;
                        TextBoxC1.Focus();
                    }
                    else
                    {
                        TextBoxC1.ToolTip = "Возможно число с плавающей точкой";
                        TextBoxC1.Background = Brushes.Transparent;
                        TextBoxC1.Foreground = Brushes.Black;
                        if (TextBoxM.Text.Length == 0)
                        {
                            TextBoxM.ToolTip = "Это поле пустое";
                            TextBoxM.Background = Brushes.DarkRed;
                            TextBoxM.Foreground = Brushes.White;
                            TextBoxM.Focus();
                        }
                        else
                        {
                            TextBoxM.ToolTip = "Целое число";
                            TextBoxM.Background = Brushes.Transparent;
                            TextBoxM.Foreground = Brushes.Black;
                            if (TextBoxAStart.Text.Length == 0)
                            {
                                TextBoxAStart.ToolTip = "Это поле пустое";
                                TextBoxAStart.Background = Brushes.DarkRed;
                                TextBoxAStart.Foreground = Brushes.White;
                                TextBoxAStart.Focus();
                            }
                            else
                            {
                                TextBoxAStart.ToolTip = "Целое число";
                                TextBoxAStart.Background = Brushes.Transparent;
                                TextBoxAStart.Foreground = Brushes.Black;
                                if (TextBoxAEnd.Text.Length == 0)
                                {
                                    TextBoxAEnd.ToolTip = "Это поле пустое";
                                    TextBoxAEnd.Background = Brushes.DarkRed;
                                    TextBoxAEnd.Foreground = Brushes.White;
                                    TextBoxAEnd.Focus();
                                }
                                else
                                {
                                    TextBoxAEnd.ToolTip = "Целое число";
                                    TextBoxAEnd.Background = Brushes.Transparent;
                                    TextBoxAEnd.Foreground = Brushes.Black;
                                    if (TextBoxH.Text.Length == 0)
                                    {
                                        TextBoxH.ToolTip = "Это поле пустое";
                                        TextBoxH.Background = Brushes.DarkRed;
                                        TextBoxH.Foreground = Brushes.White;
                                        TextBoxH.Focus();
                                    }
                                    else
                                    {
                                        TextBoxH.ToolTip = "Возможно число с плавающей точкой";
                                        TextBoxH.Background = Brushes.Transparent;
                                        TextBoxH.Foreground = Brushes.Black;
                                        NextPage.Focus();
                                        if (Convert.ToInt32(TextBoxAStart.Text) > Convert.ToInt32(TextBoxAEnd.Text))
                                        {
                                            MessageBox.Show("Не верный диапазон", "Неверно", MessageBoxButton.OK, MessageBoxImage.Information);
                                        }
                                        else
                                        {
                                            ModuleData.R = double.Parse(TextBoxR.Text);
                                            ModuleData.B = double.Parse(TextBoxB.Text);
                                            ModuleData.C1 = double.Parse(TextBoxC1.Text);
                                            ModuleData.M = int.Parse(TextBoxM.Text);
                                            ModuleData.Astart = int.Parse(TextBoxAStart.Text);
                                            ModuleData.Aend = int.Parse(TextBoxAEnd.Text);
                                            ModuleData.H = double.Parse(TextBoxH.Text);
                                            NavigationService.Navigate(new Uri("/Arrays.xaml", UriKind.Relative));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }                 
        }

        private void TextBoxR_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",") && (!TextBoxR.Text.Contains(",") && TextBoxR.Text.Length != 0) || (e.Text == "-") 
                && (!TextBoxR.Text.Contains("-") && TextBoxR.Text.Length == 0)))
            {
                e.Handled = true;
            }
        }

        private void TextBoxM_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (TextBoxM.Text.Length == 0 && e.Text == "0")
            {
                e.Handled = true;
            }
            else
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
            }
        }

        private void TextBoxAStart_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == "-") && (!TextBoxAStart.Text.Contains("-") && TextBoxAStart.Text.Length == 0)))
            {
                e.Handled = true;
            }
        }

        private void TextBoxH_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",") && (!TextBoxH.Text.Contains(",") && TextBoxH.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }

        private void TextBoxAEnd_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == "-") && (!TextBoxAEnd.Text.Contains("-") && TextBoxAEnd.Text.Length == 0)))
            {
                e.Handled = true;
            }
        }

        private void TextBoxC1_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",") && (!TextBoxC1.Text.Contains(",") && TextBoxC1.Text.Length != 0) || (e.Text == "-") 
                && (!TextBoxC1.Text.Contains("-") && TextBoxC1.Text.Length == 0)))
            {
                e.Handled = true;
            }
        }

        private void TextBoxB_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ",") && (!TextBoxB.Text.Contains(",") && TextBoxB.Text.Length != 0) || (e.Text == "-") 
                && (!TextBoxB.Text.Contains("-") && TextBoxB.Text.Length == 0)))
            {
                e.Handled = true;
            }
        }
    }
}
