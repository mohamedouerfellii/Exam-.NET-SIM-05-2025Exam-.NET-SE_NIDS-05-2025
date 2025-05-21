using Examen.ApplicationCore.Domain;
using Examen.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Examen.Infrastructure
{
    public class EXContext : DbContext
    {
        public DbSet<Collaborateur> Collaborateurs { get; set; }
        public DbSet<Equipement> Equipements { get; set; }
        public DbSet<Musicien> Musiciens { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Studio> Studios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                            Initial Catalog=ExamenNIDS_SE;
                                            Integrated Security=true;
                                            MultipleActiveResultSets=true");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collaborateur>()
                .HasMany(c => c.Musiciens)
                .WithMany(m => m.Collaborateurs)
                .UsingEntity(e => e.ToTable("Collaborations"));

            modelBuilder.Entity<Collaborateur>()
                .Property(c => c.Role)
                .HasColumnName("RoleCollaborateur");

            modelBuilder.ApplyConfiguration(new ReservationConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
