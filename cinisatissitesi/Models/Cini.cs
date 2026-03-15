using System.ComponentModel.DataAnnotations;

namespace cinisatissitesi.Models
{
    public class Cini
    {
        public int Id { get; set; }

        public string Ad { get; set; }

        public string Aciklama { get; set; }

        public decimal Fiyat { get; set; }

        public int Stok { get; set; }

        public string ResimUrl { get; set; }

        public string Kategori { get; set; }
    }
}