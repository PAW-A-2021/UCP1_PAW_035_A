using System;
using System.Collections.Generic;

#nullable disable

namespace TokoLaundry.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public string NoTelpon { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
