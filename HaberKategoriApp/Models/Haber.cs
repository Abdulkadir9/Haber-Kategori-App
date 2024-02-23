using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberKategoriApp.Models
{
    public class Haber
    {
        [Key]
        public int h_Id { get; set; }
        public string h_Baslik { get; set; }
        public string h_Aciklama { get; set; }
        public int h_KategoriId { get; set; }
        public Kategori Kategori { get; set; }

        public override string ToString()
        {
            string kategoriAd = "";
            foreach (var kateg in Data.db.Kategoris)
            {
                if (kateg.k_Id == h_KategoriId)
                {
                    kategoriAd = kateg.k_Baslik;
                }
            }

            return $"{h_Baslik} - {kategoriAd}\n{h_Aciklama}";
        }
    }
}
