using System;
using System.Collections.Generic;

#nullable disable

namespace TokoLaundry.Models
{
    public partial class Transaksi
    {
        public int IdTransaksi { get; set; }
        public int? IdAdmin { get; set; }
        public int? IdBarang { get; set; }
        public int? IdCustomer { get; set; }
        public DateTime? Tanggal { get; set; }
        public string Catatan { get; set; }
        public int? TotalTransaksi { get; set; }

        public virtual Barang IdAdmin1 { get; set; }
        public virtual Admin IdAdminNavigation { get; set; }
        public virtual Customer IdBarangNavigation { get; set; }
    }
}
