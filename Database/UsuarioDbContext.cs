using Microsoft.EntityFrameworkCore;
using myProject.Model;

namespace myProject.Database
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext>
        options) : base(options) { 

        }



        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Destino> Destinos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            var usuario = modelBuilder.Entity<Usuario>();
            usuario.ToTable("usuario");
            usuario.HasKey(x => x.Id);
            usuario.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            usuario.Property(x => x.DataNascimento).HasColumnName("data_nascimento");

            var destino = modelBuilder.Entity<Destino>();
            destino.ToTable("destino");
            destino.HasKey(x => x.Id);
            destino.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            destino.Property(x => x.destino).HasColumnName("destino").IsRequired();
            destino.Property(x => x.checkIn).HasColumnName("check_in").IsRequired();
            destino.Property(x => x.checkOut).HasColumnName("check_out").IsRequired();

            var cliente = modelBuilder.Entity<Cliente>();
            cliente.ToTable("cliente");
            cliente.HasKey(x => x.Id);
            cliente.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            cliente.Property(x => x.TipoPessoa).HasColumnName("tipo_pessoa").IsRequired();
            cliente.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            cliente.Property(x => x.CpfCnpj).HasColumnName("cpf_cnpj").IsRequired();
            cliente.Property(x => x.Endereco).HasColumnName("endereco").IsRequired();
            cliente.Property(x => x.Cidade).HasColumnName("cidade").IsRequired();
            cliente.Property(x => x.UfEstado).HasColumnName("uf_estado").IsRequired();
            cliente.Property(x => x.Telefone).HasColumnName("telefone").IsRequired();
            cliente.Property(x => x.Email).HasColumnName("email").IsRequired();
            cliente.Property(x => x.Mensagem).HasColumnName("mensagem");
        }

    }

        
}