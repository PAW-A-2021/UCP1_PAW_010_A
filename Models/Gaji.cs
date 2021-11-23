using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1_PAW_010_A.Models
{
    public partial class Gaji
    {
        public int Idgaji { get; set; }
        public int NoSlip { get; set; }
        public DateTime? Tanggal { get; set; }
        public string GajiBulan { get; set; }
        public int? Idkaryawan { get; set; }
        public int? Lembur { get; set; }
        public int? Masuk { get; set; }
        public int? SubTotal { get; set; }
        public int? Pph { get; set; }
        public int? Total { get; set; }

        public virtual Karyawan IdkaryawanNavigation { get; set; }
    }
}
