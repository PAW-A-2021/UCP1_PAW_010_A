using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_010_A.Models
{
    public partial class Golongan
    {
        public Golongan()
        {
            Karyawans = new HashSet<Karyawan>();
        }

        public int Idgolongan { get; set; }
        public int Golongan1 { get; set; }
        public int? TjKeluarga { get; set; }
        public int? TjKesehatan { get; set; }
        public int? UangLembur { get; set; }
        public int? UangMakan { get; set; }

        public virtual ICollection<Karyawan> Karyawans { get; set; }
    }
}
