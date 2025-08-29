
using Consultorio.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Consultorio.Maps
{
    public class ConsultasMap : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.ToTable("Consultas");

            builder.HasKey(p => p.Id);

            builder.Property(c => c.PrecoConsulta)
            .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Paciente)
            .WithMany()
            .HasForeignKey(p => p.PacienteId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Profissional)
            .WithMany()
            .HasForeignKey(p => p.ProfissionalId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Especialidade)
            .WithMany()
            .HasForeignKey(e => e.EspecialidadeId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}