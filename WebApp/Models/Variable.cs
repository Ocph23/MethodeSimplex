using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Variable
    {
        public int Id { get; set; }
        public int NamaVariable { get; set; }

        public virtual ICollection<HasilKeuntungan> HasilKeuntungan{ get; set; }


    }
}
