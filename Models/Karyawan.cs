using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_010_A.Models
{
    public partial class Karyawan
    {
        public Karyawan()
        {
            Gajis = new HashSet<Gaji>();
        }

        public int Idkaryawan { get; set; }
        public long Nip { get; set; }
        public string Nama { get; set; }
        public string JenisKelamin { get; set; }
        public string Alamat { get; set; }
        public int? Idjabatan { get; set; }
        public int? Idgolongan { get; set; }
        public string Status { get; set; }

        public virtual Golongan IdgolonganNavigation { get; set; }
        public virtual Jabatan IdjabatanNavigation { get; set; }
        public virtual ICollection<Gaji> Gajis { get; set; }
    }
}
