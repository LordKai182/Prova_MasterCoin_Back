using Domain.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class UsuarioMapp : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.ToTable("Usuariuo", "cadastros");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Nome).IsRequired().ForNpgsqlHasComment("os Valores nesta coluna nao serao considerados martescoin nem mc"); ;
            entity.Property(u => u.DataNascimento).IsRequired();
            entity.Property(u => u.Email).IsRequired();
            entity.Property(u => u.Senha).IsRequired();
            entity.Property(u => u.NomeUsuario).IsRequired();
        }
    }
}
