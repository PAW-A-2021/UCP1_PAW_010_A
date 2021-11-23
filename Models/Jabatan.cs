using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_010_A.Models
{
    public partial class Jabatan
    {
        public Jabatan()
        {
            Karyawans = new HashSet<Karyawan>();
        }

        public int Idjabatan { get; set; }
        public string Jabatan1 { get; set; }
        public int? Gajipokok { get; set; }
        public int? TjJabatan { get; set; }

        public virtual ICollection<Karyawan> Karyawans { get; set; }
    }
}
