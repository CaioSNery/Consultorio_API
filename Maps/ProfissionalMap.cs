using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Maps
{
    public class ProfissionalMap : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.ToTable("Profissionais");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome).IsRequired();
            

            builder.HasOne(p => p.Especialidade)
              .WithMany(p => p.Profissionais)
               .HasForeignKey(e => e.EspecialidadeId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}