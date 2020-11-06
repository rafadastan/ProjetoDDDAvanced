using Microsoft.EntityFrameworkCore;
using Projeto01.Domain.Entities;
using Projeto01.Infra.Data.SqlServer.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto01.Infra.Data.SqlServer.Contexts
{
    //REGRA 1: Herdar DbContext
    public class SqlContext : DbContext
    {
        //REGRA 2: Construtor que possa receber os parametros
        //de configuração necessários para ativar o DbContext
        public SqlContext(DbContextOptions<SqlContext> options)
            : base(options) //construtor da superclasse
        {

        }

        //REGRA 3: Declarar uma propriedade DbSet para cada
        //entidade mapeada neste contexto de banco de dados
        public DbSet<EmpresaEntity> Empresa { get; set; }
        public DbSet<FuncionarioEntity> Funcionario { get; set; }
        public DbSet<UsuarioEntity> Usuario { get; set; }

        //REGRA 4: Sobrescrever o método OnModelCreating e adicionar
        //cada classe de mapeamento criada para o banco de dados
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            #region Índices

            modelBuilder.Entity<EmpresaEntity>(entity => {
                entity.HasIndex(e => e.RazaoSocial).IsUnique();
                entity.HasIndex(e => e.Cnpj).IsUnique();
            });

            modelBuilder.Entity<FuncionarioEntity>(entity => {
                entity.HasIndex(f => f.Cpf).IsUnique();
            });

            modelBuilder.Entity<UsuarioEntity>(entity => {
                entity.HasIndex(u => u.Email).IsUnique();
            });

            #endregion
        }
    }
}