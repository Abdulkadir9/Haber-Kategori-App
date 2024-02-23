using HaberKategoriApp.Models;
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

namespace HaberKategoriApp.Views
{
    /// <summary>
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        MenuItem mi = new MenuItem();
        public ListPage()
        {
            InitializeComponent();

            lbList.ItemsSource = Data.db.Habers.ToList();
            listInterface("Hiç Haber Yok!");            

            txtAra.TextChanged += TxtAra_TextChanged;

            mi.Click += Mi_Click;
            miSil.Click += Mi_Click;
            miDuzenle.Click += Mi_Click;
            miDetay.Click += Mi_Click;
        }

        private void Mi_Click(object sender, RoutedEventArgs e)
        {
            mi = sender as MenuItem;
            
            var selectedItem = lbList.SelectedItem;
            if (selectedItem!=null)
            {                
                switch (mi.Name)
                {
                    case "miSil":
                        Data.db.Habers.Remove((Haber)selectedItem);
                        Data.db.SaveChanges();
                        MessageBox.Show("Haber silindi.", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);                        
                        break;

                    case "miDuzenle":
                        NavigationService.Navigate(new EklePage((Haber)selectedItem));
                        break;
                    case "miDetay":
                        NavigationService.Navigate(new DetayPage((Haber)selectedItem));
                        break;
                }
                lbList.ItemsSource = Data.db.Habers.ToList();
                listInterface("Hiç Haber Yok!");
            }
            else
            {
                MessageBox.Show("Seçili haber yok.", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void TxtAra_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAra.Text) && !String.IsNullOrWhiteSpace(txtAra.Text))
            {
                lbList.ItemsSource = Data.db.Habers.Where(x => x.h_Baslik.ToLower().Contains(txtAra.Text.ToLower())).ToList();               
                listInterface("Sonuç Bulunamadı!");
            }
            else
            {               
                lbList.ItemsSource = Data.db.Habers.ToList();
                listInterface("Hiç Haber Yok!");
            }
        }

        void listInterface(string message)
        {
            if (lbList.Items.Count != 0)
            {
                lbList.Visibility = Visibility.Visible;
            }
            else
            {
                lbList.Visibility = Visibility.Hidden;
                txtListSonuc.Text = message;
            }
        }
    }
}
