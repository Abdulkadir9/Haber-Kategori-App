using HaberKategoriApp.Models;
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

namespace HaberKategoriApp.Views
{
    /// <summary>
    /// Interaction logic for DetayPage.xaml
    /// </summary>
    public partial class DetayPage : Page
    {
        public DetayPage(Haber haber)
        {
            InitializeComponent();

            txtBaslik.Text = haber.h_Baslik;
            txtAciklama.Text = haber.h_Aciklama;

            foreach(var kategori in Data.db.Kategoris)
            {
                if (kategori.k_Id == haber.h_KategoriId)
                {
                    txtKategori.Text = kategori.k_Baslik;
                }
            }

            
        }
    }
}
