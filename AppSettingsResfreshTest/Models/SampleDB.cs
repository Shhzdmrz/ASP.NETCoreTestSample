using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace AppSettingsResfreshTest.Models
{
    public class SampleDB : DbContext
    {
        public SampleDB(string connectionString) : base(GetOptions(connectionString)) { }
        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
        public SampleDB(DbContextOptions<SampleDB> options) : base(options) { }
        public int BaseSaveChanges() => base.SaveChanges();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Item>().HasIndex(p => p.PK);
            modelBuilder.Entity<Item>().Property(b => b.PK).HasMaxLength(500);
        }
        public async Task<int> BaseSaveChangesAsync() => await base.SaveChangesAsync();
        public DbSet<Item> Items { get; set; }
    }

    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column(TypeName = "VARCHAR(200)")]
        public string PK { get; set; }
        [Column(TypeName = "NVARCHAR(1000)")]
        public string SK1 { get; set; }
        [Column(TypeName = "NVARCHAR(1000)")]
        public string SK2 { get; set; }
        [Column(TypeName = "NVARCHAR(1000)")]
        public string SK3 { get; set; }
        [Column(TypeName = "NVARCHAR(1000)")]
        public string SK4 { get; set; }
        [Column(TypeName = "NVARCHAR(1000)")]
        public string SK5 { get; set; }
        /// <summary>
        /// created date
        /// </summary>
        public DateTime SK20 { get; set; }
        /// <summary>
        /// last updated date
        /// </summary>
        public DateTime SK21 { get; set; }
        /// <summary>
        /// entity date
        /// </summary>
        public DateTime? SK22 { get; set; }
        public string Data { get; set; }
    }
}
