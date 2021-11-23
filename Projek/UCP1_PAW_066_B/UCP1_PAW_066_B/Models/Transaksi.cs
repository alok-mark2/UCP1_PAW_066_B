using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_066_B.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdProduk { get; set; }
        public int? IdAdmin { get; set; }
        public string TotalTransaksi { get; set; }

        public virtual Admind IdAdminNavigation { get; set; }
        public virtual Produk IdProdukNavigation { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
