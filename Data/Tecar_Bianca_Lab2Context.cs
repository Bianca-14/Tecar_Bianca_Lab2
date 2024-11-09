using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tecar_Bianca_Lab2.Models;

namespace Tecar_Bianca_Lab2.Data
{
    public class Tecar_Bianca_Lab2Context : DbContext
    {
        public Tecar_Bianca_Lab2Context (DbContextOptions<Tecar_Bianca_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Tecar_Bianca_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Tecar_Bianca_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
