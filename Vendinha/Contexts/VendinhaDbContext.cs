using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Vendinha.Models;

namespace Vendinha.Contexts
{
    public class VendinhaDbContext : DbContext
    {
        private readonly string? connectionString;

        public VendinhaDbContext(string connString)
        {
            this.connectionString = connString;
        }

        public VendinhaDbContext(DbContextOptions<VendinhaDbContext> opt) : base(opt)
        { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Divida> Dividas => Set<Divida>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ----- clientes -----
            var entityCliente = modelBuilder.Entity<Cliente>();
            entityCliente.ToTable("clientes");
            entityCliente.HasKey(c => c.Id);
            entityCliente.Property(c => c.Id).HasColumnName("id");
            entityCliente.Property(c => c.Nome).HasColumnName("nome").HasMaxLength(150);
            entityCliente.Property(c => c.Cpf).HasColumnName("cpf").HasMaxLength(11);
            entityCliente.Property(c => c.DataNascimento).HasColumnName("data_nascimento").HasColumnType("date");
            entityCliente.Property(c => c.Email).HasColumnName("email").HasMaxLength(150);
            entityCliente.HasIndex(c => c.Cpf).IsUnique();
            entityCliente.Ignore(c => c.Idade);
            entityCliente.Ignore(c => c.CpfFormatado);
            entityCliente.HasMany(c => c.Dividas)
                .WithOne()
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // ----- dividas -----
            var entityDivida = modelBuilder.Entity<Divida>();
            entityDivida.ToTable("dividas");
            entityDivida.HasKey(d => d.Id);
            entityDivida.Property(d => d.Id).HasColumnName("id");
            entityDivida.Property(d => d.ClienteId).HasColumnName("cliente_id");
            entityDivida.Property(d => d.Valor).HasColumnName("valor").HasColumnType("numeric(12,2)");
            entityDivida.Property(d => d.Paga).HasColumnName("paga");
            entityDivida.Property(d => d.DataCriacao).HasColumnName("data_criacao");
            entityDivida.Property(d => d.DataPagamento).HasColumnName("data_pagamento");
            entityDivida.Ignore(d => d.Situacao);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseNpgsql(connectionString)
                    .LogTo(message => Debug.WriteLine(message))
                    .EnableDetailedErrors();
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
