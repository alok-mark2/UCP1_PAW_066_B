using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_066_B.Models
{
    public partial class Admind
    {
        public Admind()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdAdmin { get; set; }
        public string NamaAdmin { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
