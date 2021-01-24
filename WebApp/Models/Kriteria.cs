using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Kriteria
    {
        public int Id { get; set; }
        public int NamaKriteria { get; set; }

        public virtual ICollection<JenisKayu> JenisKayu { get; set; }
        public virtual ICollection<Aturan> Aturan { get; set; }
    }
}
