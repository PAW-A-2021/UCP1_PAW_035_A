using System;
using System.Collections.Generic;

#nullable disable

namespace TokoLaundry.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdAdmin { get; set; }
        public string NamaAdmin { get; set; }
        public string NoTelpon { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
