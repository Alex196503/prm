using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProiectMediiBun.Models;

namespace ProiectMediiBun.Data
{
    public class ProiectMediiBunContext : DbContext
    {
        public ProiectMediiBunContext (DbContextOptions<ProiectMediiBunContext> options)
            : base(options)
        {
        }

        public DbSet<ProiectMediiBun.Models.Member> Member { get; set; } = default!;
        public DbSet<ProiectMediiBun.Models.Membership> Membership { get; set; } = default!;
        public DbSet<ProiectMediiBun.Models.Reservation> Reservation { get; set; } = default!;
        public DbSet<ProiectMediiBun.Models.Review> Review { get; set; } = default!;
        public DbSet<ProiectMediiBun.Models.Teren> Teren { get; set; } = default!;
        public DbSet<ProiectMediiBun.Models.Trainer> Trainer { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Teren)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TerenID)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Member>()
                .HasOne(m => m.Trainer)
                .WithMany(t => t.Members)
                .HasForeignKey(m => m.TrainerID)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
