using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasOne(r => r.Musicien)
                .WithMany(m => m.Reservations)
                .HasForeignKey(r => r.MuscienFk);

            builder.HasOne(r => r.Studio)
                    .WithMany(s => s.Reservations)
                    .HasForeignKey(r => r.StudioFk);

            builder.HasKey(r => new { r.MuscienFk, r.StudioFk, r.DateReservation });
        }
    }
}
