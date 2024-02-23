using HaberKategoriApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace HaberKategoriApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button btn = new Button();
        public MainWindow()
        {
            InitializeComponent();

            btn.Click += Btn_Click;
            btnMenu.Click += Btn_Click;
            btnAnasayfa.Click += Btn_Click;
            btnEkle.Click += Btn_Click;
            btnListe.Click += Btn_Click;
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            btn = sender as Button;
            Frame.Visibility = Visibility.Visible;            
            switch (btn.Name)
            {
                case "btnMenu":                    
                    if (spMenu.Width != 0)
                    {
                        spMenu.Width = 0;
                    }
                    else
                    {
                        spMenu.Width = 152;
                    }
                    break;

                case "btnAnasayfa":
                    Frame.Visibility = Visibility.Hidden;
                    break;

                case "btnEkle":
                    Frame.Navigate(new EklePage());
                    break;

                case "btnListe":
                    Frame.Navigate(new ListPage());
                    break;                    
            }
        }

    }
}
