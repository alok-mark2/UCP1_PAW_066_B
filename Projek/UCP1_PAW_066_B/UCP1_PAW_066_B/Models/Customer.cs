using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_066_B.Models
{
    public partial class Customer
    {
        public int IdCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public string Alamat { get; set; }
        public string Telephone { get; set; }

        public virtual Transaksi IdCustomerNavigation { get; set; }
    }
}
