using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class Aturan
    {
        public int Id { get; set; }

        public string NamaAturan { get; set; }

        public int KriteriaId { get; set; }
    }
}
