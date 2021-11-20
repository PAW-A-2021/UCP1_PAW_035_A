using System;
using System.Collections.Generic;

#nullable disable

namespace TokoLaundry.Models
{
    public partial class Barang
    {
        public Barang()
        {
            Transaksis = new HashSet<Transaksi>();
        }

        public int IdBarang { get; set; }
        public string NamaBarang { get; set; }
        public int? HargaBarang { get; set; }
        public string JenisBarang { get; set; }

        public virtual ICollection<Transaksi> Transaksis { get; set; }
    }
}
