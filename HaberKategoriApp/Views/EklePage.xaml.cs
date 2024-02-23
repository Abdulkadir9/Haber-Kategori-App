using HaberKategoriApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for EklePage.xaml
    /// </summary>
    public partial class EklePage : Page
    {
        TextBox txt = new TextBox();
        Haber habers;

        public EklePage()
        {
            InitializeComponent();

            cbHaberKategori.ItemsSource = Data.db.Kategoris.ToList();           
            cbHaberKategori.SelectedIndex = 0;            

            btnKategoriEkle.Click += BtnKategoriEkle_Click;

            txtKategoriBaslik.TextChanged += TxtChanged_TextChanged;
            txtHaberBaslik.TextChanged += TxtChanged_TextChanged;
            txtHaberAciklama.TextChanged += TxtChanged_TextChanged;

            btnHaberEkle.Click += BtnHaberEkle_Click;
        }
        public EklePage(Haber haber) : this()
        {
            habers = haber;

            txtHaberBaslik.Text = habers.h_Baslik;
            txtHaberAciklama.Text = habers.h_Aciklama;
            foreach (var k in Data.db.Kategoris)
            {
                if (k.k_Id == haber.h_KategoriId)
                {
                    cbHaberKategori.SelectedIndex = k.k_Id-1;
                }
            }
        }
        private void TxtChanged_TextChanged(object sender, TextChangedEventArgs e)
        {
            txt = sender as TextBox;
            txt.BorderBrush = new SolidColorBrush(Color.FromRgb(30, 30, 30));
        }

        private void BtnHaberEkle_Click(object sender, RoutedEventArgs e)
        {
            if (habers == null)
            {
                if (!String.IsNullOrEmpty(txtHaberBaslik.Text) && !String.IsNullOrWhiteSpace(txtHaberBaslik.Text))
                {
                    if (!String.IsNullOrEmpty(txtHaberAciklama.Text) && !String.IsNullOrWhiteSpace(txtHaberAciklama.Text))
                    {
                        foreach (var Kategori in Data.db.Kategoris)
                        {
                            if (Kategori.k_Baslik == cbHaberKategori.SelectedItem.ToString())
                            {
                                Data.db.Habers.Add(new Haber()
                                {
                                    h_Baslik = txtHaberBaslik.Text,
                                    h_Aciklama = txtHaberAciklama.Text,
                                    h_KategoriId = Kategori.k_Id
                                });
                            }
                        }
                        Data.db.SaveChanges();

                        MessageBox.Show("Haber eklendi.", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new ListPage());
                    }
                    else
                    {
                        txtHaberAciklama.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                }
                else
                {
                    txtHaberBaslik.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                foreach (var Kategori in Data.db.Kategoris)
                {
                    if (Kategori.k_Baslik == cbHaberKategori.SelectedItem.ToString())
                    {
                        habers.h_Baslik = txtHaberBaslik.Text;
                        habers.h_Aciklama = txtHaberAciklama.Text;
                        habers.h_KategoriId = Kategori.k_Id;
                        
                        MessageBox.Show("Haber değiştirildi.", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
                        NavigationService.Navigate(new ListPage());
                    }
                }
                Data.db.SaveChanges();
            }
        }
        private void BtnKategoriEkle_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtKategoriBaslik.Text) && !String.IsNullOrWhiteSpace(txtKategoriBaslik.Text))
            {
                Data.db.Kategoris.Add(new Kategori()
                {
                    k_Baslik = txtKategoriBaslik.Text
                });
                Data.db.SaveChanges();

                cbHaberKategori.SelectedIndex = cbHaberKategori.Items.Count;
                cbHaberKategori.ItemsSource = Data.db.Kategoris.ToList();
                txtKategoriBaslik.Clear();
                txtHaberBaslik.Focus();
                MessageBox.Show("Kategori eklendi.", "Bilgilendirme", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                txtKategoriBaslik.BorderBrush = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
