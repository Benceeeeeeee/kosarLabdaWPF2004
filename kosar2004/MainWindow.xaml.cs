using kosar2000;
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

namespace kosar2004
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Adatbazis a;
        private List<Merkozes> lista;
        public MainWindow()
        {
            InitializeComponent();
            a = new Adatbazis();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lista = a.Feltolt();

            grid.ItemsSource = lista;
            button.IsEnabled = false;
        }

        private void f2_Click(object sender, RoutedEventArgs e)
        {
            tblock.Text = a.F2();
        }

        private void f3_Click(object sender, RoutedEventArgs e)
        {
            tblock.Text = a.F3();
        }

        private void f4_Click(object sender, RoutedEventArgs e)
        {
            tblock.Text = a.F4();
        }

        private void f5_Click(object sender, RoutedEventArgs e)
        {
            tblock.Text = a.F5();
        }

        private void f6_Click(object sender, RoutedEventArgs e)
        {
            tblock.Text = a.F6();
        }
    }
}
