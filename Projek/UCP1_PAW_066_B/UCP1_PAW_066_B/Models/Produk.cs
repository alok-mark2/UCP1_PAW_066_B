using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_066_B.Models
{
    public partial class Produk
    {
        public Produk()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdProduk { get; set; }
        public string NamaProduk { get; set; }
        public string Quantity { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
