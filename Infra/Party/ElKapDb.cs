using System;
using ElKap.Data.Party;
using Microsoft.EntityFrameworkCore;

namespace ElKap.Infra.Party
{
    public class ElKapDb : DbContext
    {
        public ElKapDb(DbContextOptions<ElKapDb> options) : base(options) { }

        public DbSet<PersonData> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder b)
        {
            InitializeTables(b);
        }

        public static void InitializeTables(ModelBuilder b)
        {
            b?.Entity<PersonData>()?.ToTable(nameof(Persons), nameof(ElKapDb).Substring(0, 5));
        }
    }
}

