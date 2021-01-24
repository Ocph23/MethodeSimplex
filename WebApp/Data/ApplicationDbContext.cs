using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext  :DbContext
    {

        public DbSet<Variable> Variables { get; set; }
        public DbSet<Aturan> Aturans { get; set; }
        public DbSet<HasilKeuntungan> Hasils { get; set; }
        public DbSet<Kriteria> Kriteria{ get; set; }
        public DbSet<User> Users { get; set; }
        // Constructor - set name of connection
        public ApplicationDbContext() 
        {
        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
    
    }
}
