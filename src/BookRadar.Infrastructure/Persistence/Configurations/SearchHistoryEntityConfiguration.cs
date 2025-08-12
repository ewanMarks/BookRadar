using BookRadar.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookRadar.Infrastructure.Persistence.Configurations;

public sealed class SearchHistoryEntityConfiguration : IEntityTypeConfiguration<SearchHistoryEntity>
{
    public void Configure(EntityTypeBuilder<SearchHistoryEntity> b)
    {
        // Tabla con nombre del enunciado:
        b.ToTable("HistorialBusquedas"); // requerido por la prueba
        b.HasKey(x => x.Id);

        // Columnas
        b.Property(x => x.Author).HasColumnName("Autor").HasMaxLength(200).IsRequired();
        b.Property(x => x.Title).HasColumnName("Titulo").HasMaxLength(400).IsRequired();
        b.Property(x => x.PublicationYear).HasColumnName("AnioPublicacion");
        b.Property(x => x.Publisher).HasColumnName("Editorial").HasMaxLength(200);
        b.Property(x => x.SearchedAt).HasColumnName("FechaConsulta").IsRequired();

        // Índice para evitar duplicados cercanos (acelera ExistsWithin)
        b.HasIndex(x => new { x.Author, x.Title, x.SearchedAt });
    }
}
