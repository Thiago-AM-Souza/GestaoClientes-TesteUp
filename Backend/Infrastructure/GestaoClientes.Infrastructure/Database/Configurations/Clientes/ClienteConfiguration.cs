using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GestaoClientes.Domain.Clientes;

namespace GestaoClientes.Infrastructure.Database.Configurations.Clientes
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("id");

            builder.Property(x => x.Nome)
                   .HasColumnName("nome");

            builder.ComplexProperty(x => x.Email, emailBuilder =>
            {
                emailBuilder.Property(e => e.Valor)
                            .HasColumnName("email")
                            .IsRequired();
            });

            builder.ComplexProperty(x => x.Cpf, cpfBuilder =>
            {
                cpfBuilder.Property(e => e.Valor)
                            .HasColumnName("cpf")
                            .IsRequired();
            });

            builder.OwnsMany(x => x.Telefones, b =>
            {
                b.ToTable("cliente_telefones");

                b.Property<Guid>("id");
                b.HasKey("id");

                b.Property(t => t.TipoTelefone).HasColumnName("tipo_telefone");
                b.Property(t => t.Valor).HasColumnName("numero");

                b.WithOwner().HasForeignKey("cliente_id");
            });

        }
    }
}
