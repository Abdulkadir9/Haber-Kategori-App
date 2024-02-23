using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberKategoriApp.Models
{
    public class Kategori
    {
        [Key]
        public int k_Id { get; set; }
        public string k_Baslik { get; set; }
        public List<Haber> Habers { get; set; }

        public override string ToString()
        {
            return $"{k_Baslik}";
        }
    }
}
