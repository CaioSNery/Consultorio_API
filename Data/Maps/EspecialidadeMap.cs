using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Maps
{
    public class EspecialidadeMap : IEntityTypeConfiguration<Especialidade>
    {
        public void Configure(EntityTypeBuilder<Especialidade> builder)
        {
            builder.ToTable("EspecialidadesMedicas");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.PrecoConsulta)
            .HasColumnType("decimal(18,2)");

           
        }
    }
}